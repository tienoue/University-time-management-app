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
    public partial class Programmer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                datecours.Attributes["min"] = DateTime.Now.ToString("jj/mm/aaaa");

                using (MySqlConnection connexion = new MySqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString))
                {
                    string query = "SELECT matricule FROM enseignant ";
                    string query1 = "SELECT code FROM ue ";
                    string query2 = "SELECT nomFiliere FROM filiere ";
                    string query3 = "SELECT code  FROM niveau ";
                    string query4 = "SELECT code FROM salle ";
                    connexion.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query1))
                    {
                        cmd.Connection = connexion;

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            UE.DataSource = reader;
                            UE.DataTextField = "code";
                            UE.DataBind();
                        }
                    }
                    using (MySqlCommand cmd = new MySqlCommand(query4))
                    {
                        cmd.Connection = connexion;

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            Salle.DataSource = reader;
                            Salle.DataTextField = "code";
                            Salle.DataBind();
                        }
                    }
                    connexion.Close();
                }
            }
        }



        protected void Enregistrer(object sender, EventArgs e)
        {
            DateTime dateCour = DateTime.Parse(datecours.Text);
            DateTime delaimodification = DateTime.Parse(modification.Text);
            DateTime deuxjoursavant = dateCour.AddDays(-2);
            TimeSpan heureDebut = TimeSpan.Parse(heuredebut.Text);
            TimeSpan heureFin = TimeSpan.Parse(heurefin.Text);
            //string prof = ddldata.SelectedValue;
            string filiere = "";
            string ue = UE.SelectedValue;
            string salle = Salle.SelectedValue;
            string niveau = "";
            int semestre = 1;
            string nom = "";

            using (MySqlConnection connexion = new MySqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString))
            {
                string query5 = "select filiere from ue where code=@c";
                string query4 = "select niveau from ue where code=@c";
                string query3 = "select semestre from ue where code=@c";
                string query2 = "select nom from enseignant where matricule like (select matriculeEnseignant from ue where code=@code)";
                string query = "INSERT INTO programmation (datePassage,heureDebut,heureFin,delaiModification, nomEnseignant,codeUE,codeNiveau,nomFiliere,codeSalle, semestre, genre) VALUES (@datecours,@heuredebut,@heurefin,@delaimodification,@nomEnseignant,@codeUe,@codeniveau,@nomfiliere,@codesalle, @semestre, @genre)";
                using(MySqlCommand command =new MySqlCommand(query2, connexion))
                {
                    connexion.Open();
                    command.Parameters.AddWithValue("@code", ue);
                    nom=command.ExecuteScalar().ToString();
                    connexion.Close();
                }
                using (MySqlCommand command = new MySqlCommand(query3, connexion))
                {
                    connexion.Open();
                    command.Parameters.AddWithValue("@c", ue);
                    semestre =Convert.ToInt32( command.ExecuteScalar());
                    connexion.Close();
                }
                using (MySqlCommand command = new MySqlCommand(query4, connexion))
                {
                    connexion.Open();
                    command.Parameters.AddWithValue("@c", ue);
                    niveau = command.ExecuteScalar().ToString();
                    connexion.Close();
                }
                using (MySqlCommand command = new MySqlCommand(query5, connexion))
                {
                    connexion.Open();
                    command.Parameters.AddWithValue("@c", ue);
                    filiere = command.ExecuteScalar().ToString();
                    connexion.Close();
                }
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = connexion;

                    cmd.Parameters.AddWithValue("@codeUe", ue);
                    cmd.Parameters.AddWithValue("@nomEnseignant", nom);
                    cmd.Parameters.AddWithValue("@codeniveau", niveau);
                    cmd.Parameters.AddWithValue("@nomfiliere", filiere);
                    cmd.Parameters.AddWithValue("@codesalle", salle);
                    cmd.Parameters.AddWithValue("@datecours", dateCour);
                    cmd.Parameters.AddWithValue("@delaimodification", delaimodification);
                    cmd.Parameters.AddWithValue("@heuredebut", heureDebut);
                    cmd.Parameters.AddWithValue("@heurefin", heureFin);
                    cmd.Parameters.AddWithValue("@semestre", semestre);
                    cmd.Parameters.AddWithValue("@genre", DropDownListType.SelectedValue);

                    connexion.Open();
                    cmd.ExecuteNonQuery();
                    string script = "alert ('Programmation Enregistree avec Success')";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", script, true);
                    UE.SelectedIndex = 0;
                    Salle.SelectedIndex = 0;
                    datecours.Text = "";
                    heuredebut.Text = "";
                    modification.Text = "";
                    heurefin.Text = "";

                }

            }

        }
    }
}