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
    public partial class TypeTimeStamp : Form
    {
        private Service service;

        public TypeTimeStamp()
        {
            service = new Service();
            InitializeComponent();
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            textBoxSearch.Text = "";
        }

        private void TypeTimeStamp_Load(object sender, EventArgs e)
        {
            RunList();

        }
        public void RunList()
        {
            var ret = service.GetTimesType();
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
            var ret = service.TimestampTypeSearch(textBoxSearch.Text);
            dataGridView.DataSource = ret.ResultObj;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddTimeStamp ARPC = new AddTimeStamp();
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



            printer.Title = "รายงานประเภท Time Stamp";
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
