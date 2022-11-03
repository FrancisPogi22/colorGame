using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MidtermPoject
{
    public partial class Form2 : Form
    {
        public static Form2 instance;
        Boolean isFound = false;
        public Form2()
        {
            InitializeComponent();
            instance = this;
        }

        private void btnLoginUser_Click(object sender, EventArgs e)
        {
            string sentInfo = "";
            int userId = 0, userCredit = 0;
            string con = "Server=localhost;Database=itp104;User=root;Password=;";
            MySqlConnection connection = new(con);
            MySqlCommand cmd = new("SELECT * FROM users")
            {
                CommandType = CommandType.Text,
                Connection = connection
            };
            connection.Open();
            try
            {
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (dr["nickname"].ToString() == txtUsername.Text && dr["Password"].ToString() == txtPassword.Text)
                    {
                        sentInfo = dr["nickname"].ToString();
                        userId = (int)dr["id"];
                        userCredit = (int)dr["credits"];
                        isFound = true;
                    }
                }

                dr.Close();

            }
            catch (Exception z)
            {
                MessageBox.Show(z.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            if (isFound == true)
            {
                MessageBox.Show("Successfully Logged In, Maligayang pag bati ka kulay " + sentInfo.ToString().ToUpper() + "!");
                this.Hide();
                Form1.instance.username = Convert.ToString(sentInfo);
                Form1.instance.user.Text = sentInfo;
                Form1.instance.userId = Convert.ToInt32(userId.ToString());
                Form1.instance.result.Text = "GOOD LUCK " + sentInfo.ToUpper() + "!";
                Form1.instance.userCredits.Text = "CREDITS : " + userCredit.ToString();
                Form1.instance.auth.Text = "LOGOUT";
                Form1.instance.credits = userCredit;
                Form1 form1 = new();
            }

            else
            {
                MessageBox.Show("Incorrect Username or Password!", "Color Game", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegisterUser_Click(object sender, EventArgs e)
        {
            Form3 form3 = new();
            this.Hide();
            form3.Show();
        }

        private void checkPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkPassword.Checked == true) {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }
    }
}
