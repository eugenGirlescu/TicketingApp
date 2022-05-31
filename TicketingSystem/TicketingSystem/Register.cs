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

namespace TicketingSystem
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=LAPTOP-SQ90480J\\SQLEXPRESS;Initial Catalog=ticketing;Integrated Security=True");
            SqlCommand cmd;
            if (txtFname.Text != string.Empty && txtPass.Text != string.Empty && txtLname.Text != string.Empty && txtEmail.Text != string.Empty)
            {
                conn.Open();
                cmd = new SqlCommand("SELECT  * FROM [dbo].[register] where email='" + txtEmail.Text + "'", conn);
                SqlDataReader userFromDb= cmd.ExecuteReader();

                if(userFromDb.Read())
                {
                    userFromDb.Close();
                    MessageBox.Show("User with this email already exist please try another ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } else
                {
                    userFromDb.Close();
                    cmd = new SqlCommand("INSERT INTO[dbo].[register] VALUES(@firstName,@lastName,@email,@password)", conn);
                    cmd.Parameters.AddWithValue("firstName", txtFname.Text);
                    cmd.Parameters.AddWithValue("lastName", txtLname.Text);
                    cmd.Parameters.AddWithValue("email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("password", txtPass.Text);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Your Account is created . Please login now.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            } else
            {
                MessageBox.Show("Please enter value in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
        }
    }
}
