using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DGVPrinterHelper;

namespace ProjectSETimeStamp
{
    public partial class ApproveAccept : Form
    {
        private Service service;
        public ApproveAccept()
        {
            service = new Service();
            InitializeComponent();
        }
        public Timestamp TS_Global;
        public string valueRadio;
        private void ApproveAccept_Load(object sender, EventArgs e)
        {
            //labelName.Text = TS_Global.Employee.EmpFName + "  " + TS_Global.Employee.EmpLName;
            //labelEN.Text = TS_Global.EmpID.ToString();
            //labelDepart.Text = TS_Global.Employee.EmpDepart;
            //labelType.Text = TS_Global.TypeID.ToString();//อันนี้ต้องเป็น Type ที่เป็น value ไม่ใช่ ID
            //labelDetail.Text = TS_Global.TimestampDes;
            /*labelDateS.Text = TS_Global.TimestampFDay;
            labelDateEnd.Text = TS_Global.TimestampLDay;
            //labelTimeIN.Text = TS_Global.TimestampIn;
            //labelTimeOUT.Text = TS_Global.TimestampOut;*/



        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ret = service.TimestampUpdateStatus(Convert.ToInt32(TS_Global.EmpID), valueRadio);
            MessageBox.Show(ret.Message);
            this.Close();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                valueRadio = radioButton2.Text;
            }
            if (radioButton4.Checked == true)
            {
                valueRadio = radioButton4.Text;
            }
            /*if (radioButton6.Checked == true)
            {
                valueRadio = radioButton6.Text;
            }*/

        }

       
    }
}
