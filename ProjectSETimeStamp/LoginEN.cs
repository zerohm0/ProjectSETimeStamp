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
using Model;
using ProjectDatabase;
using Container = Model.Container;

namespace ProjectSETimeStamp
{
    public partial class LoginEN : Form
    {
        private Service service;
        public LoginEN()
        {
            service = new Service();
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
        private void LoginEN_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
            Password_TB.UseSystemPasswordChar = true;
            Showpassword_CB.Text = "Show Password";

        }
        private void Submit_BT_Click(object sender, EventArgs e)
        {
            //String SQL_Query = "";
            //string con = "Data Source=$Local;Initial Catalog=$Database;User ID=$USer;Password=$Password";
            String Username = Username_TB.Text;
            String Password = Password_TB.Text;
            // Submit ผ่านไปหน้า form1
            MDI homeform = new MDI() ;
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
        private void Submit_BT_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void Username_TB_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {
            //assasasasaackadadoikadnadladadladiialdmadladjal
        }

        private void Username_LB_Click(object sender, EventArgs e)
        {
            MessageBox.Show("sdsdsd");
        }

        private void Username_TB_KeyPress_1(object sender, KeyPressEventArgs e)
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

        private void Password_TB_KeyPress_1(object sender, KeyPressEventArgs e)
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

        private void Submit_BT_Click_1(object sender, EventArgs e)
        {
            //String SQL_Query = "";
            //string con = "Data Source=$Local;Initial Catalog=$Database;User ID=$USer;Password=$Password";
            String Username = Username_TB.Text;
            String Password = Password_TB.Text;
            // Submit ผ่านไปหน้า form1
            MDI homeform = new MDI();
            if (Username == "js" && Password == "va")
            {
                homeform.Show();
                this.Hide();
            }
            else if (Username == "" && Password == "" )
            {
                MessageBox.Show("โปรดใส่ Username หรือ Password ");

            }
            else if (Username == "")
            {
                MessageBox.Show("โปรดใส่ Username");
            }
            else if (Password == "")
            {
                MessageBox.Show("โปรดใส่ Password");
            }
            else
            {
                MessageBox.Show("USERNAME หรือ PASSWORD ไม่ถูกต้อง", "Warning input is Fail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            var ret = service.Login(Username_TB.Text, Password_TB.Text);
        }

        private void Submit_BT_MouseMove(object sender, MouseEventArgs e)
        {
            Submit_BT.Cursor = Cursors.Hand;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void Username_TB_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void Check_Text_is_Emtry()
        {
            
        }

        private void Submit_BT_MouseHover_1(object sender, EventArgs e)
        {
            Submit_BT.BackColor = Color.DodgerBlue;
        }

        private void Showpassword_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (Showpassword_CB.Checked)
            {
                Password_TB.UseSystemPasswordChar = false;
                Showpassword_CB.Text = "Hide Password";
            }
            else
            {
                Password_TB.UseSystemPasswordChar = true;
                Showpassword_CB.Text = "Show Password";
            }
        }

        private void Submit_BT_MouseLeave(object sender, EventArgs e)
        {
            Submit_BT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(214)))));
        }

        private void CloseForm_BT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CloseForm_BT_MouseHover(object sender, EventArgs e)
        {
            CloseForm_BT.BackColor = Color.DodgerBlue;
        }

        private void CloseForm_BT_MouseLeave(object sender, EventArgs e)
        {
            CloseForm_BT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(214)))));
        }
    }
}
