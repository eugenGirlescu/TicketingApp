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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register register = new Register();
            register.ShowDialog();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=LAPTOP-SQ90480J\\SQLEXPRESS;Initial Catalog=ticketing;Integrated Security=True");
            conn.Open();

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=LAPTOP-SQ90480J\\SQLEXPRESS;Initial Catalog=ticketing;Integrated Security=True");
            SqlCommand cmd;

            if (txtEmail.Text != string.Empty && txtPass.Text != string.Empty)
            {
                conn.Open();
                cmd = new SqlCommand("SELECT  * FROM [dbo].[register] where email='" + txtEmail.Text + "' and password='" + txtPass.Text + "'", conn);
                SqlDataReader userFromDb = cmd.ExecuteReader();

                if (userFromDb.Read())
                {
                    userFromDb.Close();
                    conn.Close();
                    this.Hide();
                    Home home = new Home();
                    home.ShowDialog();
                } else
                {
                    userFromDb.Close();
                    MessageBox.Show("No Account available with this username and password ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else
            {
                MessageBox.Show("Please enter value in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
