
namespace ProjectSETimeStamp
{
    partial class MDIForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MDIForm));
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.ribbonTab1 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.ribbonButtonEmp = new System.Windows.Forms.RibbonButton();
            this.ribbonButtonAuthen = new System.Windows.Forms.RibbonButton();
            this.ribbonTab2 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel2 = new System.Windows.Forms.RibbonPanel();
            this.ribbonButton4 = new System.Windows.Forms.RibbonButton();
            this.ribbonTab3 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel3 = new System.Windows.Forms.RibbonPanel();
            this.ribbonButtonAsk = new System.Windows.Forms.RibbonButton();
            this.ribbonButtonApprove = new System.Windows.Forms.RibbonButton();
            this.ribbonTab4 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel4 = new System.Windows.Forms.RibbonPanel();
            this.ribbonButtonCheckStatus = new System.Windows.Forms.RibbonButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelEN = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelNAME = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelDEP = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelPOS = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbon1
            // 
            this.ribbon1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ribbon1.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.Margin = new System.Windows.Forms.Padding(4);
            this.ribbon1.Minimized = false;
            this.ribbon1.Name = "ribbon1";
            // 
            // 
            // 
            this.ribbon1.OrbDropDown.BorderRoundness = 8;
            this.ribbon1.OrbDropDown.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.OrbDropDown.Name = "";
            this.ribbon1.OrbDropDown.Size = new System.Drawing.Size(527, 447);
            this.ribbon1.OrbDropDown.TabIndex = 0;
            this.ribbon1.RibbonTabFont = new System.Drawing.Font("Trebuchet MS", 9F);
            this.ribbon1.Size = new System.Drawing.Size(1221, 196);
            this.ribbon1.TabIndex = 1;
            this.ribbon1.Tabs.Add(this.ribbonTab1);
            this.ribbon1.Tabs.Add(this.ribbonTab2);
            this.ribbon1.Tabs.Add(this.ribbonTab3);
            this.ribbon1.Tabs.Add(this.ribbonTab4);
            this.ribbon1.Text = "ribbon1";
            // 
            // ribbonTab1
            // 
            this.ribbonTab1.Name = "ribbonTab1";
            this.ribbonTab1.Panels.Add(this.ribbonPanel1);
            this.ribbonTab1.Text = "ผู้ใช้งาน";
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.Items.Add(this.ribbonButtonEmp);
            this.ribbonPanel1.Items.Add(this.ribbonButtonAuthen);
            this.ribbonPanel1.Name = "ribbonPanel1";
            this.ribbonPanel1.Text = " ";
            // 
            // ribbonButtonEmp
            // 
            this.ribbonButtonEmp.Image = global::ProjectSETimeStamp.Properties.Resources.Boss;
            this.ribbonButtonEmp.LargeImage = global::ProjectSETimeStamp.Properties.Resources.Boss;
            this.ribbonButtonEmp.Name = "ribbonButtonEmp";
            this.ribbonButtonEmp.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButtonEmp.SmallImage")));
            this.ribbonButtonEmp.Text = "ข้อมูลพนักงาน";
            this.ribbonButtonEmp.Click += new System.EventHandler(this.ribbonButtonEmp_Click);
            // 
            // ribbonButtonAuthen
            // 
            this.ribbonButtonAuthen.Image = global::ProjectSETimeStamp.Properties.Resources.People;
            this.ribbonButtonAuthen.LargeImage = global::ProjectSETimeStamp.Properties.Resources.People;
            this.ribbonButtonAuthen.Name = "ribbonButtonAuthen";
            this.ribbonButtonAuthen.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButtonAuthen.SmallImage")));
            this.ribbonButtonAuthen.Text = "สิทธิ์ผู้ใช้งาน";
            this.ribbonButtonAuthen.Click += new System.EventHandler(this.ribbonButtonAuthen_Click);
            // 
            // ribbonTab2
            // 
            this.ribbonTab2.Name = "ribbonTab2";
            this.ribbonTab2.Panels.Add(this.ribbonPanel2);
            this.ribbonTab2.Text = "ประเภทTimestamp";
            // 
            // ribbonPanel2
            // 
            this.ribbonPanel2.Items.Add(this.ribbonButton4);
            this.ribbonPanel2.Name = "ribbonPanel2";
            this.ribbonPanel2.Text = " ";
            // 
            // ribbonButton4
            // 
            this.ribbonButton4.Image = global::ProjectSETimeStamp.Properties.Resources.Alarm;
            this.ribbonButton4.LargeImage = global::ProjectSETimeStamp.Properties.Resources.Alarm;
            this.ribbonButton4.Name = "ribbonButton4";
            this.ribbonButton4.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton4.SmallImage")));
            this.ribbonButton4.Text = "ประเภทTimestamp";
            this.ribbonButton4.Click += new System.EventHandler(this.ribbonButton4_Click);
            // 
            // ribbonTab3
            // 
            this.ribbonTab3.Name = "ribbonTab3";
            this.ribbonTab3.Panels.Add(this.ribbonPanel3);
            this.ribbonTab3.Text = "ขอTimestamp";
            // 
            // ribbonPanel3
            // 
            this.ribbonPanel3.Items.Add(this.ribbonButtonAsk);
            this.ribbonPanel3.Items.Add(this.ribbonButtonApprove);
            this.ribbonPanel3.Name = "ribbonPanel3";
            this.ribbonPanel3.Text = "ribbonPanel3";
            // 
            // ribbonButtonAsk
            // 
            this.ribbonButtonAsk.Image = global::ProjectSETimeStamp.Properties.Resources.paste321;
            this.ribbonButtonAsk.LargeImage = global::ProjectSETimeStamp.Properties.Resources.paste321;
            this.ribbonButtonAsk.Name = "ribbonButtonAsk";
            this.ribbonButtonAsk.Text = "ขอTimestamp";
            this.ribbonButtonAsk.Click += new System.EventHandler(this.ribbonButtonAsk_Click);
            // 
            // ribbonButtonApprove
            // 
            this.ribbonButtonApprove.Image = global::ProjectSETimeStamp.Properties.Resources.prepare32;
            this.ribbonButtonApprove.LargeImage = global::ProjectSETimeStamp.Properties.Resources.prepare32;
            this.ribbonButtonApprove.Name = "ribbonButtonApprove";
            this.ribbonButtonApprove.Text = "อนุมัติTimestamp";
            this.ribbonButtonApprove.Click += new System.EventHandler(this.ribbonButtonApprove_Click);
            // 
            // ribbonTab4
            // 
            this.ribbonTab4.Name = "ribbonTab4";
            this.ribbonTab4.Panels.Add(this.ribbonPanel4);
            this.ribbonTab4.Text = "ตรวจสอบสถานะ";
            // 
            // ribbonPanel4
            // 
            this.ribbonPanel4.Items.Add(this.ribbonButtonCheckStatus);
            this.ribbonPanel4.Name = "ribbonPanel4";
            this.ribbonPanel4.Text = " ";
            // 
            // ribbonButtonCheckStatus
            // 
            this.ribbonButtonCheckStatus.Image = global::ProjectSETimeStamp.Properties.Resources.Find;
            this.ribbonButtonCheckStatus.LargeImage = global::ProjectSETimeStamp.Properties.Resources.Find;
            this.ribbonButtonCheckStatus.Name = "ribbonButtonCheckStatus";
            this.ribbonButtonCheckStatus.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButtonCheckStatus.SmallImage")));
            this.ribbonButtonCheckStatus.Text = "ตรวจสอบสถานะ";
            this.ribbonButtonCheckStatus.Click += new System.EventHandler(this.ribbonButtonCheckStatus_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelEN,
            this.toolStripStatusLabelNAME,
            this.toolStripStatusLabelDEP,
            this.toolStripStatusLabelPOS});
            this.statusStrip1.Location = new System.Drawing.Point(0, 656);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1221, 26);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelEN
            // 
            this.toolStripStatusLabelEN.Name = "toolStripStatusLabelEN";
            this.toolStripStatusLabelEN.Size = new System.Drawing.Size(82, 20);
            this.toolStripStatusLabelEN.Text = "รหัสพนักงาน";
            // 
            // toolStripStatusLabelNAME
            // 
            this.toolStripStatusLabelNAME.Name = "toolStripStatusLabelNAME";
            this.toolStripStatusLabelNAME.Size = new System.Drawing.Size(51, 20);
            this.toolStripStatusLabelNAME.Text = "ชื่อสกุล";
            // 
            // toolStripStatusLabelDEP
            // 
            this.toolStripStatusLabelDEP.Name = "toolStripStatusLabelDEP";
            this.toolStripStatusLabelDEP.Size = new System.Drawing.Size(43, 20);
            this.toolStripStatusLabelDEP.Text = "แผนก";
            // 
            // toolStripStatusLabelPOS
            // 
            this.toolStripStatusLabelPOS.Name = "toolStripStatusLabelPOS";
            this.toolStripStatusLabelPOS.Size = new System.Drawing.Size(56, 20);
            this.toolStripStatusLabelPOS.Text = "ตำแหน่ง";
            // 
            // MDIForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1221, 682);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.ribbon1);
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MDIForm";
            this.Text = "MDIForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MDIForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.RibbonTab ribbonTab1;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.RibbonButton ribbonButtonEmp;
        private System.Windows.Forms.RibbonButton ribbonButtonAuthen;
        private System.Windows.Forms.RibbonTab ribbonTab2;
        private System.Windows.Forms.RibbonPanel ribbonPanel2;
        private System.Windows.Forms.RibbonButton ribbonButton4;
        private System.Windows.Forms.RibbonTab ribbonTab3;
        private System.Windows.Forms.RibbonPanel ribbonPanel3;
        private System.Windows.Forms.RibbonButton ribbonButtonAsk;
        private System.Windows.Forms.RibbonButton ribbonButtonApprove;
        private System.Windows.Forms.RibbonTab ribbonTab4;
        private System.Windows.Forms.RibbonPanel ribbonPanel4;
        private System.Windows.Forms.RibbonButton ribbonButtonCheckStatus;
        private System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelEN;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelNAME;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelDEP;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelPOS;
    }
}