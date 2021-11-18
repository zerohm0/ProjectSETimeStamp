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
    public partial class EditAuthen : Form
    {
        private Service service;
        public EditAuthen()
        {

            service = new Service();
            InitializeComponent();
        }
        public string ID;
        public string Authen;
        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            var filter = new Filter();
            filter.ID = comboBoxEmpID.Text;
            filter.Name = textBoxName.Text;
            filter.LName = textBoxLName.Text;
            filter.Department = comboBoxDepart.Text;
            filter.Level = comboBoxPermissLev.Text;
            var container = new Container();
            container.Filter = filter;
            var ret = service.AuthenEdit(container);
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

        private void EditAuthen_Load(object sender, EventArgs e)
        {
           

            
            var ret = service.getList();
            if (ret.Status)
            {
                string[] s1 = ret.ResultID;
                string[] s2 = ret.ResultObj;
                string[] s3 = ret.ResultAnotherOneBiteTheDust;

                comboBoxEmpID.Items.AddRange(s1);
                comboBoxDepart.Items.AddRange(s2);
                comboBoxPermissLev.Items.AddRange(s3);
            }
            else
            {
                MessageBox.Show(ret.Message);
            }
            if (textBoxName.Text != null)
            {
                var ret2 = service.EmpSearch(comboBoxEmpID.Text);
                comboBoxDepart.Text = ret2.ExceptMessage;
                comboBoxEmpID.SelectedItem = ID;
                comboBoxPermissLev.SelectedItem = Authen;
            }
        }

        private void buttonAddPermiss_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
