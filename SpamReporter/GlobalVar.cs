using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
using Microsoft.Win32;
using System.Windows.Forms;

namespace SpamReporter
{
    class GlobalVar
    {
        private static GlobalVar m_s = new GlobalVar();
        public static GlobalVar instance()
        {
            return m_s;
        }

        public ThisAddIn m_addin = null;
        public Outlook.Application m_aplication = null;
        public bool m_bActivated = false;
        public SpamReporterRibborn m_ribbornBar = null;
        public Filters m_filters = new Filters();
        public int m_nSpamDetectCount = 0;
        IWebService _webService = new IWebService();

        public void init(Outlook.Application app, ThisAddIn addin)
        {
            m_addin = addin;
            m_aplication = app;
            checkActivated();
            new Task(()=> getBlackListFromServer(true)).Start();
        }


        public void getBlackListFromServer(bool bcheckMails )
        {
            if (m_bActivated == false) return;
                 
            filterData data = _webService.getFilterData();
            if (data == null) return;
            m_filters.init(data);

            if (m_addin != null && bcheckMails ==true)
                m_addin.checkInboxAllItem();
        }

        public void postSpamReport(string sender, string subject, string content, string receiver, string reason)
        {
            _webService.postSpamReport(sender, subject, content, receiver, reason);
        }

        public void postNewSpamReport(string sender, string subject, string content, string receiver)
        {
            _webService.postNewSpamReport(sender, subject, content, receiver);
        }


        private void checkActivated()
        {
            string strVal = RegistryManager.GetValue(Registry.CurrentUser, "SOFTWARE\\SpamReport", "Activated");
            if (strVal.Contains("1"))
                m_bActivated = true;
            else
                m_bActivated = false;
            updateRibbornBar();
        }
        public void setActivated()
        {
            RegistryManager.SetValue(Registry.CurrentUser, "SOFTWARE\\SpamReport", "Activated", "1");
            m_bActivated = true;
            updateRibbornBar();
        }

        public void updateRibbornBar()
        {
            if (m_ribbornBar == null) return;
            if (m_bActivated)
            {
                if (m_nSpamDetectCount == 0)
                {
                    m_ribbornBar.btn_option.Image = SpamReporter.Properties.Resources.active;
                    m_ribbornBar.btn_option.Label = "Option";
                }
                else
                {
                    m_ribbornBar.btn_option.Image = SpamReporter.Properties.Resources.spam;
                    m_ribbornBar.btn_option.Label = "(" + m_nSpamDetectCount.ToString() + ")";
                }
            }
            else
                m_ribbornBar.btn_option.Image = SpamReporter.Properties.Resources.deactive;
        }
    }
}
