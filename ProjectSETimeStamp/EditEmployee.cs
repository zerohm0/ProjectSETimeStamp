using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using ProjectDatabase;
using Container = Model.Container;


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
        //Code ข้างล่างคือของ Authen Edit เด๋วค่อยย้าย
        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            var filter = new Filter();
            filter.ID = comboBoxEmpID.Text;
            filter.Name = textBoxName.Text;
            filter.LName = textBoxLName.Text;
            filter.Department = comboBoxDepartment.Text;
            filter.Level = comboBoxPosition.Text;//ไม่ถูกต้องเพราะผิดform
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
            var ret = service.getList();
            if (ret.Status)
            {
                comboBoxEmpID.Items.AddRange(ret.ResultID.ToArray());
                comboBoxDepartment.Items.AddRange(ret.ResultObj.ToArray());
                comboBoxPosition.Items.AddRange(ret.ResultAnotherOneBiteTheDust.ToArray());
            }
            else
            {
                MessageBox.Show(ret.Message);
            }
        }
    }
}
