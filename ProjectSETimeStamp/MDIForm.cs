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
        private Service service;

        public MDIForm()
        {
            service = new Service();

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

        private void ribbonButtonCheckStatus_Click(object sender, EventArgs e)
        {
            foreach (Form f in MdiChildren)
            {
                if (f.GetType() == typeof(VeriStatus))
                {
                    f.Activate();
                    f.WindowState = FormWindowState.Maximized;
                    
                    return;
                }
            }
            Form form = new VeriStatus
            {
                MdiParent = this
               
            };
            form.Text = toolStripStatusLabelEN.Text;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }

        private void MDIForm_Load(object sender, EventArgs e)
        {
            LoginEN log = new LoginEN();
            var value = log.ShowDialog();
            var filter = new Filter();
            filter.ID = log.Username_TB.Text;
            var container = new Container();

            container.Filter = filter;
            if (value.ToString() == "OK" && log.globalresult)
            {
                var ret = service.getOneManLogin(container);

                toolStripStatusLabelDEP.Text = filter.Department;
                toolStripStatusLabelEN.Text= log.Username_TB.Text;
                toolStripStatusLabelNAME.Text= ret.Message;
                toolStripStatusLabelPOS.Text= filter.Detial;

                foreach (Form f in MdiChildren)
                {
                    if (f.GetType() == typeof(Form1))
                    {
                        f.Activate();
                        f.WindowState = FormWindowState.Maximized;

                        return;
                    }
                }
                Form form = new Form1
                {
                    MdiParent = this
                };

                form.WindowState = FormWindowState.Maximized;
                form.Show();
            }
            else
            {
                log.ShowDialog();
            }
        }

        private void ribbonTab2_ActiveChanged(object sender, EventArgs e)
        {

        }

        private void ribbonButton4_Click(object sender, EventArgs e)
        {
            foreach (Form f in MdiChildren)
            {
                if (f.GetType() == typeof(TypeTimeStamp))
                {
                    f.Activate();
                    f.WindowState = FormWindowState.Maximized;
                    return;
                }
            }
            Form form = new TypeTimeStamp
            {
                MdiParent = this
            };
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }

        private void ribbonButtonAsk_Click(object sender, EventArgs e)
        {
            foreach (Form f in MdiChildren)
            {
                if (f.GetType() == typeof(AskTimeStamp))
                {
                    f.Activate();
                    f.WindowState = FormWindowState.Maximized;
                    return;
                }
            }
            Form form = new AskTimeStamp
            {
                MdiParent = this
            };
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }

        private void ribbonButtonApprove_Click(object sender, EventArgs e)
        {
            foreach (Form f in MdiChildren)
            {
                if (f.GetType() == typeof(ApproveTimeStamp))
                {
                    f.Activate();
                    f.WindowState = FormWindowState.Maximized;
                    return;
                }
            }
            Form form = new ApproveTimeStamp
            {
                MdiParent = this
            };
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }

        private void ribbonTab4_ActiveChanged(object sender, EventArgs e)
        {

        }
    }
}
