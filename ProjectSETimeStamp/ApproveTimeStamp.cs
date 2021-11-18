using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DGVPrinterHelper;

namespace ProjectSETimeStamp
{
    public partial class ApproveTimeStamp : Form
    {
        private Service service;

        public ApproveTimeStamp()
        {
            service = new Service();

            InitializeComponent();
        }

        private void ApproveTimeStamp_Load(object sender, EventArgs e)
        {
            Runlist();
        }
        public void Runlist()
        {
            var ret = service.GetAPTTimestamp();
            if (ret.Status)
            {
                dataGridView1.DataSource = ret.ResultObj;
            }
            else
            {
                MessageBox.Show(ret.Message);
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            var ret = service.StampSearch(textBox1.Text);
            dataGridView1.DataSource = ret.ResultObj;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void buttonOther_Click(object sender,EventArgs e)
        {
            string IDofrow = "";//นำข้อมูลมาจาก ID  ในตาราง
            var ret = service.StampSearch(IDofrow);
            if (ret.Status)
            {
                Timestamp ts = ret.ResultObj;
                var APA = new ApproveAccept();
                APA.TS_Global = ts;
                if (APA.ShowDialog() == DialogResult.OK)
                {
                    Runlist();
                }
            }
            
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "report";
        }
    }
}
