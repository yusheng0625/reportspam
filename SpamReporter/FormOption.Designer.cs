namespace SpamReporter
{
    partial class FormOption
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOption));
            this.btn_activate = new System.Windows.Forms.Button();
            this.line_top = new System.Windows.Forms.GroupBox();
            this.list_black = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.lbl_activation = new System.Windows.Forms.Label();
            this.list_domain = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_activate
            // 
            this.btn_activate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_activate.Location = new System.Drawing.Point(198, 11);
            this.btn_activate.Name = "btn_activate";
            this.btn_activate.Size = new System.Drawing.Size(76, 26);
            this.btn_activate.TabIndex = 0;
            this.btn_activate.Text = "Activate";
            this.btn_activate.UseVisualStyleBackColor = true;
            this.btn_activate.Click += new System.EventHandler(this.btn_activate_Click);
            // 
            // line_top
            // 
            this.line_top.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.line_top.Location = new System.Drawing.Point(11, 39);
            this.line_top.Name = "line_top";
            this.line_top.Size = new System.Drawing.Size(264, 8);
            this.line_top.TabIndex = 1;
            this.line_top.TabStop = false;
            // 
            // list_black
            // 
            this.list_black.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.list_black.FormattingEnabled = true;
            this.list_black.Location = new System.Drawing.Point(12, 76);
            this.list_black.Name = "list_black";
            this.list_black.Size = new System.Drawing.Size(129, 225);
            this.list_black.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Mail List";
            // 
            // btn_refresh
            // 
            this.btn_refresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_refresh.Location = new System.Drawing.Point(201, 307);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(75, 24);
            this.btn_refresh.TabIndex = 4;
            this.btn_refresh.Text = "Refresh";
            this.btn_refresh.UseVisualStyleBackColor = true;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // lbl_activation
            // 
            this.lbl_activation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_activation.AutoSize = true;
            this.lbl_activation.Location = new System.Drawing.Point(15, 17);
            this.lbl_activation.Name = "lbl_activation";
            this.lbl_activation.Size = new System.Drawing.Size(152, 13);
            this.lbl_activation.TabIndex = 5;
            this.lbl_activation.Text = "Activation will send mail to site.";
            // 
            // list_domain
            // 
            this.list_domain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.list_domain.FormattingEnabled = true;
            this.list_domain.Location = new System.Drawing.Point(147, 76);
            this.list_domain.Name = "list_domain";
            this.list_domain.Size = new System.Drawing.Size(129, 225);
            this.list_domain.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(150, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Domain List";
            // 
            // FormOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 337);
            this.Controls.Add(this.lbl_activation);
            this.Controls.Add(this.btn_refresh);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.list_domain);
            this.Controls.Add(this.list_black);
            this.Controls.Add(this.line_top);
            this.Controls.Add(this.btn_activate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormOption";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Spam Repoting Options";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_activate;
        private System.Windows.Forms.GroupBox line_top;
        private System.Windows.Forms.ListBox list_black;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_refresh;
        private System.Windows.Forms.Label lbl_activation;
        private System.Windows.Forms.ListBox list_domain;
        private System.Windows.Forms.Label label3;
    }
}