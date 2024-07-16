using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WebApplication_TPfinal_ICT203
{
    public partial class UE : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.RowDataBound += GridView1_RowDataBound;
            if (!IsPostBack)
            {
                /*// Connexion à la base de données
                string connectionString = "Data Source=JUNIOR\\SQLEXPRESS;Initial Catalog=ICT2050;Integrated Security=True;";
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                // Requête SQL pour récupérer les données
                string query = "SELECT poste FROM PostesSet";
                SqlCommand command = new SqlCommand(query, connection);

                // Création d'un DataReader pour lire les données
                SqlDataReader reader = command.ExecuteReader();

                // Remplissage du DropDownList avec les données du DataReader
                while (reader.Read())
                {
                    DropDownList1.Items.Add(reader["poste"].ToString());
                }

                // Fermeture du DataReader et de la connexion à la base de données
                reader.Close();
                connection.Close();*/
            }



            string connectionString = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT code from ue order by code asc";
                string query2 = "SELECT * FROM ue order by code asc";
                string query3 = "SELECT matricule, nom FROM enseignant order by nom asc";
                string query4 = "SELECT code FROM niveau order by code asc";
                string query5 = "SELECT nomFiliere FROM filiere order by nomFiliere asc";
                MySqlCommand command = new MySqlCommand(query, connection);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string codeUE = reader.GetString("code");

                        HtmlGenericControl listItem = new HtmlGenericControl("li");
                        //listItem.InnerText = codeUE;
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
                        bouton_supprimer.Click += (buttonSender, buttonEvent) => Supprimer_Click(buttonSender, buttonEvent, codeUE); // Associer l'événement de clic et passer le texte en paramètre

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

                        //GridView1.Columns["libelle"].Visible = false;
                    }
                }
                using (MySqlCommand command2 = new MySqlCommand(query3, connection))
                {
                    using (MySqlDataReader reader = command2.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string matricule = reader.GetString("matricule");
                            string nom = reader.GetString("nom");
                            string chaine=nom+" ("+matricule+")";


                            DropDownListMatricule.Items.Add(chaine);
                        }
                    }
                }
                using (MySqlCommand command2 = new MySqlCommand(query4, connection))
                {
                    using (MySqlDataReader reader = command2.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string niveau = reader.GetString("code");
                            DropDownListNiveau.Items.Add(niveau);
                        }
                    }
                }
                using (MySqlCommand command2 = new MySqlCommand(query5, connection))
                {
                    using (MySqlDataReader reader = command2.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string filiere = reader.GetString("nomFiliere");
                            DropDownListFiliere.Items.Add(filiere);
                        }
                    }
                }
                connection.Close();
            }
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)// pour raccourcir le contenu de la colonne 1 (des libelles) avant de l'afficher. 
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Récupérer la valeur de la colonne souhaitée
                string valeurOriginale = e.Row.Cells[1].Text;

                // Modifier la valeur selon vos besoins
                string nouvelleValeur = valeurOriginale.Substring(0,8)+"...";

                // Assigner la nouvelle valeur à la colonne
                e.Row.Cells[1].Text = nouvelleValeur;
            }
        }
        protected void Supprimer_Click(object sender, EventArgs e, string codeUE)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
            string query = "delete from ue where code like '" + codeUE + "'";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                    Response.Redirect("UE.aspx");
                }
                connection.Close();
            }
        }

        protected void Enregistrer_Click(object sender, EventArgs e)
        {
            string chaine = DropDownListMatricule.Text;
            int premiereParenthese = 0;
            int deuxiemeParenthese = 0;
            for (int i=0; i<chaine.Length;i++)
            {
                if ( chaine.Substring(i,1)== "(")
                {
                    premiereParenthese=i;
                }
                if (chaine.Substring(i, 1) == ")")
                {
                    deuxiemeParenthese = i;
                }
            }
            chaine = chaine.Substring(premiereParenthese + 1, deuxiemeParenthese-premiereParenthese-1);

            string connectionString = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
            string query = "insert into ue() values(@v1,@v2,@v3,@v4,@v5, @v6, @v7)";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@v1", textboxCode.Text);
                    command.Parameters.AddWithValue("@v2", textboxLibelle.Text);
                    command.Parameters.AddWithValue("@v3", textboxNombreDHeures.Text);
                    command.Parameters.AddWithValue("@v4", DropDownListSemestre.Text);
                    command.Parameters.AddWithValue("@v5", chaine);
                    command.Parameters.AddWithValue("@v6", DropDownListFiliere.SelectedValue);
                    command.Parameters.AddWithValue("@v7", DropDownListNiveau.SelectedValue);
                    command.ExecuteNonQuery();
                    Response.Redirect("UE.aspx");
                }
                connection.Close();
            }
        }
    }
}