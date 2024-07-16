using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication_TPfinal_ICT203
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*string connectionString = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
            string query = "insert into compteadmin(login, password) values (@login,@password)";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@login", "admin1");
                    command.Parameters.AddWithValue("@password", Class1.HashPassword("q"));
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }*/
            int nombre=0, nombreDesideratasEffectif;
            string connectionString = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
            string query = "SELECT count(*) from desiderata2";
            string query2 = "select nombreDesideratas from compteadmin";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        nombreDesideratasEffectif = Convert.ToInt32(command.ExecuteScalar());
                    }
                }
                using (MySqlCommand command = new MySqlCommand(query2, connection))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        nombre = Convert.ToInt32(command.ExecuteScalar());
                    }
                }
                
                connection.Close();
            }
            if (nombreDesideratasEffectif > nombre)
            {
                Class1.nombreDesideratas = nombreDesideratasEffectif;
                int nouveauxDesideratas=nombreDesideratasEffectif-nombre;
                span.Style["color"] = "White";
                span.Style["background-color"] = "rgb(0, 0, 255)";
                span.Style["padding-top"] = "4px";
                span.Style["padding-bottom"] = "4px";
                span.Style["padding-left"] = "10px";
                span.Style["padding-right"] = "10px";
                span.Style["border-radius"] = "20px";
                span.InnerText = nouveauxDesideratas.ToString();

                span.Visible = true;
            }
            else
            {
                span.Visible=false;
            }


            









            if (Session["Username"] != null)
            {
                deconnexion.Visible = true;

                object obj;
                string loginAdministrateur;
                string connectionString1 = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
                string query1 = "SELECT login FROM compteAdmin";
                using (MySqlConnection connection = new MySqlConnection(connectionString1))
                {
                    using (MySqlCommand command = new MySqlCommand(query1, connection))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            connection.Open();
                            obj = command.ExecuteScalar();
                            connection.Close();
                            loginAdministrateur = obj.ToString();
                        }
                    }
                }
                if (loginAdministrateur == (string)Session["Username"])
                {
                    mesProgrammations.Visible = false;
                    desiderata.Visible = false;
                    messages.Visible = false;

                    enseignants.Visible = true;
                    departements.Visible = true;
                    programmer.Visible = true;
                    modifierProgrammation.Visible = true;
                    DesideratasAdmin.Visible = true;
                    historique.Visible = true;
                }
                else
                {
                    mesProgrammations.Visible = true;
                    desiderata.Visible = true;
                    messages.Visible = true;

                    enseignants.Visible = false;
                    departements.Visible = false;
                    programmer.Visible = false;
                    modifierProgrammation.Visible = false;
                    DesideratasAdmin.Visible = false;
                    historique.Visible = false;


                    int nombre2 = 0, nombreMessagesEffectif;
                    string connectionString2 = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
                    string query3 = "SELECT count(*) from message where destinataire=@d";
                    string query4 = "select nombreMessages from enseignant where matricule=@d";
                    using (MySqlConnection connection = new MySqlConnection(connectionString2))
                    {
                        connection.Open();
                        using (MySqlCommand command = new MySqlCommand(query3, connection))
                        {
                            using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                            {
                                command.Parameters.AddWithValue("@d", (string)Session["Username"]);
                                nombreMessagesEffectif = Convert.ToInt32(command.ExecuteScalar());
                            }
                        }
                        using (MySqlCommand command = new MySqlCommand(query4, connection))
                        {
                            using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                            {
                                command.Parameters.AddWithValue("@d", (string)Session["Username"]);
                                nombre2 = Convert.ToInt32(command.ExecuteScalar());
                            }
                        }
                        connection.Close();
                    }
                    
                    if (nombreMessagesEffectif > nombre2)
                    {
                        Class1.nombreMessages = nombreMessagesEffectif;
                        int nouveauxMessages = nombreMessagesEffectif - nombre2;
                        span1.Style["color"] = "White";
                        span1.Style["background-color"] = "rgb(0, 0, 255)";
                        span1.Style["padding-top"] = "4px";
                        span1.Style["padding-bottom"] = "4px";
                        span1.Style["padding-left"] = "10px";
                        span1.Style["padding-right"] = "10px";
                        span1.Style["border-radius"] = "20px";
                        span1.InnerText = nouveauxMessages.ToString();

                        span1.Visible = true;
                    }
                    else
                    {
                        span1.Visible = false;
                    }
                }
            }
            else
            {
                deconnexion.Visible = false;

                mesProgrammations.Visible = false;
                desiderata.Visible = false;
                messages.Visible = false;

                enseignants.Visible = false;
                departements.Visible = false;
                programmer.Visible = false;
                modifierProgrammation.Visible = false;
                DesideratasAdmin.Visible = false;
                historique.Visible = false;
            }

            deconnexion.ServerClick += deconnexion_Click;
        }

        private void deconnexion_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Default.aspx");
        }

    }
}