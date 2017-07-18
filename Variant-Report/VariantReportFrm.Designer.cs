namespace Variant_Report
{
    partial class VariantReportFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VariantReportFrm));
            this.label1 = new System.Windows.Forms.Label();
            this.tbFileName = new System.Windows.Forms.TextBox();
            this.btnReport = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.bwGenReport = new System.ComponentModel.BackgroundWorker();
            this.btnSaveReport = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select File:";
            // 
            // tbFileName
            // 
            this.tbFileName.Location = new System.Drawing.Point(90, 21);
            this.tbFileName.Name = "tbFileName";
            this.tbFileName.ReadOnly = true;
            this.tbFileName.Size = new System.Drawing.Size(316, 20);
            this.tbFileName.TabIndex = 1;
            // 
            // btnReport
            // 
            this.btnReport.Enabled = false;
            this.btnReport.Location = new System.Drawing.Point(294, 65);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(150, 44);
            this.btnReport.TabIndex = 3;
            this.btnReport.Text = "Generate Report";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel1.LinkColor = System.Drawing.Color.Gray;
            this.linkLabel1.Location = new System.Drawing.Point(400, 170);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(44, 13);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "y-str.org";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLbl});
            this.statusStrip1.Location = new System.Drawing.Point(0, 202);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(464, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLbl
            // 
            this.statusLbl.Name = "statusLbl";
            this.statusLbl.Size = new System.Drawing.Size(38, 17);
            this.statusLbl.Text = "Done.";
            // 
            // bwGenReport
            // 
            this.bwGenReport.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwGenReport_DoWork);
            this.bwGenReport.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwGenReport_RunWorkerCompleted);
            // 
            // btnSaveReport
            // 
            this.btnSaveReport.Enabled = false;
            this.btnSaveReport.Location = new System.Drawing.Point(294, 115);
            this.btnSaveReport.Name = "btnSaveReport";
            this.btnSaveReport.Size = new System.Drawing.Size(150, 44);
            this.btnSaveReport.TabIndex = 6;
            this.btnSaveReport.Text = "Save Report";
            this.btnSaveReport.UseVisualStyleBackColor = true;
            this.btnSaveReport.Click += new System.EventHandler(this.btnSaveReport_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(412, 16);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(31, 28);
            this.btnBrowse.TabIndex = 7;
            this.btnBrowse.Text = "..";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // VariantReportFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 224);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.btnSaveReport);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.tbFileName);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VariantReportFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Variant Report";
            this.Load += new System.EventHandler(this.VariantReportFrm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFileName;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLbl;
        private System.ComponentModel.BackgroundWorker bwGenReport;
        private System.Windows.Forms.Button btnSaveReport;
        private System.Windows.Forms.Button btnBrowse;
    }
}

