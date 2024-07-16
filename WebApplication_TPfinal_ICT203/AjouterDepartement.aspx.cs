using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication_TPfinal_ICT203
{
    public partial class AjouterDepartement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            // Récupérer le conteneur parent
            //Panel fileUploadPanel = (Panel)FindControl("fileUploadPanel");

            // Récupérer le contrôle de champ de fichier à partir du conteneur parent
            /*FileUpload imageFile = (FileUpload)fileUploadPanel.FindControl("imageFile");

            if (imageFile.HasFile)
            {
                string fileName = Path.GetFileName(imageFile.FileName);
                string uniqueFileName = fileName;
                string filePath = Server.MapPath("~/Images/") + uniqueFileName;
                int counter = 1;
                while (File.Exists(filePath))
                {
                    string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
                    string fileExtension = Path.GetExtension(fileName);
                    uniqueFileName = $"{fileNameWithoutExtension}_{counter}{fileExtension}";
                    filePath = Server.MapPath("~/Images/") + uniqueFileName;
                    counter++;
                }

                imageFile.SaveAs(filePath);

                // Enregistrer le chemin de l'image dans la base de données
                string cheminImage = "/Images/" + uniqueFileName; // Chemin relatif de l'image dans votre application

                using (SqlConnection connection = new SqlConnection("Votre chaîne de connexion à la base de données"))
                {
                    connection.Open();
                    string query = "INSERT INTO departement (nomDepartement, cheminImage) VALUES (@nomDepartement, @cheminImage)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@nomDepartement", textboxMatricule.Text);
                    command.Parameters.AddWithValue("@cheminImage", cheminImage);
                    command.ExecuteNonQuery();
                }

                Response.Redirect("Departement.aspx");
            }*/

            /*if (Request.Files.Count > 0)
            {
                HttpPostedFile postedFile = Request.Files[0]; // Accéder au premier fichier téléchargé

                if (postedFile != null && postedFile.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(postedFile.FileName);

                    // Votre logique pour gérer le nom de fichier en cas de conflit

                    string filePath = Server.MapPath("~/Images/") + fileName;
                    postedFile.SaveAs(filePath);

                    
                    // Enregistrer le chemin de l'image dans la base de données
                    string cheminImage = "/Images/" + fileName; // Chemin relatif de l'image dans votre application

                    using (SqlConnection connection = new SqlConnection("Votre chaîne de connexion à la base de données"))
                    {
                        connection.Open();
                        string query = "INSERT INTO departement (nomDepartement, cheminImage) VALUES (@nomDepartement, @cheminImage)";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@nomDepartement", textboxMatricule.Text);
                        command.Parameters.AddWithValue("@cheminImage", cheminImage);
                        command.ExecuteNonQuery();
                    }

                    Response.Redirect("Departement.aspx");
                }
            }*/

            // Vérifier si un fichier a été sélectionné
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
                    string query = "INSERT INTO departement (nomDepartement, image) VALUES (@FileName, @FileContent)";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@FileName", textboxNomDepartement.Text);
                    command.Parameters.AddWithValue("@FileContent", fileBytes);
                    command.ExecuteNonQuery();
                    Response.Redirect("Departements.aspx");
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
    }
}