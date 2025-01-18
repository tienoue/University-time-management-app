using MySql.Data.MySqlClient;
using OpenQA.Selenium;
using System;
using System.Collections;
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
    public partial class ModifierProgrammation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //GridView1.RowDataBound += GridView1_RowDataBound;
            using (MySqlConnection connexion = new MySqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString))
            {
                string query5 = "SELECT id FROM programmation order by id";
                string query6 = "select * from programmation order by id";

                connexion.Open();
                using(MySqlCommand command = new MySqlCommand(query5, connexion))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int ID = reader.GetInt32("id");

                            HtmlGenericControl listItem = new HtmlGenericControl("li");
                            //listItem.InnerText = codeUE;
                            listItem.Style["color"] = "white";
                            listItem.Style["font-size"] = "20.6px";
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
                            bouton_supprimer.Click += (buttonSender, buttonEvent) => Supprimer_Click(buttonSender, buttonEvent, ID.ToString()); // Associer l'événement de clic et passer le texte en paramètre

                            // Ajouter les boutons à l'élément <li>
                            //listItem.Controls.Add(bouton_ouvrir);
                            listItem.Controls.Add(bouton_supprimer);

                            myList.Style.Add("position", "absolute");
                            myList.Controls.Add(listItem);
                        }
                    }
                }
                using (MySqlCommand cmd = new MySqlCommand(query5))
                {
                    cmd.Connection = connexion;
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int ID = reader.GetInt32("id");
                            dropdownListId.Items.Add(ID.ToString());
                        }
                    }
                }
                using (MySqlCommand cmd = new MySqlCommand(query6))
                {
                    cmd.Connection = connexion;
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        GridView1.DataSource = dataTable;
                        GridView1.DataBind();
                    }
                }
                connexion.Close();
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)// pour raccourcir le contenu de la colonne 1 (des libelles) avant de l'afficher. 
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Récupérer la valeur de la colonne souhaitée
                string valeurOriginale = e.Row.Cells[1].Text;
                string valeurOriginale2 = e.Row.Cells[4].Text;

                // Modifier la valeur selon vos besoins
                string nouvelleValeur = valeurOriginale.Substring(0, 10);
                string nouvelleValeur2 = valeurOriginale2.Substring(0, 10);

                // Assigner la nouvelle valeur à la colonne
                e.Row.Cells[1].Text = nouvelleValeur;
                e.Row.Cells[4].Text = nouvelleValeur2;
            }
        }

        protected void Supprimer_Click(object sender, EventArgs e, string ID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
            string query = "delete from programmation where id=" + ID+"";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                    Response.Redirect("ModifierProgrammation.aspx");
                }
                connection.Close();
            }
        }

        protected void Modifier(object sender, EventArgs e)
        {
            DateTime dateCour = DateTime.Parse(datemodifie.Text);
            TimeSpan heureDebut = TimeSpan.Parse(heuredebutmodifie.Text);
            TimeSpan heureFin = TimeSpan.Parse(heurefinmodifie.Text);
            //string idP = dropdownListId.SelectedValue;


            using (MySqlConnection connexion = new MySqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString))
            {
                connexion.Open();
                string query = "UPDATE  programmation SET datePassage= @datecours,heureDebut=@heuredebut,heureFin =@heurefin WHERE id=@idP;";
                using (MySqlCommand cmde = new MySqlCommand(query,connexion))
                {
                    cmde.Parameters.AddWithValue("@idP", int.Parse(dropdownListId.SelectedValue));
                    cmde.Parameters.AddWithValue("@datecours", dateCour);
                    cmde.Parameters.AddWithValue("@heuredebut", heureDebut);
                    cmde.Parameters.AddWithValue("@heurefin", heureFin);

                    
                    int rowsAffected = cmde.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Response.Redirect("ModifierProgrammation.aspx");
                        string scripte = "alert ('Modification Enregistree avec Success')";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", scripte, true);
                        dropdownListId.SelectedValue = "";
                        datemodifie.Text = "";
                        heuredebutmodifie.Text = "";
                        heurefinmodifie.Text = "";
                    }
                    else
                    {
                        string scrip = "alert ('Erreur lors de la modification')";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", scrip, true);

                    }

                }
                connexion.Close();
            }
        }
    }
}
