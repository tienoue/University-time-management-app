using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication_TPfinal_ICT203
{
    public partial class AjouterEnseignant : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            labelSuccess.Visible = false;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
            string query = "insert into enseignant() values(@v1,@v2,@v3,@v4,@v5)";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@v1", matricule.Text);
                    command.Parameters.AddWithValue("@v2", nom.Text);
                    command.Parameters.AddWithValue("@v3", Class1.HashPassword(motDePasse.Text));
                    command.Parameters.AddWithValue("@v4", File.ReadAllBytes(Server.MapPath("~/images2/user2.jpg")));
                    command.Parameters.AddWithValue("@v5", 0);
                    command.ExecuteNonQuery();
                    //labelSuccess.Visible = true;
                }
                connection.Close();
            }
            /*matricule.Text = "";
            nom.Text = "";
            motDePasse.Text = "";*/
            Response.Redirect("Enseignants.aspx");
        }
    }
}