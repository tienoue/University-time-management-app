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
    public partial class Departements : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*string connectionString = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT nomDepartement, image FROM departement order by nomDepartement asc";
                MySqlCommand command = new MySqlCommand(query, connection);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string nomDepartement = reader.GetString("nomDepartement");
                        byte[] imageData  = (byte[])reader["image"];

                        Panel panelDepartement = new Panel();
                        panelDepartement.Width = 300;
                        panelDepartement.Height = 300;
                        panelDepartement.CssClass = "panelDepartement";

                        // Créer une image pour le departement
                        Image imageDepartement = new Image();
                        imageDepartement.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(imageData );
                        imageDepartement.CssClass = "imageDepartement";

                        // Créer une étiquette pour afficher le nom de l'étudiant
                        Label labelNomDepartement = new Label();
                        labelNomDepartement.Text = nomDepartement;
                        labelNomDepartement.CssClass = "nomDepartement";

                        // Ajouter l'image et l'étiquette au panel de l'étudiant
                        panelDepartement.Controls.Add(imageDepartement);
                        panelDepartement.Controls.Add(labelNomDepartement);

                        // Ajouter le panel de l'étudiant à un conteneur sur votre page (par exemple, un placeholder)
                        Panel1.Controls.Add(panelDepartement);
                    }
                }
                connection.Close();
            }*/

            string connectionString = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT nomDepartement, image FROM departement order by nomDepartement asc";
                MySqlCommand command = new MySqlCommand(query, connection);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string nomDepartement = reader.GetString("nomDepartement");
                        byte[] imageData  = (byte[])reader["image"];

                        LinkButton panelDepartement = new LinkButton();
                        panelDepartement.Width = 300;
                        panelDepartement.Height = 250;
                        panelDepartement.CssClass = "panelDepartement";
                        panelDepartement.Click += ClickablePanel_Click;

                        // Créer une image pour le departement
                        Image imageDepartement = new Image();
                        imageDepartement.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(imageData );
                        imageDepartement.CssClass = "imageDepartement";
                        imageDepartement.Style["border-radius"] = "10px";

                        // Créer une étiquette pour afficher le nom de l'étudiant
                        Label labelNomDepartement = new Label();
                        //labelNomDepartement.ID = "idLabelNomDepartement";
                        labelNomDepartement.Text = nomDepartement;
                        labelNomDepartement.CssClass = "nomDepartement";

                        // Ajouter l'image et l'étiquette au panel de l'étudiant
                        panelDepartement.Controls.Add(imageDepartement);
                        panelDepartement.Controls.Add(labelNomDepartement);

                        // Ajouter le panel de l'étudiant à un conteneur sur votre page (par exemple, un placeholder)
                        Panel1.Controls.Add(panelDepartement);
                    }
                }
                connection.Close();
            }

        }

        protected void ClickablePanel_Click(object sender, EventArgs e)
        {
            /*LinkButton panelDepartement = (LinkButton)sender;
            Label label = (Label)panelDepartement.FindControl("idLabelNomDepartement"); // Remplacez "labelId" par l'ID réel de votre Label

            if (label != null)
            {
                Class1.departementActuel = label.Text;
            }*/

            LinkButton panelDepartement = (LinkButton)sender;

            if (panelDepartement.Controls.Count > 0 && panelDepartement.Controls[0] is Label)
            {
                Label label = (Label)panelDepartement.Controls[0];
                Class1.departementActuel = label.Text;
            }
            else if (panelDepartement.Controls.Count > 0 && panelDepartement.Controls[1] is Label)
            {
                Label label = (Label)panelDepartement.Controls[1];
                Class1.departementActuel = label.Text;
            }

            Response.Redirect("filiere.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AjouterDepartement.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("niveau.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("UE.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("salle.aspx");
        }
    }
}