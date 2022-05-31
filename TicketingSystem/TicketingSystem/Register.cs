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
            SqlCommand cmd = new SqlCommand(
                @"INSERT INTO[dbo].[register]
           ([firstName]
           ,[lastName]
           ,[email]
           ,[password])
     VALUES
           ('" + txtFname.Text + "', '" + txtLname.Text + "', '" + txtEmail.Text + "', '" + txtPass.Text +"' )",conn);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Registered succesfully !");
            }
            catch (SqlException) {
                MessageBox.Show(" User email already exist !");
            }
            
        }
    }
}
