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
    public partial class Messages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Username"] != null)
            {
                string query = "select message, dateEnvoi, heureEnvoi from message where destinataire=@destinataire order by id desc";
                string query2 = "update enseignant set nombreMessages=@nombre where matricule=@m";
                string matricule = Session["Username"].ToString();
                using (MySqlConnection connexion = new MySqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString))
                {

                    using (MySqlCommand cmd = new MySqlCommand(query, connexion))
                    {
                        connexion.Open();
                        cmd.Parameters.AddWithValue("@destinataire", matricule);
                        using (MySqlDataAdapter adapter=new MySqlDataAdapter(cmd))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            GridView1.DataSource = dataTable;
                            GridView1.DataBind();
                        }

                    }
                    using (MySqlCommand cmd = new MySqlCommand(query2, connexion))
                    {
                        cmd.Parameters.AddWithValue("@nombre", Class1.nombreMessages);
                        cmd.Parameters.AddWithValue("@m", Session["Username"]);
                        cmd.ExecuteNonQuery();
                    }

                    connexion.Close();
                }
            }
            else
            {
                string scrip = "alert ('Aucun utilisateur connecte')";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", scrip, true);
            }
        }
    }
}