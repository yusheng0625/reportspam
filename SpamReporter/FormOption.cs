using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpamReporter
{
    public partial class FormOption : Form
    {
        public FormOption()
        {
            InitializeComponent();
            GlobalVar global = GlobalVar.instance();
            if (global.m_bActivated)
                this.Icon = Properties.Resources.icon_on;
            else
                this.Icon = Properties.Resources.icon_off;

            reSizeForm();
            fillBlackList();
            fillDomainList();
        }
        void reSizeForm()
        {
            GlobalVar global = GlobalVar.instance();
            if (global.m_bActivated == false) return;

            int t_gap = line_top.Top;
            line_top.Visible = false;
            lbl_activation.Visible = false;
            btn_activate.Visible = false;
            this.Height -= t_gap;
        }


        void fillBlackList()
        {
            list_black.Items.Clear();
            GlobalVar global = GlobalVar.instance();
            foreach(string strBlack in global.m_filters.m_blackMailList)
            {
                list_black.Items.Add(strBlack);
            }            
        }

        void fillDomainList()
        {
            list_domain.Items.Clear();
            GlobalVar global = GlobalVar.instance();
            foreach (string strBlack in global.m_filters.m_blackDomainList)
            {
                list_domain.Items.Add(strBlack);
            }
        }


        private void btn_activate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Activate the Spam Report?", "Activation", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return;

            GlobalVar global = GlobalVar.instance();
            global.m_addin.sendActivationMail();
            global.setActivated();
            Close();
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            GlobalVar global = GlobalVar.instance();
            global.m_filters.clear();
            fillBlackList();
            fillDomainList();

            global.getBlackListFromServer(false);
            //new Task(()=> global.getBlackListFromServer(false)).Start();
            //Close();

            fillBlackList();
            fillDomainList();
        }
    }
}
