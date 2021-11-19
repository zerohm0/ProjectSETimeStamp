using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DGVPrinterHelper;

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
            //dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
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

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            //อันนี้ของEdit ของปุ่มในตาราง ไม่ใช่ปุ่ม +
            EditEmployee ARPC = new EditEmployee();
            var value = ARPC.ShowDialog();
           
            if (value.ToString() == "OK")
            {
                RunList();

            }
        }

        private void textBoxSearch_Click(object sender, EventArgs e)
        {
            textBoxSearch.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //dataGridView.AutoSizeColumnsMode =DataGridViewAutoSizeColumnsMode.None;
            //dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            //dataGridView.AutoResizeColumns();
            DGVPrinter printer = new DGVPrinter();



            printer.Title = "รายงานพนักงาน";
            printer.SubTitle = string.Format("วันที่: {0}", DateTime.Now.Date.ToShortDateString());
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true; 
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.printDocument.DefaultPageSettings.Landscape = true;

            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Hide();
            printer.PrintPreviewDataGridView(dataGridView);
            

            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            
            this.Show();
            


        }
    }
}
