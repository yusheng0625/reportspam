using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using System.Threading.Tasks;

namespace SpamReporter
{
    public partial class SpamReporterRibborn
    {
        private void SpamReporterRibborn_Load(object sender, RibbonUIEventArgs e)
        {
            GlobalVar.instance().m_ribbornBar = this;
            //GlobalVar.instance().m_addin.onStartAddin();
            //new Task(() => GlobalVar.instance().m_addin.onStartAddin()).Start();
        }

        private void btn_option_Click(object sender, RibbonControlEventArgs e)
        {
            GlobalVar global = GlobalVar.instance();
            if (global.m_bActivated && global.m_nSpamDetectCount>0)
            {
                global.m_addin.exploereSpamFolder();
                global.m_nSpamDetectCount = 0;
                global.updateRibbornBar();
            }
            else
            {
                FormOption frm = new FormOption();
                frm.ShowDialog();
            }
        }

    }
}
