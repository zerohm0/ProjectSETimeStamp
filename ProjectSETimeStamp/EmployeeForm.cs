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

            DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn();
            editButtonColumn.Name = "Edit";
            editButtonColumn.Text = "Edit";

            if (dataGridView.Columns["Edit"] == null)
            {
                dataGridView.Columns.Insert(0, editButtonColumn);
            }
            //dataGridViewAuthen.CellClick += dataGridViewAuthen_CellClick;
            this.dataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
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

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView.Columns["Edit"].Index)
            {

                string ID = dataGridView.Rows[e.RowIndex].Cells["รหัสพนักงาน"].Value.ToString();
                string Fnam = dataGridView.Rows[e.RowIndex].Cells["ชื่อ"].Value.ToString();
                string Lnam = dataGridView.Rows[e.RowIndex].Cells["นามสกุล"].Value.ToString();
                string Depart = dataGridView.Rows[e.RowIndex].Cells["แผนก"].Value.ToString();




                EditEmployee ARPC = new EditEmployee();
                ARPC.ID = ID;
                ARPC.textBoxName.Text = Fnam;
                ARPC.textBoxLName.Text = Lnam;
                ARPC.Depart = Depart;
                var value = ARPC.ShowDialog();

                //MessageBox.Show(value.ToString());
                if (value.ToString() == "OK")
                {
                    RunList();

                }


            }
        }

        private void dataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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
    }
}
