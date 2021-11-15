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
    public partial class MDIForm : Form
    {
        public MDIForm()
        {
            InitializeComponent();
        }

        private void ribbonButtonEmp_Click(object sender, EventArgs e)
        {
            foreach (Form f in MdiChildren)
            {
                if (f.GetType() == typeof(EmployeeForm))
                {
                    f.Activate();
                    f.WindowState = FormWindowState.Maximized;
                    return;
                }
            }
            Form form = new EmployeeForm
            {
                MdiParent = this
            };
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }

        private void ribbonButtonAuthen_Click(object sender, EventArgs e)
        {
            foreach (Form f in MdiChildren)
            {
                if (f.GetType() == typeof(Authentication))
                {
                    f.Activate();
                    f.WindowState = FormWindowState.Maximized;
                    return;
                }
            }
            Form form = new Authentication
            {
                MdiParent = this
            };
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }
    }
}
