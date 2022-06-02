using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace TicketingSystem
{
    class Ticket
    {
        private static String myConn = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

        public String id { get; set; }
        public String subject { get; set; }

        public String description { get; set; }

        public String status { get; set; }

        public DateTime openDate { get; set; }

        private const String SELECT_QUERY = "SELECT id,subject,description,status,openDate FROM [dbo].[ticket] WHERE status='Open'";

        private const String INSERT_QUERY = "INSERT INTO [dbo].[ticket](subject,description) VALUES(@subject,@description)";

        private const String UPDATE_QUERY_STATUS_OPEN = "UPDATE [dbo].[ticket] SET subject=@subject,description=@description where id=@id";

        private const String UPDATE_QUERY_STATUS_CLOSED = "UPDATE [dbo].[ticket] SET subject=@subject,description=@description,status=@status,closeDate=@closeDate where id=@id";

        private const String DELETE_QUERY = "DELETE FROM [dbo].[ticket] WHERE id=@id";
        public DataTable GetTickets()
        {
            var datatable = new DataTable();
            using (SqlConnection conn = new SqlConnection(myConn))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(SELECT_QUERY, conn))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(datatable);
                    }
                }
                conn.Close();
            }
            return datatable;
        }

        public bool insertTicket(Ticket ticket)
        {
            int rows;
            using (SqlConnection con = new SqlConnection(myConn))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(INSERT_QUERY, con))
                {
                    cmd.Parameters.AddWithValue("@subject", ticket.subject);
                    cmd.Parameters.AddWithValue("@description", ticket.description);

                    rows = cmd.ExecuteNonQuery();
                }
            }
            return (rows > 0) ? true : false;
        }

        private bool executeQuery(Ticket ticket, String query)
        {
            int rows;
            SqlConnection con = new SqlConnection(myConn);

            con.Open();

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@id", ticket.id);
            cmd.Parameters.AddWithValue("@subject", ticket.subject);
            cmd.Parameters.AddWithValue("@description", ticket.description);
            cmd.Parameters.AddWithValue("@status", ticket.status);
            cmd.Parameters.AddWithValue("@closeDate", DateTime.Now);

            rows = cmd.ExecuteNonQuery();

            return (rows > 0) ? true : false;
        }
        public bool updateTicket(Ticket ticket)
        {
            if (ticket.status == "Open")
            {
                return executeQuery(ticket, UPDATE_QUERY_STATUS_OPEN);
            }
            else
            {
                return executeQuery(ticket, UPDATE_QUERY_STATUS_CLOSED);
            }
        }

        public bool deleteTicket(Ticket ticket)
        {
            int rows;
            using (SqlConnection con = new SqlConnection(myConn))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(DELETE_QUERY, con))
                {
                    com.Parameters.AddWithValue("@id", ticket.id);
                    rows = com.ExecuteNonQuery();
                }
            }
            return (rows > 0) ? true : false;
        }
    }
}
