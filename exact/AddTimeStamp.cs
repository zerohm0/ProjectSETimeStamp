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
    public partial class AddTimeStamp : Form

    {
        private Service service;

        public AddTimeStamp()
        {
            service = new Service();

            InitializeComponent();
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {


            var ret = service.AddTimestampType(textBoxTpe.Text, textBoxDetail.Text);

            MessageBox.Show(ret.Message);
            if (ret.Status)
            {
                this.Close();
            }
        }
    }
}
