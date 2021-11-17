
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
            this.ribbonButton3 = new System.Windows.Forms.RibbonButton();
            this.ribbonTab2 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel2 = new System.Windows.Forms.RibbonPanel();
            this.ribbonButton4 = new System.Windows.Forms.RibbonButton();
            this.ribbonTab3 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel3 = new System.Windows.Forms.RibbonPanel();
            this.ribbonButton5 = new System.Windows.Forms.RibbonButton();
            this.ribbonButton6 = new System.Windows.Forms.RibbonButton();
            this.ribbonTab4 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel4 = new System.Windows.Forms.RibbonPanel();
            this.ribbonButtonCheckStatus = new System.Windows.Forms.RibbonButton();
            this.ribbonTab5 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel5 = new System.Windows.Forms.RibbonPanel();
            this.ribbonButton8 = new System.Windows.Forms.RibbonButton();
            this.ribbonTab6 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel6 = new System.Windows.Forms.RibbonPanel();
            this.ribbonButton10 = new System.Windows.Forms.RibbonButton();
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
            this.ribbon1.Size = new System.Drawing.Size(916, 159);
            this.ribbon1.TabIndex = 1;
            this.ribbon1.Tabs.Add(this.ribbonTab1);
            this.ribbon1.Tabs.Add(this.ribbonTab2);
            this.ribbon1.Tabs.Add(this.ribbonTab3);
            this.ribbon1.Tabs.Add(this.ribbonTab4);
            this.ribbon1.Tabs.Add(this.ribbonTab5);
            this.ribbon1.Tabs.Add(this.ribbonTab6);
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
            this.ribbonPanel1.Items.Add(this.ribbonButton3);
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
            // ribbonButton3
            // 
            this.ribbonButton3.Image = global::ProjectSETimeStamp.Properties.Resources.User_group;
            this.ribbonButton3.LargeImage = global::ProjectSETimeStamp.Properties.Resources.User_group;
            this.ribbonButton3.Name = "ribbonButton3";
            this.ribbonButton3.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton3.SmallImage")));
            this.ribbonButton3.Text = "ระดับสิทธิ์";
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
            this.ribbonButton4.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton4.Image")));
            this.ribbonButton4.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton4.LargeImage")));
            this.ribbonButton4.Name = "ribbonButton4";
            this.ribbonButton4.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton4.SmallImage")));
            this.ribbonButton4.Text = "ประเภทTimestamp";
            // 
            // ribbonTab3
            // 
            this.ribbonTab3.Name = "ribbonTab3";
            this.ribbonTab3.Panels.Add(this.ribbonPanel3);
            this.ribbonTab3.Text = "ขอTimestamp";
            // 
            // ribbonPanel3
            // 
            this.ribbonPanel3.Items.Add(this.ribbonButton5);
            this.ribbonPanel3.Items.Add(this.ribbonButton6);
            this.ribbonPanel3.Name = "ribbonPanel3";
            this.ribbonPanel3.Text = "ribbonPanel3";
            // 
            // ribbonButton5
            // 
            this.ribbonButton5.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton5.Image")));
            this.ribbonButton5.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton5.LargeImage")));
            this.ribbonButton5.Name = "ribbonButton5";
            this.ribbonButton5.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton5.SmallImage")));
            this.ribbonButton5.Text = "ขอTimestamp";
            // 
            // ribbonButton6
            // 
            this.ribbonButton6.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton6.Image")));
            this.ribbonButton6.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton6.LargeImage")));
            this.ribbonButton6.Name = "ribbonButton6";
            this.ribbonButton6.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton6.SmallImage")));
            this.ribbonButton6.Text = "อนุมัติTimestamp";
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
            this.ribbonButtonCheckStatus.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButtonCheckStatus.Image")));
            this.ribbonButtonCheckStatus.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButtonCheckStatus.LargeImage")));
            this.ribbonButtonCheckStatus.Name = "ribbonButtonCheckStatus";
            this.ribbonButtonCheckStatus.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButtonCheckStatus.SmallImage")));
            this.ribbonButtonCheckStatus.Text = "ตรวจสอบสถานะ";
            this.ribbonButtonCheckStatus.Click += new System.EventHandler(this.ribbonButtonCheckStatus_Click);
            // 
            // ribbonTab5
            // 
            this.ribbonTab5.Name = "ribbonTab5";
            this.ribbonTab5.Panels.Add(this.ribbonPanel5);
            this.ribbonTab5.Text = "ประวัติ";
            // 
            // ribbonPanel5
            // 
            this.ribbonPanel5.Items.Add(this.ribbonButton8);
            this.ribbonPanel5.Name = "ribbonPanel5";
            this.ribbonPanel5.Text = " ";
            // 
            // ribbonButton8
            // 
            this.ribbonButton8.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton8.Image")));
            this.ribbonButton8.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton8.LargeImage")));
            this.ribbonButton8.Name = "ribbonButton8";
            this.ribbonButton8.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton8.SmallImage")));
            this.ribbonButton8.Text = "ประวัติ";
            // 
            // ribbonTab6
            // 
            this.ribbonTab6.Name = "ribbonTab6";
            this.ribbonTab6.Panels.Add(this.ribbonPanel6);
            this.ribbonTab6.Text = "รายงาน";
            // 
            // ribbonPanel6
            // 
            this.ribbonPanel6.Items.Add(this.ribbonButton10);
            this.ribbonPanel6.Name = "ribbonPanel6";
            this.ribbonPanel6.Text = " ";
            // 
            // ribbonButton10
            // 
            this.ribbonButton10.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton10.Image")));
            this.ribbonButton10.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton10.LargeImage")));
            this.ribbonButton10.Name = "ribbonButton10";
            this.ribbonButton10.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton10.SmallImage")));
            this.ribbonButton10.Text = "จัดทำรายงาน";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelEN,
            this.toolStripStatusLabelNAME,
            this.toolStripStatusLabelDEP,
            this.toolStripStatusLabelPOS});
            this.statusStrip1.Location = new System.Drawing.Point(0, 532);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(916, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelEN
            // 
            this.toolStripStatusLabelEN.Name = "toolStripStatusLabelEN";
            this.toolStripStatusLabelEN.Size = new System.Drawing.Size(64, 17);
            this.toolStripStatusLabelEN.Text = "รหัสพนักงาน";
            // 
            // toolStripStatusLabelNAME
            // 
            this.toolStripStatusLabelNAME.Name = "toolStripStatusLabelNAME";
            this.toolStripStatusLabelNAME.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabelNAME.Text = "ชื่อสกุล";
            // 
            // toolStripStatusLabelDEP
            // 
            this.toolStripStatusLabelDEP.Name = "toolStripStatusLabelDEP";
            this.toolStripStatusLabelDEP.Size = new System.Drawing.Size(34, 17);
            this.toolStripStatusLabelDEP.Text = "แผนก";
            // 
            // toolStripStatusLabelPOS
            // 
            this.toolStripStatusLabelPOS.Name = "toolStripStatusLabelPOS";
            this.toolStripStatusLabelPOS.Size = new System.Drawing.Size(44, 17);
            this.toolStripStatusLabelPOS.Text = "ตำแหน่ง";
            // 
            // MDIForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 554);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.ribbon1);
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.Name = "MDIForm";
            this.Text = "MDIForm";
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
        private System.Windows.Forms.RibbonButton ribbonButton3;
        private System.Windows.Forms.RibbonTab ribbonTab2;
        private System.Windows.Forms.RibbonPanel ribbonPanel2;
        private System.Windows.Forms.RibbonButton ribbonButton4;
        private System.Windows.Forms.RibbonTab ribbonTab3;
        private System.Windows.Forms.RibbonPanel ribbonPanel3;
        private System.Windows.Forms.RibbonButton ribbonButton5;
        private System.Windows.Forms.RibbonButton ribbonButton6;
        private System.Windows.Forms.RibbonTab ribbonTab4;
        private System.Windows.Forms.RibbonPanel ribbonPanel4;
        private System.Windows.Forms.RibbonButton ribbonButtonCheckStatus;
        private System.Windows.Forms.RibbonTab ribbonTab5;
        private System.Windows.Forms.RibbonPanel ribbonPanel5;
        private System.Windows.Forms.RibbonButton ribbonButton8;
        private System.Windows.Forms.RibbonTab ribbonTab6;
        private System.Windows.Forms.RibbonPanel ribbonPanel6;
        private System.Windows.Forms.RibbonButton ribbonButton10;
        private System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelEN;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelNAME;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelDEP;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelPOS;
    }
}