using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using DGVPrinterHelper;

namespace ProjectSETimeStamp
{
    public partial class HRMHoliday : Form
    {
        private Service service;

        public HRMHoliday()
        {
            service = new Service();

            InitializeComponent();
        }

        private void HRMHoliday_Load(object sender, EventArgs e)
        {

        }
        public void RunList()
        {
            var ret = service.GetHoliday();
            if (ret.Status)
            {
                dataGridView1.DataSource = ret.ResultObj;
            }
            else
            {
                MessageBox.Show(ret.Message);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string Description =Interaction.InputBox("please add details",
                       "Description",
                       " ",
                       0,
                       0);
            var mdi = new MDIForm();
            var filter = new Filter();
            filter.dtF = dateTimePicker1.Value;
            filter.ID = mdi.toolStripStatusLabelEN.Text;
            filter.dtK = DateTime.Today;
            filter.Detial = Description;
            filter.Department = comboBox1.Text;
            var container = new Container();
            container.Filter = filter;
            var ret = service.AddHoliday(container);
            if (ret.Status)
            {
                MessageBox.Show(ret.Message);
            }
            else
            {
                MessageBox.Show(ret.Message);

            }
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();



            printer.Title = "รายงานสิทธิ์การใช้งานระบบ";
            printer.SubTitle = string.Format("วันที่: {0}", DateTime.Now.Date.ToShortDateString());
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.printDocument.DefaultPageSettings.Landscape = true;

            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Hide();
            printer.PrintPreviewDataGridView(dataGridView1);


            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

            this.Show();
        }
    }
}
