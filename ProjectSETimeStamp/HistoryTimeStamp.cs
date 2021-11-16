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
    public partial class HistoryTimeStamp : Form
    {
        private Service service;
        public int Eid = 0;

        public HistoryTimeStamp()
        {
            service = new Service();

            InitializeComponent();
        }

        private void HistoryTimeStamp_Load(object sender, EventArgs e)
        {
            MDIForm mdi = new MDIForm();
            Eid = Convert.ToInt32(mdi.toolStripStatusLabelEN.Text);

            RunList();
        }
        public void RunList()
        {
            var ret = service.GetTimestampOfMine(Eid);
            if (ret.Status)
            {
                dataGridView1.DataSource = ret.ResultObj;
            }
            else
            {
                MessageBox.Show(ret.Message);
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            var ret = service.TimestampofMineSeaarch(textBox1.Text, Eid);
            dataGridView1.DataSource = ret.ResultObj;
        }
    }
}
