using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication_TPfinal_ICT203
{
    public partial class historique : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (MySqlConnection connexion = new MySqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString))
            {
                string query6 = "select * from trace_programmation";

                connexion.Open();
                using (MySqlCommand cmd = new MySqlCommand(query6))
                {
                    cmd.Connection = connexion;
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        GridView1.DataSource = dataTable;
                        GridView1.DataBind();
                    }
                }
                connexion.Close();
            }
        }
    }
}