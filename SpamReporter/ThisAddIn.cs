using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;


namespace SpamReporter
{
    public partial class ThisAddIn
    {
        Outlook.NameSpace m_outlookNameSpace;
        SpamChecker m_chcker = new SpamChecker();
        Outlook.MAPIFolder m_spamFolder;

        object m_lockProcessingItem = new object();
        bool m_bDontReportNewSpam = false;

        List<Outlook.Items> m_inboxItems = new List<Outlook.Items>();
        Outlook.Items m_spamItems;  

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            GlobalVar.instance().m_addin = this;
            onStartAddin();
        }

        public void onStartAddin()
        {
            //MessageBox.Show("onStartAddin");
            m_outlookNameSpace = Application.GetNamespace("MAPI");

            foreach (Outlook.MAPIFolder fld in m_outlookNameSpace.Folders)
            {
                if (!fld.Name.Contains("@")) continue;
                Outlook.MAPIFolder inBox = fld.Folders["Inbox"];
                if(inBox==null) continue;
                Outlook.Items items = inBox.Items;
                if (items == null) continue;
                m_inboxItems.Add(items);
                items.ItemAdd += new Outlook.ItemsEvents_ItemAddEventHandler(items_ItemAdd);
            }


            /*
                        foreach (Outlook.Store store in m_outlookNameSpace.Stores)
                        {
                            try
                            {
                                if (store == null) continue;
                                if (store.DisplayName == null) continue;
                                if (!store.DisplayName.Contains("@")) continue;
                                MessageBox.Show(store.DisplayName);

                                if (store.Session == null) continue;
                                Outlook.MAPIFolder inbox = store.Session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox);
                                if (inbox == null) continue;

                                Outlook.Items items = inbox.Items;
                                if (items == null) continue;

                                m_inboxItems.Add(items);
                                items.ItemAdd += new Outlook.ItemsEvents_ItemAddEventHandler(items_ItemAdd);
                            }
                            catch (Exception eee)
                            {
                                MessageBox.Show(eee.Message);
                            }
                        }
            */
            //MessageBox.Show("making spam folder");
            Outlook.MAPIFolder inbox_1th = (Outlook.MAPIFolder)this.Application.ActiveExplorer().Session.GetDefaultFolder
                        (Outlook.OlDefaultFolders.olFolderInbox);

            //spam folder setting
            if (inbox_1th != null)
            {
                foreach (Outlook.MAPIFolder fld in inbox_1th.Folders)
                {
                    if (fld.Name == "Spam Report")
                    {
                        m_spamFolder = fld;
                        break;
                    }
                }
                if (m_spamFolder == null)
                    inbox_1th.Folders.Add("Spam Report", Outlook.OlDefaultFolders.olFolderInbox);
                m_spamFolder = inbox_1th.Folders["Spam Report"];
                m_spamItems = m_spamFolder.Items;
                m_spamItems.ItemAdd += new Outlook.ItemsEvents_ItemAddEventHandler(spamItems_ItemAdd);
            }
            //MessageBox.Show("making spam folder finised");
            GlobalVar.instance().init(this.Application, this);
        }


        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            // Note: Outlook no longer raises this event. If you have code that 
            //    must run when Outlook shuts down, see https://go.microsoft.com/fwlink/?LinkId=506785
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }

        #endregion


        public void exploereSpamFolder()
        {
            Application.ActiveExplorer().CurrentFolder = m_spamFolder;
        }


        public void checkInboxAllItem()
        {
            GlobalVar global = GlobalVar.instance();
            if (global.m_bActivated == false || m_spamFolder == null) return;

            string strReason = "";
            int nMoved = 0;
            foreach (Outlook.Store store in m_outlookNameSpace.Stores)
            {
                if (!store.DisplayName.Contains("@")) continue;

                Outlook.MAPIFolder inbox = store.Session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox);

                foreach (object item in inbox.Items)
                {
                    if (item == null) continue;
                    if ((item is Outlook.MailItem) == false) continue;

                    Outlook.MailItem mail = item as Outlook.MailItem;
                    if (m_chcker.isSpam(mail, out strReason) == false) continue;

                    new Task(() => global.postSpamReport(mail.Sender.Address,
                        mail.Subject, "contents...", mail.To, strReason)).Start();

                    lock (m_lockProcessingItem)
                    {
                        m_bDontReportNewSpam = true;
                        mail.Move(m_spamFolder);
                        m_bDontReportNewSpam = false;
                    }
                    nMoved++;
                }
            }

            global.m_nSpamDetectCount += nMoved;
            global.updateRibbornBar();
        }

        void items_ItemAdd(object Item)
        {
            GlobalVar global = GlobalVar.instance();
            if (global.m_bActivated == false || m_spamFolder==null) return;
            string strReason = "";
            Outlook.MailItem mail = (Outlook.MailItem)Item;
            if (m_chcker.isSpam(mail, out strReason) == false) return;

            new Task(()=> global.postSpamReport(mail.Sender.Address, mail.Subject, "...", mail.To, strReason)).Start();

            lock(m_lockProcessingItem)
            {
                m_bDontReportNewSpam = true;
                mail.Move(m_spamFolder);
                m_bDontReportNewSpam = false;
            }

            global.m_nSpamDetectCount++;
            global.updateRibbornBar();
        }

        void spamItems_ItemAdd(object Item)
        {
            GlobalVar global = GlobalVar.instance();
            if (global.m_bActivated == false) return;
            if(m_bDontReportNewSpam == true) return;

            Outlook.MailItem mail = (Outlook.MailItem)Item;
            new Task(() => global.postNewSpamReport(mail.Sender.Address,mail.Subject, mail.Body, mail.To)).Start();

            global.m_nSpamDetectCount++;
            global.updateRibbornBar();
        }

        public void sendActivationMail()
        {
            Outlook.MailItem eMail = (Outlook.MailItem)this.Application.CreateItem(Outlook.OlItemType.olMailItem);
            eMail.Subject = "Activation SpamReporter";
            string[] toMail = new string[] { "activate@spamreport.com.au" };
            eMail.To = string.Join(";", toMail);
            eMail.CC = eMail.To;
            eMail.Body = "Activated";
            eMail.Importance = Outlook.OlImportance.olImportanceNormal;
            eMail.SaveSentMessageFolder = this.Application.Session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderSentMail);
            ((Outlook._MailItem)eMail).Send();
        }

    }
}
