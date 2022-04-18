using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
using System.Windows.Forms;

namespace SpamReporter
{
    class SpamChecker
    {
        public bool isSpam(Outlook.MailItem mail, out string reason)
        {
            reason = "black_mail";
            GlobalVar global = GlobalVar.instance();
            if (mail == null) return false;

            if(mail.SenderEmailAddress==null) return false;
            if (global.m_filters.isBlackDomain(mail.SenderEmailAddress))
            {
                reason = "black_domain";
                return true;
            }
            if (global.m_filters.isBlackMail(mail.SenderEmailAddress))
                return true;

            return false;
        }

    }
}
