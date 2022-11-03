using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;

namespace MidtermPoject
{
    public partial class Form1 : Form
    {
        private string connectToDatabase = "Server=localhost;Database=itp104;User=root;Password=;";
        private Color Pink = Color.Fuchsia, Blue = Color.Blue, Green = Color.FromArgb(0, 192, 0), Yellow = Color.Yellow, White = Color.White, Red = Color.Red;
        private Random colorRandom = new();
        public string userChoice = "", username = "";
        public int credits = 0, userBet = 0, userId = 0;
        public Label result, userCredits, user;
        public Button auth;
        public static Form1 instance;

        public Form1()
        {
            InitializeComponent();
            instance = this;
            auth = btnLogin;
            user = lblUsername;
            userCredits = lblCredits;
            result = lblResult;
        }

        private void btnAddCredits_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new(connectToDatabase);
            connection.Open();
            string Query = "UPDATE users SET credits = credits + " + 1000 + " WHERE id = " + userId;
            MySqlCommand cmd = new(Query, connection);
            cmd.ExecuteNonQuery();
            credits += 1000;
            MessageBox.Show("Successfully Added Credits!");
            lblCredits.Text = "CREDITS : " + credits.ToString();
        }

        private void btnBlue_Click(object sender, EventArgs e)
        {
            
            if (credits == 0)
            {
                MessageBox.Show("CLICK THE PLUS BUTTON BELOW TO ADD CREDITS! ", "Color Game", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MySqlConnection connection = new(connectToDatabase);
                connection.Open();
                string Query = "UPDATE users SET credits = credits - " + 50 + " WHERE id = " + userId;
                MySqlCommand cmd = new(Query, connection);
                cmd.ExecuteNonQuery();
                credits -= 50;
                userBet += 50;
                userChoice = "Blue";
                lblCredits.Text = "CREDITS : " + credits.ToString();
                lblUserColor.BackColor = Blue;
            }
            
        }

        private void btnWhite_Click(object sender, EventArgs e)
        {
            if (credits == 0)
            {
                MessageBox.Show("CLICK THE PLUS BUTTON BELOW TO ADD CREDITS! ", "Color Game", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MySqlConnection connection = new(connectToDatabase);
                connection.Open();
                string Query = "UPDATE users SET credits = credits - " + 50 + " WHERE id = " + userId;
                MySqlCommand cmd = new(Query, connection);
                cmd.ExecuteNonQuery();
                credits -= 50;
                userBet += 50;
                userChoice = "White";
                lblCredits.Text = "CREDITS : " + credits.ToString();
                lblUserColor.BackColor = White;
            }
        }

        private void btnGreen_Click(object sender, EventArgs e)
        {
            if (credits == 0)
            {
                 MessageBox.Show("CLICK THE PLUS BUTTON BELOW TO ADD CREDITS! ", "Color Game", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MySqlConnection connection = new(connectToDatabase);
                connection.Open();
                string Query = "UPDATE users SET credits = credits - " + 50 + " WHERE id = " + userId;
                MySqlCommand cmd = new(Query, connection);
                cmd.ExecuteNonQuery();
                credits -= 50;
                userBet += 50;
                userChoice = "Green";
                lblCredits.Text = "CREDITS : " + credits.ToString();
                lblUserColor.BackColor = Green;
            }
        }

        private void btnPink_Click(object sender, EventArgs e)
        {
            if (credits == 0)
            {
                MessageBox.Show("CLICK THE PLUS BUTTON BELOW TO ADD CREDITS! ", "Color Game", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MySqlConnection connection = new(connectToDatabase);
                connection.Open();
                string Query = "UPDATE users SET credits = credits - " + 50 + " WHERE id = " + userId;
                MySqlCommand cmd = new(Query, connection);
                cmd.ExecuteNonQuery();
                credits -= 50;
                userBet += 50;
                userChoice = "Pink";
                lblCredits.Text = "CREDITS : " + credits.ToString();
                lblUserColor.BackColor = Pink;
            }
        }

        private void btnRed_Click(object sender, EventArgs e)
        {
            if (credits == 0)
            {
                MessageBox.Show("CLICK THE PLUS BUTTON BELOW TO ADD CREDITS! ", "Color Game", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MySqlConnection connection = new(connectToDatabase);
                connection.Open();
                string Query = "UPDATE users SET credits = credits - " + 50 + " WHERE id = " + userId;
                MySqlCommand cmd = new(Query, connection);
                cmd.ExecuteNonQuery();
                credits -= 50;
                userBet += 50;
                userChoice = "Red";
                lblCredits.Text = "CREDITS : " + credits.ToString();
                lblUserColor.BackColor = Red;
            }
        }

        private void btnYellow_Click(object sender, EventArgs e)
        {
            if (credits == 0)
            {
                MessageBox.Show("CLICK THE PLUS BUTTON BELOW TO ADD CREDITS! ", "Color Game", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MySqlConnection connection = new(connectToDatabase);
                connection.Open();
                string Query = "UPDATE users SET credits = credits - " + 50 + " WHERE id = " + userId;
                MySqlCommand cmd = new(Query, connection);
                cmd.ExecuteNonQuery();
                credits -= 50;
                userBet += 50;
                userChoice = "Yellow";
                lblCredits.Text = "CREDITS : " + credits.ToString();
                lblUserColor.BackColor = Yellow;
            }  
        }

        private void btnDrawColor_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new(connectToDatabase);
            int colorCode = colorRandom.Next(6);

            if (colorCode == 0)
            {
                if (userChoice == "Pink")
                {
                    userBet *= 2;
                    credits += userBet;
                    connection.Open();
                    string Query = "UPDATE users SET credits = credits + " + userBet + " WHERE id = " + userId;
                    MySqlCommand cmd = new(Query, connection);
                    cmd.ExecuteNonQuery();
                    userBet = 0;
                    lblCredits.Text = "CREDITS : " + credits.ToString();
                    lblGameResult.Text = "WINNER!";
                    lblGameResult.ForeColor = White;
                }
                else
                {
                    userBet = 0;
                    lblGameResult.Text = "LOSER!";
                    lblGameResult.ForeColor = Red;
                    lblUserColor.BackColor = Color.Transparent;
                }
                lblColorResult.BackColor = Pink;
                lblResult.Text = "Color Pink Wins!";
                lblColorResult.Text = "PINK!";
                userChoice = "";
            }
            else if (colorCode == 1)
            {
                if (userChoice == "Blue")
                {
                    userBet *= 2;
                    credits += userBet;
                    connection.Open();
                    string Query = "UPDATE users SET credits = credits + " + userBet + " WHERE id = " + userId;
                    MySqlCommand cmd = new(Query, connection);
                    cmd.ExecuteNonQuery();
                    userBet = 0;
                    lblCredits.Text = "CREDITS : " + credits.ToString();
                    lblGameResult.Text = "WINNER!";
                    lblGameResult.ForeColor = White;
                }
                else
                {
                    userBet = 0;
                    lblGameResult.Text = "LOSER!";
                    lblGameResult.ForeColor = Red;
                    lblUserColor.BackColor = Color.Transparent;
                }
                lblColorResult.BackColor = Blue;
                lblResult.Text = "Color Blue Wins!";
                lblColorResult.Text = "BLUE!";
                userChoice = "";

            }
            else if (colorCode == 2)
            {
                if (userChoice == "Green")
                {
                    userBet *= 2;
                    credits += userBet;
                    connection.Open();
                    string Query = "UPDATE users SET credits = credits + " + userBet + " WHERE id = " + userId;
                    MySqlCommand cmd = new(Query, connection);
                    cmd.ExecuteNonQuery();
                    userBet = 0;
                    lblCredits.Text = "CREDITS : " + credits.ToString();
                    lblGameResult.Text = "WINNER!";
                    lblGameResult.BackColor = White;
                }
                else
                {
                    userBet = 0;
                    lblGameResult.Text = "LOSER!";
                    lblGameResult.ForeColor = Red;
                    lblUserColor.BackColor = Color.Transparent;
                }

                lblColorResult.BackColor = Green;
                lblResult.Text = "Color Green Wins!";
                lblColorResult.Text = "GREEN!";
                userChoice = "";
            }
            else if (colorCode == 3)
            {
                if (userChoice == "Yellow")
                {
                    userBet *= 2;
                    credits += userBet;
                    connection.Open();
                    string Query = "UPDATE users SET credits = credits + " + userBet + " WHERE id = " + userId;
                    MySqlCommand cmd = new(Query, connection);
                    cmd.ExecuteNonQuery();
                    userBet = 0;
                    lblCredits.Text = "CREDITS : " + credits.ToString();
                    lblGameResult.Text = "WINNER!";
                    lblGameResult.ForeColor = White;
                }
                else
                {
                    userBet = 0;
                    lblGameResult.Text = "LOSER!";
                    lblGameResult.ForeColor = Red;
                    lblUserColor.BackColor = Color.Transparent;
                }
                lblColorResult.BackColor = Yellow;
                lblResult.Text = "Color Yellow Wins!";
                lblColorResult.Text = "YELLOW!";
                userChoice = "";
            }
            else if (colorCode == 4)
            {
                if (userChoice == "White")
                {
                    userBet *= 2;
                    credits += userBet;
                    connection.Open();
                    string Query = "UPDATE users SET credits = credits + " + userBet + " WHERE id = " + userId;
                    MySqlCommand cmd = new(Query, connection);
                    cmd.ExecuteNonQuery();
                    userBet = 0;
                    lblCredits.Text = "CREDITS : " + credits.ToString();
                    lblGameResult.Text = "WINNER!";
                    lblGameResult.ForeColor = White;
                }
                else
                {
                    userBet = 0;
                    lblGameResult.Text = "LOSER!";
                    lblGameResult.ForeColor = Red;
                    lblUserColor.BackColor = Color.Transparent;
                }
                lblColorResult.BackColor = White;
                lblResult.Text = "Color White Wins!";
                lblColorResult.Text = "WHITE!";
                userChoice = "";
            }
            else if (colorCode == 5)
            {
                if (userChoice == "Red")
                {
                    userBet *= 2;
                    credits += userBet;
                    connection.Open();
                    string Query = "UPDATE users SET credits = credits + " + userBet + " WHERE id = " + userId;
                    MySqlCommand cmd = new(Query, connection);
                    cmd.ExecuteNonQuery();
                    userBet = 0;
                    lblCredits.Text = "CREDITS : " + credits.ToString();
                    lblGameResult.Text = "WINNER!";
                    lblGameResult.ForeColor = White;
                }
                else
                {
                    userBet = 0;
                    lblGameResult.Text = "LOSER!";
                    lblGameResult.ForeColor = Red;
                    lblUserColor.BackColor = Color.Transparent;
                }
                lblColorResult.BackColor = Red;
                lblResult.Text = "Color Red Wins!";
                lblColorResult.Text = "RED!";
                userChoice = "";
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (btnLogin.Text == "LOGIN")
            {
                Form2 nw = new Form2();
                nw.Show();
            }
            else if(btnLogin.Text == "LOGOUT")
            {
                MessageBox.Show("Successfully Logged Out, Thank you Boss " + Convert.ToString(username) + "!");
                this.Dispose();
            }
        }
    }
}
