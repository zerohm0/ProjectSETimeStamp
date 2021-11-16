using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace ProjectSETimeStamp
{
    public partial class AskTimeStamp : Form
    {
        private Service service;
        public AskTimeStamp()
        {
            service = new Service();

            InitializeComponent();
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            //DateTime DateIn = dateTimePickerS.Value;
            //DateTime DateOut = dateTimePickerE.Value;
            var filter = new Filter();
            DateTime TimeIN = DateTime.ParseExact(textBoxIn.Text, "HH:mm",
                                        CultureInfo.InvariantCulture);
            DateTime TimeOut = DateTime.ParseExact(textBoxOut.Text, "HH:mm", CultureInfo.InvariantCulture);

            filter.ID = labelEmpID.Text;
            filter.dtF = dateTimePickerS.Value;
            filter.dtL = dateTimePickerE.Value;
            filter.Detial = textBoxDetail.Text;
            filter.Type = comboBoxType.Text;
            filter.Name = labelName.Text;
            filter.LName = labelLastName.Text;
            filter.TimeIn = TimeIN;
            filter.TimeOut = TimeOut;


            var container = new Container();
            container.Filter = filter;
            var ret = service.AskTimestamp(container);
            if (ret.Status)
            {
                MessageBox.Show(ret.Message);
            }
            else
            {
                MessageBox.Show(ret.Message);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            comboBoxType.Text = "";
            textBoxDetail.Text = "";
            textBoxFile.Text = "";
            textBoxIn.Text = "";
            textBoxOut.Text = "";
        }
    }
}
