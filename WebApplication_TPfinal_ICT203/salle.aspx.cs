using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WebApplication_TPfinal_ICT203
{
    public partial class salle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT code from salle order by code asc";
                string query2 = "SELECT * FROM salle order by code asc";
                MySqlCommand command = new MySqlCommand(query, connection);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string codeSalle = reader.GetString("code");

                        HtmlGenericControl listItem = new HtmlGenericControl("li");
                        //listItem.InnerText = codeSalle;
                        listItem.Style["color"] = "white";
                        listItem.Style["font-size"] = "19.6px";
                        listItem.Style.Add("position", "relative");

                        // Créer le deuxième bouton
                        Button bouton_supprimer = new Button();
                        bouton_supprimer.BorderStyle = BorderStyle.None;
                        bouton_supprimer.Text = "Supprimer";
                        bouton_supprimer.Style.Add("font-size", "15px");
                        bouton_supprimer.Style.Add("width", "100px");
                        bouton_supprimer.Style.Add("position", "absolute");
                        bouton_supprimer.Style.Add("right", "5px");
                        bouton_supprimer.Style.Add("margin-top", "15px");
                        bouton_supprimer.Style.Add("background-color", "red");
                        bouton_supprimer.Style.Add("color", "white");
                        bouton_supprimer.Style.Add("border-radius", "15px");
                        bouton_supprimer.Click += (buttonSender, buttonEvent) => Supprimer_Click(buttonSender, buttonEvent, codeSalle); // Associer l'événement de clic et passer le texte en paramètre

                        // Ajouter les boutons à l'élément <li>
                        //listItem.Controls.Add(bouton_ouvrir);
                        listItem.Controls.Add(bouton_supprimer);

                        myList.Style.Add("position", "absolute");
                        myList.Controls.Add(listItem);
                    }
                }
                using (MySqlCommand command2 = new MySqlCommand(query2, connection))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command2))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        GridView1.DataSource = dataTable;
                        GridView1.DataBind();
                    }
                }
                connection.Close();
            }
        }
        protected void Supprimer_Click(object sender, EventArgs e, string codeSalle)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
            string query = "delete from salle where code like '" + codeSalle + "'";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                    Response.Redirect("salle.aspx");
                }
                connection.Close();
            }
        }

        protected void Enregistrer_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
            string query = "insert into salle() values(@v1,@v2)";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@v1", textboxCode.Text);
                    command.Parameters.AddWithValue("@v2", textboxCapacite.Text);
                    command.ExecuteNonQuery();
                    Response.Redirect("salle.aspx");
                }
                connection.Close();
            }
        }
    }
}