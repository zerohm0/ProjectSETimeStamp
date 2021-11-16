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
    }
}
