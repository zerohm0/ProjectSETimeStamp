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
    public partial class EmployeeForm : Form
    {
        private Service service;
        public EmployeeForm()
        {
            service = new Service();
            InitializeComponent();
        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            RunList();
        }
        public void RunList()
        {
            var ret = service.GetEmp();
            if (ret.Status)
            {
                dataGridView.DataSource = ret.ResultObj;
            }
            else
            {
                MessageBox.Show(ret.Message);
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {

            var ret = service.EmpSearch(textBoxSearch.Text);
            dataGridView.DataSource = ret.ResultObj;
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            textBoxSearch.Text = "";

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            //อันนี้ของEdit ของปุ่มในตาราง ไม่ใช่ปุ่ม +
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
