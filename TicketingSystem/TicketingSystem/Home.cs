using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicketingSystem
{
    public partial class Home : Form
    {
        Ticket ticket = new Ticket();
        public Home()
        {
            InitializeComponent();
            txtId.Enabled = false;
            cboxStatus.Enabled = false;
            setDataGridView();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            
        }


        private void clearControls()
        {
            txtId.Text = "";
            txtSubject.Text = "";
            txtDescription.Text = "";
        }

        private void setDataGridView()
        {
            dataGridView.DataSource = ticket.GetTickets();
        }

        private void fillWithData(DataGridViewCellEventArgs e)
        {
            var index = e.RowIndex;
            txtId.Text = dataGridView.Rows[index].Cells[0].Value.ToString();
            txtSubject.Text = dataGridView.Rows[index].Cells[1].Value.ToString();
            txtDescription.Text = dataGridView.Rows[index].Cells[2].Value.ToString();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            ticket.subject = txtSubject.Text;
            ticket.description = txtDescription.Text;
            if (ticket.subject != String.Empty)
            {
                var succes = ticket.insertTicket(ticket);
                setDataGridView();

                if (succes)
                {
                    clearControls();
                    MessageBox.Show("Ticket has been added successfully");
                }
                else
                {
                    MessageBox.Show("Error occured. Please try again...");
                }
            }
            else
            {
                MessageBox.Show("Subject cannot be empty...");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ticket.subject != string.Empty)
            {
                ticket.id = txtId.Text;
                ticket.subject = txtSubject.Text;
                ticket.description = txtDescription.Text;
                ticket.status = cboxStatus.SelectedItem.ToString();
                var succes = ticket.updateTicket(ticket);
                dataGridView.DataSource = ticket.GetTickets();
                btnCreate.Enabled = true;

                if (succes)
                {
                    clearControls();
                    MessageBox.Show("Ticket has been updated successfully");
                }
                else
                {
                    MessageBox.Show("Error occured. Please try again...");
                }      
            }
            else
            {
                MessageBox.Show("Subject cannot be empty !...");
            }
        }

        private void dgvEmployeeDetails_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnCreate.Enabled = false;
            txtId.Enabled = true;
            cboxStatus.Enabled = true;

            fillWithData(e);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearControls();
            btnCreate.Enabled = true;
            btnUpdate.Enabled = true;
        }
    }
}
