using Microsoft.Ajax.Utilities;
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
    public partial class Enseignants : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT matricule, nom, image FROM enseignant order by nom asc";
                MySqlCommand command = new MySqlCommand(query, connection);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string matricule = reader.GetString("matricule");
                        string nomEnseignant = reader.GetString("nom");
                        string chaine=nomEnseignant+"("+matricule+")";
                        byte[] imageData = (byte[])reader["image"];
                        //string imageUrl = reader.GetString("image_url");

                        LinkButton panelEnseignant = new LinkButton();
                        panelEnseignant.Width = 200;
                        panelEnseignant.Height= 200;
                        panelEnseignant.CssClass = "panelEnseignant";
                        panelEnseignant.Click += ClickablePanel_Click;

                        // Créer une image pour l'étudiant
                        Image imageEnseignant = new Image();
                        imageEnseignant.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(imageData);
                        imageEnseignant.CssClass = "imageEnseignant";
                        imageEnseignant.Style["border-radius"] = "10px";

                        // Créer une étiquette pour afficher le nom de l'étudiant
                        Label labelNomEtMatricule = new Label();
                        labelNomEtMatricule.Text = chaine;
                        labelNomEtMatricule.CssClass = "nomEnseignant";

                        // Ajouter l'image et l'étiquette au panel de l'étudiant
                        panelEnseignant.Controls.Add(imageEnseignant);
                        panelEnseignant.Controls.Add(labelNomEtMatricule);

                        // Ajouter le panel de l'étudiant à un conteneur sur votre page (par exemple, un placeholder)
                        Panel1.Controls.Add(panelEnseignant);
                    }
                }
                connection.Close();
            }
        }

        protected void ClickablePanel_Click(object sender, EventArgs e)
        {

            LinkButton panelDepartement = (LinkButton)sender;

            if (panelDepartement.Controls.Count > 0 && panelDepartement.Controls[0] is Label)
            {
                Label label = (Label)panelDepartement.Controls[0];
                string chaine = label.Text;
                int premiereParenthese = 0;
                int deuxiemeParenthese = 0;
                for (int i = 0; i < chaine.Length; i++)
                {
                    if (chaine.Substring(i, 1) == "(")
                    {
                        premiereParenthese = i;
                    }
                    if (chaine.Substring(i, 1) == ")")
                    {
                        deuxiemeParenthese = i;
                    }
                }
                Class1.matriculeEnseignant = chaine.Substring(premiereParenthese + 1, deuxiemeParenthese - premiereParenthese - 1);
            }
            else if (panelDepartement.Controls.Count > 0 && panelDepartement.Controls[1] is Label)
            {
                Label label = (Label)panelDepartement.Controls[1];
                string chaine = label.Text;
                int premiereParenthese = 0;
                int deuxiemeParenthese = 0;
                for (int i = 0; i < chaine.Length; i++)
                {
                    if (chaine.Substring(i, 1) == "(")
                    {
                        premiereParenthese = i;
                    }
                    if (chaine.Substring(i, 1) == ")")
                    {
                        deuxiemeParenthese = i;
                    }
                }
                Class1.matriculeEnseignant = chaine.Substring(premiereParenthese + 1, deuxiemeParenthese - premiereParenthese - 1);
            }

            Response.Redirect("modifierEnseignant.aspx");
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AjouterEnseignant.aspx");
        }
    }
}