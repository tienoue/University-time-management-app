using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication_TPfinal_ICT203
{
    public partial class MonCompte : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblErrorMessage.Visible = false;
            lblErrorMessage0.Visible = false;
            lblErrorMessage1.Visible = false;
            LabelMAJ.Visible = false;
            if (Session["Username"]==null)
            {
                PanelConnexion.Visible = true;
                PanelCompteAdministrateur.Visible = false;
                PanelCompteUtilisateur.Visible = false;
            }
            else
            {
                PanelConnexion.Visible = false;
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
                    PanelCompteAdministrateur.Visible = true;
                    PanelCompteUtilisateur.Visible = false;
                }
                else
                {
                    PanelCompteAdministrateur.Visible = false;
                    PanelCompteUtilisateur.Visible = true;

                    PanelInformations.Visible = true;
                    PanelModifierMotDePasse.Visible = false;

                    string connectionString = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
                    string query = "SELECT * FROM enseignant where matricule=@matricule";
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@matricule", (string)Session["Username"]);
                            using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                            {
                                DataTable dataTable = new DataTable();
                                adapter.Fill(dataTable);
                                datalist1.DataSource = dataTable;
                                datalist1.DataBind();
                            }
                        }
                    }


                    fileUpload.Visible = false;
                    modifier.Visible = false;

                    string connectionString2 = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
                    using (MySqlConnection connection = new MySqlConnection(connectionString2))
                    {
                        connection.Open();
                        string query2 = "SELECT image from enseignant where matricule='"+ (string)Session["Username"] + "'";
                        MySqlCommand command = new MySqlCommand(query2, connection);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                byte[] imageData = (byte[])reader["image"];

                                LinkButton panelEnseignant = new LinkButton();
                                panelEnseignant.Width = 60;
                                panelEnseignant.Height = 40;
                                panelEnseignant.Style["position"]="relative";
                                panelEnseignant.Click += ClickablePanel_Click;
                                panelEnseignant.ToolTip = "Modifier la photo de profil";
                                panelEnseignant.Style["margin-left"] = "auto";
                                panelEnseignant.Style["margin-right"] = "auto";
                                panelEnseignant.Style["width"] = "150px";


                                // Créer une image pour le departement
                                Image imageEnseignant = new Image();
                                imageEnseignant.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(imageData);
                                //imageEnseignant.CssClass = "imageEnseignant";
                                imageEnseignant.Style["width"] = "150px";
                                imageEnseignant.Style["height"] = "auto";
                                imageEnseignant.Style["position"] = "relative";
                                imageEnseignant.Style["margin-left"] = "auto";
                                imageEnseignant.Style["margin-right"] = "auto";

                                // Ajouter l'image et l'étiquette au panel de l'étudiant
                                panelEnseignant.Controls.Add(imageEnseignant);

                                // Ajouter le panel de l'étudiant à un conteneur sur votre page (par exemple, un placeholder)
                                image.Controls.Add(panelEnseignant);
                            }
                        }
                        connection.Close();
                    }

                }
            }

        }

        protected void ClickablePanel_Click(object sender, EventArgs e)
        {
            fileUpload.Visible = true;
            modifier.Visible = true;
        }

        protected void modifier_Click(object sender, EventArgs e)
        {
            if (fileUpload.PostedFile != null && fileUpload.PostedFile.ContentLength > 0)
            {
                // Récupérer le nom du fichier
                //string fileName = System.IO.Path.GetFileName(fileUpload.PostedFile.FileName);

                // Récupérer le contenu du fichier
                int fileLength = fileUpload.PostedFile.ContentLength;
                byte[] fileBytes = new byte[fileLength];
                fileUpload.PostedFile.InputStream.Read(fileBytes, 0, fileLength);

                // Créer une connexion à la base de données
                string connectionString = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
                MySqlConnection connection = new MySqlConnection(connectionString);

                try
                {
                    // Ouvrir la connexion à la base de données
                    connection.Open();

                    // Insérer l'image dans la base de données
                    string query = "update enseignant set image=@val where matricule='" + (string)Session["Username"] + "'";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@val", fileBytes);
                    command.ExecuteNonQuery();
                    fileUpload.Visible = false;
                    modifier.Visible = false;
                    Response.Redirect("MonCompte.aspx");

                }
                catch (Exception ex)
                {
                    // Gérer les erreurs
                }
                finally
                {
                    // Fermer la connexion à la base de données
                    connection.Close();
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string login = TextBox_Poste.Text;
            string password = TextBox_Salaire.Text;

            // Vérifier les informations d'identification dans la base de données
            if (CheckCredentials(login, Class1.HashPassword(password)))
            {
                // Les informations d'identification sont valides, rediriger l'utilisateur vers la page d'accueil
                //Class1.variableSessionUtilisateur = true;
                //Response.Redirect("~/Utilisateur.aspx");
                Session["Username"] = login;
                Session["Password"]= Class1.HashPassword(password);

                Response.Redirect("Default.aspx");
            }
            else
            {
                // Les informations d'identification sont invalides, afficher un message d'erreur
                lblErrorMessage.Text = "Nom d'utilisateur ou mot de passe incorrect.";
                lblErrorMessage.Visible = true;
            }
        }

        private bool CheckCredentials(string id, string password)
        {
            int count;
            string connectionString = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
            string query = "SELECT COUNT(*) FROM enseignant WHERE matricule = @Id AND motDePasse = @Password";
            string query2 = "SELECT COUNT(*) FROM compteAdmin WHERE login = @Id AND password = @Password";

            if (id.Substring(0,5)!="admin") //on verifie si le login ne commence pas par "admin": si c'est le cas, on verifie les informations de connexion de l'utilisateur(query), sinon, de l'administrateur(query2)
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        command.Parameters.AddWithValue("@Password", password);
                        connection.Open();
                        count = Convert.ToInt32(command.ExecuteScalar());
                        connection.Close();
                    }
                }
            }
            else
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand command = new MySqlCommand(query2, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        command.Parameters.AddWithValue("@Password", password);
                        connection.Open();
                        count = Convert.ToInt32(command.ExecuteScalar());
                        connection.Close();
                    }
                }
            }


            if (count != 0)
                return true;
            else
                return false;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
            string query = "select password from compteAdmin where login=@login";
            string query2 = "update compteAdmin set password=@password where login = @login2";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                object obj;
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@login", (string)Session["Username"]);
                    obj=command.ExecuteScalar();
                }
                using (MySqlCommand command = new MySqlCommand(query2, connection))
                {
                    command.Parameters.AddWithValue("@password", Class1.HashPassword(TextBoxNewPassword.Text));
                    command.Parameters.AddWithValue("@login2", (string)Session["Username"]);
                    if (obj.ToString() == Class1.HashPassword(TextBoxPassword.Text))
                    {
                        command.ExecuteNonQuery();
                        LabelMAJ.Visible = true;
                        PanelCompteAdministrateur.Visible = false;
                    }
                    else
                    {
                        lblErrorMessage0.Visible = true;
                    }
                }
                connection.Close();
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            PanelInformations.Visible = false;
            PanelModifierMotDePasse.Visible = true;
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
            string query = "select motDePasse from enseignant where matricule=@login";
            string query2 = "update enseignant set motDePasse=@password where matricule = @login2";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                object obj;
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@login", (string)Session["Username"]);
                    obj = command.ExecuteScalar();
                }
                using (MySqlCommand command = new MySqlCommand(query2, connection))
                {
                    command.Parameters.AddWithValue("@password", Class1.HashPassword(TextBoxNewPassword0.Text));
                    command.Parameters.AddWithValue("@login2", (string)Session["Username"]);
                    if (obj.ToString() == Class1.HashPassword(TextBoxPassword0.Text))
                    {
                        command.ExecuteNonQuery();
                        LabelMAJ.Visible = true;
                        PanelModifierMotDePasse.Visible = false;
                    }
                    else
                    {
                        PanelInformations.Visible=false;
                        PanelModifierMotDePasse.Visible=true;
                        lblErrorMessage1.Visible = true;
                    }
                }
                connection.Close();
            }
        }

        
    }
}