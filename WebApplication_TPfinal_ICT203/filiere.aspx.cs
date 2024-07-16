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
    public partial class filiere : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            nomDepartement.InnerText = "'"+Class1.departementActuel.ToUpper()+"'";


            char caractereAChanger = '\'';
            string departementActuel = "";

            foreach (char c in Class1.departementActuel)
            {
                if (c == caractereAChanger)
                {
                    departementActuel += "\\'";
                }
                else
                {
                    departementActuel += c;
                }
            }

            string connectionString = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT nomFiliere from filiere where nomDepartement like '"+departementActuel+"' order by nomFiliere asc";
                MySqlCommand command = new MySqlCommand(query, connection);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string nomFiliere = reader.GetString("nomFiliere");

                        HtmlGenericControl listItem = new HtmlGenericControl("li");
                        listItem.InnerText = nomFiliere;
                        listItem.Style["font-size"] = "30px";
                        listItem.Style.Add("position", "relative");
                        /*// Créer le premier bouton
                        Button bouton_ouvrir = new Button();
                        bouton_ouvrir.BorderStyle = BorderStyle.None;
                        bouton_ouvrir.Text = "Ouvrir";
                        bouton_ouvrir.Style.Add("font-size", "20px");
                        bouton_ouvrir.Style.Add("width", "100px");
                        bouton_ouvrir.Style.Add("position", "absolute");
                        bouton_ouvrir.Style.Add("right", "110px");
                        bouton_ouvrir.Style.Add("margin-top", "8px");
                        bouton_ouvrir.Style.Add("background-color", "green");
                        bouton_ouvrir.Style.Add("color", "white");
                        bouton_ouvrir.Click += (buttonSender, buttonEvent) => Ouvrir_Click(buttonSender, buttonEvent, nomFiliere); // Associer l'événement de clic et passer le texte en paramètre*/

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
                        bouton_supprimer.Click += (buttonSender, buttonEvent) => Supprimer_Click(buttonSender, buttonEvent, nomFiliere); // Associer l'événement de clic et passer le texte en paramètre

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

        /*protected void Ouvrir_Click(object sender, EventArgs e, string nomFiliere)
        {
            Class1.filiereActuelle = nomFiliere;
            Response.Redirect("niveau.aspx");
        }*/

        protected void Supprimer_Click(object sender, EventArgs e, string nomFiliere)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
            string query = "delete from filiere where nomFiliere like '"+ nomFiliere + "'";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                    Response.Redirect("filiere.aspx");
                }
                connection.Close();
            }
        }

        protected void Enregistrer_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
            string query = "insert into filiere() values(@v1,@v2)";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@v1", textboxNomFiliere.Text);
                    command.Parameters.AddWithValue("@v2", Class1.departementActuel);
                    command.ExecuteNonQuery();
                    Response.Redirect("filiere.aspx");
                }
                connection.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
            string query = "delete from departement where nomDepartement like '" + Class1.departementActuel + "'";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                    Response.Redirect("Departements.aspx");
                }
                connection.Close();
            }
        }
    }
}