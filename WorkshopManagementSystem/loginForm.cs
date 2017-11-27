using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using MySqlDatabaseConnection;

namespace WorkshopManagementSystem
{
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection myConnection = DatabaseConnection.getDBConnection();

                string query = "SELECT * FROM c_users WHERE email = @field1 AND password = MD5(@field2)";
                
                using (MySqlCommand command = new MySqlCommand(query, myConnection))
                {
                    command.Parameters.AddWithValue("@field1", txtEmail.Text.Trim());
                    command.Parameters.AddWithValue("@field2", txtPassword.Text.Trim());

                    if (myConnection.State != ConnectionState.Open)
                    {
                        myConnection.Close();
                        myConnection.Open();
                    }
                    
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        int rowCount = 0;
                        while (reader.Read())
                        {
                            rowCount++;
                        }

                        if (rowCount == 1)
                        {
                            this.Hide();
                            mainWindow frm = new mainWindow(this);
                            frm.Show();
                        }
                        else {
                            txtPassword.Text = "";
                            // Dialog box with exclamation icon
                            MessageBox.Show("Please Check username and password and try again",
                                "Login Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1);
                        }                        
                    }
                    
                    myConnection.Close();
                }                
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void loginForm_Load(object sender, EventArgs e)
        {
            /*
            try
            {
                MySqlConnection checkConnection = DatabaseConnection.getDBConnection();

                if (checkConnection.State != ConnectionState.Open)
                {
                    checkConnection.Close();
                    checkConnection.Open();
                }

                if (checkConnection.State != ConnectionState.Open)
                {
                    MessageBox.Show("Database server offline",
                                    "Server Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation,
                                    MessageBoxDefaultButton.Button1);
                }

                checkConnection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            */
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}
