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
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT nomFiliere from filiere order by nomFiliere asc";
                string query2 = "SELECT code from niveau order by code asc";
                string query3 = "SELECT nom from enseignant order by nom asc";
                string query4 = "SELECT code from salle order by code asc";
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DropDownListFiliere.Items.Add(reader["nomFiliere"].ToString());
                        }
                    }
                }
                using (MySqlCommand command = new MySqlCommand(query2, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DropDownListNiveau.Items.Add(reader["code"].ToString());
                        }
                    }
                }
                using (MySqlCommand command = new MySqlCommand(query3, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DropDownListEnseignant.Items.Add(reader["nom"].ToString());
                        }
                    }
                }
                using (MySqlCommand command = new MySqlCommand(query4, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DropDownListSalle.Items.Add(reader["code"].ToString());
                        }
                    }
                }
                connection.Close();
            }



            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT heureDebut, heureFin, codeUE,nomEnseignant,codeSalle, datePassage from programmation where genre='" + Class1.type + "' and semestre=" + Class1.semestre + " and nomFiliere='" + Class1.filiere + "' and codeNiveau='" + Class1.niveau + "'";
                if (Class1.enseignant != "Tous les enseignants")
                {
                    query = query + " and nomEnseignant='" + Class1.enseignant + "'";
                }
                if (Class1.salle != "Toutes les salles")
                {
                    query = query + " and codeSalle='" + Class1.salle + "'";
                }
                query = query + " order by heureDebut asc";
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TimeSpan heureDebut = reader.GetTimeSpan("heureDebut");
                            TimeSpan heureFin = reader.GetTimeSpan("heureFin");
                            string codeUE = reader.GetString("codeUE");
                            string nomEnseignant = reader.GetString("nomEnseignant");
                            string codeSalle = reader.GetString("codeSalle");
                            DateTime datePassage = reader.GetDateTime("datePassage");

                            LinkButton panelProgrammation = new LinkButton();
                            /*panelProgrammation.Style.Add("height", "200px");*/
                            panelProgrammation.Style.Add("position", "relative");
                            //panelProgrammation.Style.Add("left", "-100px");
                            panelProgrammation.Style.Add("width", "100%");
                            panelProgrammation.Style.Add("margin-left", "auto");
                            panelProgrammation.Style.Add("margin-right", "auto");
                            //panelProgrammation.Style.Add("background-color", "red");
                            //panelProgrammation.Width = 210;
                            panelProgrammation.Height = 50;
                            panelProgrammation.CssClass = "panelProgrammation";
                            //panelProgrammation.Click += ClickablePanel_Click;

                            Label labelCodeUE = new Label();
                            labelCodeUE.Text = "<br>" + codeUE + "<br>";
                            labelCodeUE.CssClass = "codeUE";

                            Label labelHeureDebut = new Label();
                            labelHeureDebut.Text = heureDebut.ToString("hh':'mm") + "-";
                            labelHeureDebut.CssClass = "element";

                            Label labelHeureFin = new Label();
                            labelHeureFin.Text = heureFin.ToString("hh':'mm") + "<br>";
                            labelHeureFin.CssClass = "element";

                            Label labelNomEnseignant = new Label();
                            labelNomEnseignant.Text = "M." + nomEnseignant;
                            labelNomEnseignant.CssClass = "element";

                            Label labelCodeSalle = new Label();
                            labelCodeSalle.Text = "<br>" + codeSalle;
                            labelCodeSalle.CssClass = "element";

                            Label labelDatePassage = new Label();
                            labelDatePassage.Text = "<br>" + datePassage.ToString("dd/MM/yyyy");
                            labelDatePassage.CssClass = "element";

                            HtmlGenericControl listItem = new HtmlGenericControl("hr");
                            listItem.Style.Add("position", "absolute%");
                            listItem.Style.Add("bottom", "0");
                            listItem.Style.Add("width", "100%");
                            listItem.Style.Add("color", "black");


                            panelProgrammation.Controls.Add(labelCodeUE);
                            panelProgrammation.Controls.Add(labelHeureDebut);
                            panelProgrammation.Controls.Add(labelHeureFin);
                            panelProgrammation.Controls.Add(labelNomEnseignant);
                            panelProgrammation.Controls.Add(labelCodeSalle);
                            panelProgrammation.Controls.Add(labelDatePassage);
                            panelProgrammation.Controls.Add(listItem);

                            string jourDeLaSemaine = datePassage.DayOfWeek.ToString();
                            if (jourDeLaSemaine == "Monday")
                                lundi.Controls.Add(panelProgrammation);
                            else if (jourDeLaSemaine == "Tuesday")
                                mardi.Controls.Add(panelProgrammation);
                            else if (jourDeLaSemaine == "Wednesday")
                                mercredi.Controls.Add(panelProgrammation);
                            else if (jourDeLaSemaine == "Thursday")
                                jeudi.Controls.Add(panelProgrammation);
                            else if (jourDeLaSemaine == "Friday")
                                vendredi.Controls.Add(panelProgrammation);
                        }
                    }
                }
                connection.Close();
            }

            if (!IsPostBack)
            {
                DropDownListType.SelectedValue = Class1.type;
                DropDownListSemestre.SelectedValue = Class1.semestre + "";
                DropDownListFiliere.SelectedValue = Class1.filiere;
                DropDownListNiveau.SelectedValue = Class1.niveau;
                DropDownListEnseignant.SelectedValue = Class1.enseignant;
                DropDownListSalle.SelectedValue = Class1.salle;
            }
        }

        protected void DropDownListSemestre_SelectedIndexChanged(object sender, EventArgs e)
        {
            string semestre = DropDownListSemestre.SelectedValue;
            bool b = int.TryParse(semestre, out Class1.semestre);
            //Class1.semestre=int.Parse(semestre);
            Response.Redirect("Default.aspx");
        }

        protected void DropDownListFiliere_SelectedIndexChanged(object sender, EventArgs e)
        {
            Class1.filiere = DropDownListFiliere.SelectedValue;
            Response.Redirect("Default.aspx");
        }

        protected void DropDownListNiveau_SelectedIndexChanged(object sender, EventArgs e)
        {
            Class1.niveau = DropDownListNiveau.SelectedValue;
            Response.Redirect("Default.aspx");
        }

        protected void DropDownListEnseignant_SelectedIndexChanged(object sender, EventArgs e)
        {
            Class1.enseignant = DropDownListEnseignant.SelectedValue;
            Response.Redirect("Default.aspx");
        }

        protected void DropDownListSalle_SelectedIndexChanged(object sender, EventArgs e)
        {
            Class1.salle = DropDownListSalle.SelectedValue;
            Response.Redirect("Default.aspx");
        }

        protected void DropDownListType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Class1.type = DropDownListType.SelectedValue;
            Response.Redirect("Default.aspx");
        }
    }
}