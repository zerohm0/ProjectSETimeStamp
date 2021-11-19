using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using OfficeOpenXml;
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
        Container GlobalC = new Container();
        private void Authentication_Load(object sender, EventArgs e)
        {
            RunList();

            DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn();
            editButtonColumn.Name = "Edit";
            editButtonColumn.Text = "Edit";
         
            if (dataGridViewAuthen.Columns["Edit"] == null )
            {
                dataGridViewAuthen.Columns.Insert(0, editButtonColumn);
            }
            //dataGridViewAuthen.CellClick += dataGridViewAuthen_CellClick;
            this.dataGridViewAuthen.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

        }
        public void RunList()
        {
            var ret = service.GetAuthen();
            if (ret.Status)
            {
                dataGridViewAuthen.DataSource = ret.ResultObj;
                GlobalC.ResultObj = ret.ResultObj;
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
            GlobalC.ResultObj = ret.ResultObj;
        }

        private void textBoxEmpSearch_Click(object sender, EventArgs e)
        {
            textBoxEmpSearch.Text = "";

        }

        

        

        

        


            private void dataGridViewAuthen_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.ColumnIndex == dataGridViewAuthen.Columns["Edit"].Index)
            {

                string ID = dataGridViewAuthen.Rows[e.RowIndex].Cells["รหัสพนักงาน"].Value.ToString();
                string Fnam  = dataGridViewAuthen.Rows[e.RowIndex].Cells["ชื่อ"].Value.ToString();
                string Lnam = dataGridViewAuthen.Rows[e.RowIndex].Cells["นามสกุล"].Value.ToString();
                string Authen = dataGridViewAuthen.Rows[e.RowIndex].Cells["สิทธิ์การใช้งาน"].Value.ToString();
                

               

                    EditAuthen ARPC = new EditAuthen();
                ARPC.ID = ID;
                ARPC.textBoxName.Text = Fnam;
                ARPC.textBoxLName.Text = Lnam;
                ARPC.Authen = Authen;
                    var value = ARPC.ShowDialog();

                    //MessageBox.Show(value.ToString());
                    if (value.ToString() == "OK")
                    {
                        RunList();

                    }
                

            }
        }

        private void dataGridViewAuthen_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (e.ColumnIndex == 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                Image someImage = Properties.Resources.application_edit;

                var w = Properties.Resources.application_edit.Width;
                var h = Properties.Resources.application_edit.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(someImage, new Rectangle(x, y, w, h));
                e.Handled = true;
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
            printer.PrintPreviewDataGridView(dataGridViewAuthen);


            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

            this.Show();
        }
    }
   
}
