using MySql.Data.MySqlClient;
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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            String con = "Server=localhost;Database=itp104;User=root;Password=;";
            MySqlConnection connection = new MySqlConnection(con);
            MySqlCommand command = connection.CreateCommand();
            command.Connection = connection;
            connection.Open();
            try
            {
                command.CommandText = "INSERT INTO users VALUES (" + Convert.ToInt32(txtUserId.Text) + " , '" + txtUsername.Text + "', '" + txtPassword.Text + "', '" + Convert.ToInt32(txtCredits.Text) + "')";
                command.ExecuteNonQuery();
                MessageBox.Show("Registration Successful!");
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
            Form2 form2 = new();
            this.Dispose();
            form2.Show();
        }

        private void checkPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkPassword.Checked == true)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }
    }
}
