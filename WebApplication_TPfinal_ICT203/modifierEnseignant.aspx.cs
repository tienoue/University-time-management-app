using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication_TPfinal_ICT203
{
    public partial class modifierEnseignant : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString2 = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(connectionString2))
            {
                connection.Open();
                string query2 = "SELECT matricule, nom, image from enseignant where matricule='" + Class1.matriculeEnseignant + "'";
                MySqlCommand command = new MySqlCommand(query2, connection);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string matricule=reader.GetString("matricule");
                        string nom = reader.GetString("nom");
                        byte[] imageData = (byte[])reader["image"];

                        Panel panelEnseignant = new Panel();
                        panelEnseignant.Width = 60;
                        panelEnseignant.Height = 40;
                        panelEnseignant.Style["position"] = "relative";
                        panelEnseignant.ToolTip = "Modifier la photo de profil";
                        panelEnseignant.Style["margin-left"] = "auto";
                        panelEnseignant.Style["margin-right"] = "auto";
                        panelEnseignant.Style["width"] = "150px";

                        Label labelMatricule = new Label();
                        labelMatricule.Text = "<strong>Matricule: </strong>"+matricule+"<br/>";

                        Label labelNom= new Label();
                        labelNom.Text = "<strong>Nom: </strong>" + nom+"<br/>";

                        // Créer une image pour le departement
                        Image imageEnseignant = new Image();
                        imageEnseignant.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(imageData);
                        //imageEnseignant.CssClass = "imageEnseignant";
                        imageEnseignant.Style["width"] = "150px";
                        imageEnseignant.Style["height"] = "auto";
                        imageEnseignant.Style["position"] = "relative";
                        imageEnseignant.Style["margin-left"] = "auto";
                        imageEnseignant.Style["margin-right"] = "auto";
                        //imageEnseignant.Style["border-radius"] = "50px";

                        // Ajouter l'image et l'étiquette au panel de l'étudiant
                        panelEnseignant.Controls.Add(imageEnseignant);

                        // Ajouter le panel de l'étudiant à un conteneur sur votre page (par exemple, un placeholder)
                        image.Controls.Add(panelEnseignant);

                        PanelInformations.Controls.Add(labelMatricule);
                        PanelInformations.Controls.Add(labelNom);
                    }
                }
                connection.Close();
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string connectionString2 = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(connectionString2))
            {
                connection.Open();
                string query2 = "delete from enseignant where matricule='" + Class1.matriculeEnseignant + "'";
                MySqlCommand command = new MySqlCommand(query2, connection);
                command.ExecuteNonQuery();
                Response.Redirect("Enseignants.aspx");
                connection.Close();
            }
        }
    }
}