using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            EditEmployee ARPC = new EditEmployee();
            var value = ARPC.ShowDialog();
            //AMC.labelStatus.Enabled = false;
            //AMC.labelStatus.Visible = false;
            if (value.ToString() == "OK")
            {
                RunList();

            }
        }
    }
}
