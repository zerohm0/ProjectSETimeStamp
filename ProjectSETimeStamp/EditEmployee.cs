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
    public partial class EditEmployee : Form
    {
        private Service service;

        public EditEmployee()
        {
            service = new Service();

            InitializeComponent();
        }
        public string ID;
        public string Depart;
        //Code ข้างล่างคือของ Authen Edit เด๋วค่อยย้าย
        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            var filter = new Filter();
            filter.ID = comboBoxEmpID.Text;
            filter.Name = textBoxName.Text;
            filter.LName = textBoxLName.Text;
            filter.Department = comboBoxDepartment.Text;
            filter.Level = comboBoxPosition.Text;
            var container = new Container();
            container.Filter = filter;
            var ret = service.EmployEdit(container);
            if (ret.Status)
            {
                MessageBox.Show(ret.Message);
                this.Close();
            }
            else
            {
                MessageBox.Show(ret.Message);
            }
        }

        private void EditEmployee_Load(object sender, EventArgs e)
        {
            var ret = service.getList2();
            if (ret.Status)
            {
                string[] s1 = ret.ResultID;
                string[] s2 = ret.ResultObj;
                string[] s3 = ret.ResultAnotherOneBiteTheDust;

                comboBoxEmpID.Items.AddRange(s1);
                comboBoxDepartment.Items.AddRange(s2);
                comboBoxPosition.Items.AddRange(s3);
            }
            else
            {
                MessageBox.Show(ret.Message);
            }
            if (textBoxName.Text != null)
            {
                var ret2 = service.EmpSearch(comboBoxEmpID.Text);
                comboBoxDepartment.Text = Depart;
                comboBoxEmpID.SelectedItem = ID;
                comboBoxPosition.SelectedItem = ret2.Message2;
            }


        }
    }
}
