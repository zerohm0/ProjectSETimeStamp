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
    public partial class Authentication : Form
    {
        private Service service;
        public Authentication()
        {
            service = new Service();
            InitializeComponent();
        }

        private void Authentication_Load(object sender, EventArgs e)
        {
            RunList();
        }
        public void RunList()
        {
            var ret = service.GetAuthen();
            if (ret.Status)
            {
                dataGridViewAuthen.DataSource = ret.ResultObj;
            }
            else
            {
                MessageBox.Show(ret.Message);
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            var ret = service.AuthenSearch(textBoxEmpSearch.Text);
            dataGridViewAuthen.DataSource = ret.ResultObj;
        }

        private void textBoxEmpSearch_Click(object sender, EventArgs e)
        {
            textBoxEmpSearch.Text = "";

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            //อันนี้ของEdit ของปุ่มในตาราง ไม่ใช่ปุ่ม +

            EditAuthen ARPC = new EditAuthen();
            var value = ARPC.ShowDialog();
            //AMC.labelStatus.Enabled = false;
            //AMC.labelStatus.Visible = false;
            if (value.ToString() == "OK")
            {
                RunList();

            }
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "test";
        }
    }
}
