namespace SpamReporter
{
    partial class SpamReporterRibborn : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public SpamReporterRibborn()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
            GlobalVar.instance().m_ribbornBar = this;
            GlobalVar.instance().updateRibbornBar();
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tab1 = this.Factory.CreateRibbonTab();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.btn_option = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.group1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.ControlId.OfficeId = "TabMail";
            this.tab1.Groups.Add(this.group1);
            this.tab1.Label = "TabMail";
            this.tab1.Name = "tab1";
            // 
            // group1
            // 
            this.group1.Items.Add(this.btn_option);
            this.group1.Label = "Spam Report";
            this.group1.Name = "group1";
            // 
            // btn_option
            // 
            this.btn_option.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btn_option.Image = global::SpamReporter.Properties.Resources.deactive;
            this.btn_option.Label = "Option";
            this.btn_option.Name = "btn_option";
            this.btn_option.ShowImage = true;
            this.btn_option.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btn_option_Click);
            // 
            // SpamReporterRibborn
            // 
            this.Name = "SpamReporterRibborn";
            this.RibbonType = "Microsoft.Outlook.Explorer";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.SpamReporterRibborn_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btn_option;
    }

    partial class ThisRibbonCollection
    {
        internal SpamReporterRibborn SpamReporterRibborn
        {
            get { return this.GetRibbon<SpamReporterRibborn>(); }
        }
    }
}
