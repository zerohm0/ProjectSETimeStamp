using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ProjectSETimeStamp
{
    public partial class LoginEN : Form
    {
        public LoginEN()
        {
            InitializeComponent();
            
        }
        //Connect SQL Server
        //string con = "Data Source =.;Initial Catalog = shop;User ID = sa;Password = 123456;";
        //"Data Source=$Local;Initial Catalog=$Database;User ID=$USer;Password=$Password"
        /*private string ConnectAndQuery(String ConnectSQL,String QuerySQL)
        {
            //String connectionstring = null;
            DataTable SQLQuery_DT = new DataTable();
            SqlConnection cnn;
            cnn = new SqlConnection(ConnectSQL);
            SqlCommand cmd = new SqlCommand(QuerySQL, cnn);
            try
            {
                cnn.Open();
                MessageBox.Show("สามารถConnectDatabase ได้");
                SqlDataAdapter Send_SQL_to_DB = new SqlDataAdapter(cmd);
                Send_SQL_to_DB.Fill(SQLQuery_DT);
                cnn.Close();
                Send_SQL_to_DB.Dispose();
            }
            catch
            {
                MessageBox.Show("ไม่สามารถเข้าถึง Database ได้");
            }
            return  ;
        }
       */
        private void Submit_BT_Click(object sender, EventArgs e)
        {
            //String SQL_Query = "";
            //string con = "Data Source=$Local;Initial Catalog=$Database;User ID=$USer;Password=$Password";
            String Username = Username_TB.Text;
            String Password = Password_TB.Text;
            // Submit ผ่านไปหน้า form1
            Form1 homeform = new Form1() ;
            if (Username == "js" && Password == "va")
            {
                homeform.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("USERNAME หรือ PASSWORD ไม่ถูกต้อง","Warning input is Fail",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }

        }

        private void Username_TB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar >= 65 && (int)e.KeyChar <= 122) || ((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57) || (int)e.KeyChar == 8 || (int)e.KeyChar == 13 || (int)e.KeyChar == 46)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                
                //MessageBox.Show("กรุณาระบุข้อมุลตัวอังกฤษ", "Username ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Password_TB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar >= 65 && (int)e.KeyChar <= 122) || ((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57) || (int)e.KeyChar == 8 || (int)e.KeyChar == 13 || (int)e.KeyChar == 46)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;

                //MessageBox.Show("กรุณาระบุข้อมุลตัวอังกฤษ", "Username ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
