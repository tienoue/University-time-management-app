using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WebApplication_TPfinal_ICT203
{
    public partial class niveau : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string connectionString = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT code from niveau order by code asc";
                MySqlCommand command = new MySqlCommand(query, connection);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string codeNiveau = reader.GetString("code");

                        HtmlGenericControl listItem = new HtmlGenericControl("li");
                        listItem.InnerText = codeNiveau;
                        listItem.Style["font-size"] = "30px";
                        listItem.Style.Add("position", "relative");

                        // Créer le deuxième bouton
                        Button bouton_supprimer = new Button();
                        bouton_supprimer.BorderStyle = BorderStyle.None;
                        bouton_supprimer.Text = "Supprimer";
                        bouton_supprimer.Style.Add("font-size", "20px");
                        bouton_supprimer.Style.Add("width", "100px");
                        bouton_supprimer.Style.Add("position", "absolute");
                        bouton_supprimer.Style.Add("right", "5px");
                        bouton_supprimer.Style.Add("margin-top", "8px");
                        bouton_supprimer.Style.Add("background-color", "red");
                        bouton_supprimer.Style.Add("color", "white");
                        bouton_supprimer.Style.Add("border-radius", "15px");
                        bouton_supprimer.Click += (buttonSender, buttonEvent) => Supprimer_Click(buttonSender, buttonEvent, codeNiveau); // Associer l'événement de clic et passer le texte en paramètre

                        // Ajouter les boutons à l'élément <li>
                        //listItem.Controls.Add(bouton_ouvrir);
                        listItem.Controls.Add(bouton_supprimer);

                        myList.Style.Add("position", "absolute");
                        myList.Controls.Add(listItem);
                    }
                }
                connection.Close();
            }
        }

        protected void Supprimer_Click(object sender, EventArgs e, string codeNiveau)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
            string query = "delete from niveau where code like '" + codeNiveau + "'";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                    Response.Redirect("niveau.aspx");
                }
                connection.Close();
            }
        }

        protected void Enregistrer_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
            string query = "insert into niveau() values(@v1)";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@v1", textboxCodeNiveau.Text);
                    command.ExecuteNonQuery();
                    Response.Redirect("niveau.aspx");
                }
                connection.Close();
            }
        }
    }
}