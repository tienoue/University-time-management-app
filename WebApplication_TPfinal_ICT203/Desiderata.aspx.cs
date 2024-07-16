using MySql.Data.MySqlClient;
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
    public partial class Desiderata : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            labelSuccess.Visible = false;


            using (MySqlConnection connexion = new MySqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString))
            {
                string query6 = "select * from programmation where nomEnseignant=(select nom from enseignant where matricule='" + Session["Username"] + "')";

                connexion.Open();
                using (MySqlCommand cmd = new MySqlCommand(query6))
                {
                    cmd.Connection = connexion;
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        GridView2.DataSource = dataTable;
                        GridView2.DataBind();
                    }
                }
                connexion.Close();
            }



            string connectionString = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query2 = "SELECT * FROM desiderata where matriculeEnseignant='" + Session["Username"] +"'";
                string query3 = "SELECT code from ue where matriculeEnseignant='" + Session["Username"] +"' order by code asc";
                string query4 = "SELECT heureDebut from programmation where nomEnseignant=(select nom from enseignant where matricule='" + Session["Username"] + "') order by heureDebut asc";
                string query5 = "SELECT datePassage from programmation where nomEnseignant=(select nom from enseignant where matricule='" + Session["Username"] + "') order by datePassage asc";



                using (MySqlCommand command2 = new MySqlCommand(query2, connection))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command2))
                    {
                        DataTable datatable = new DataTable();
                        adapter.Fill(datatable);
                        GridView1.DataSource = datatable;
                        GridView1.DataBind();
                    }
                }
                using (MySqlCommand command2 = new MySqlCommand(query3, connection))
                {
                    using (MySqlDataReader reader = command2.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string code = reader.GetString("code");
                            ue.Items.Add(code);
                        }
                    }
                }
                using (MySqlCommand command2 = new MySqlCommand(query4, connection))
                {
                    using (MySqlDataReader reader = command2.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TimeSpan code = reader.GetTimeSpan("heureDebut");
                            ancienneHeure.Items.Add(code.ToString());
                        }
                    }
                }
                using (MySqlCommand command2 = new MySqlCommand(query5, connection))
                {
                    using (MySqlDataReader reader = command2.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DateTime code = reader.GetDateTime("datePassage");
                            ancienneDate.Items.Add(code.ToString());
                        }
                    }
                }
                connection.Close();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "insert into desiderata(heureDebut,heureFin,dateDePassage,dateEnvoi,heureEnvoi,codeUE,matriculeEnseignant, ancienneHeureDebut, ancienneDateDePassage) values(@v1, @v2, @v3, @v4, @v5, @v6, @v7, @v8, @v9)";
                string query2 = "insert into desiderata2(heureDebut,heureFin,dateDePassage,dateEnvoi,heureEnvoi,codeUE,matriculeEnseignant, ancienneHeureDebut, ancienneDateDePassage) values(@v1, @v2, @v3, @v4, @v5, @v6, @v7, @v8, @v9)";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@v1", heureDebut.Text);
                    command.Parameters.AddWithValue("@v2", heureFin.Text);
                    command.Parameters.AddWithValue("@v3", DateTime.Parse(date.Text));
                    command.Parameters.AddWithValue("@v4", DateTime.Now);
                    command.Parameters.AddWithValue("@v5", DateTime.Now.ToString("HH:mm"));
                    command.Parameters.AddWithValue("@v6", ue.SelectedValue);
                    command.Parameters.AddWithValue("@v7", Session["Username"]);
                    command.Parameters.AddWithValue("@v8", ancienneHeure.SelectedValue);
                    command.Parameters.AddWithValue("@v9", DateTime.Parse(ancienneDate.SelectedValue));
                    //command.Parameters.AddWithValue("@v9", ancienneDate.SelectedValue.Substring(0,10));

                    command.ExecuteNonQuery();
                    /*date.Text = null;
                    heureDebut.Text = null;
                    heureFin.Text = null;*/
                }
                using (MySqlCommand command = new MySqlCommand(query2, connection))
                {
                    command.Parameters.AddWithValue("@v1", heureDebut.Text);
                    command.Parameters.AddWithValue("@v2", heureFin.Text);
                    command.Parameters.AddWithValue("@v3", DateTime.Parse(date.Text));
                    command.Parameters.AddWithValue("@v4", DateTime.Now);
                    command.Parameters.AddWithValue("@v5", DateTime.Now.ToString("HH:mm"));
                    command.Parameters.AddWithValue("@v6", ue.SelectedValue);
                    command.Parameters.AddWithValue("@v7", Session["Username"]);
                    command.Parameters.AddWithValue("@v8", ancienneHeure.SelectedValue);
                    command.Parameters.AddWithValue("@v9", DateTime.Parse(ancienneDate.SelectedValue));

                    command.ExecuteNonQuery();
                    Response.Redirect("Desiderata.aspx");
                }
                connection.Close() ;
            }
        }
    }
}