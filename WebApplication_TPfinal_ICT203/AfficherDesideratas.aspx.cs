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
    public partial class AfficherDesideratas : System.Web.UI.Page
    {
        /*protected void Page_Load(object sender, EventArgs e)
        {
            BindGridView();
            if (!IsPostBack)
            {
                using (MySqlConnection connexion = new MySqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString))
                {
                    string query = "SELECT id FROM desiderata order by id asc ";
                    using (MySqlCommand cmd = new MySqlCommand(query))
                    {
                        connexion.Open();
                        cmd.Connection = connexion;

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            id.DataSource = reader;
                            id.DataTextField = "id";
                            id.DataBind();

                        }

                    }
                }
            }

        }
        protected void accepter(object sender, EventArgs e)
        {
            DateTime date=DateTime.Now;
            TimeSpan heuredebut=TimeSpan.Zero;
            TimeSpan heurefin=TimeSpan.Zero;
            DateTime anciennedatepassage=DateTime.Now;
            TimeSpan ancienneheuredebut = TimeSpan.Zero;

            string idD = id.SelectedValue;
            string query = "SELECT heureDebut,heureFin,dateDePassage ,AncienneHeureDebut , AncienneDateDePassage FROM desiderata WHERE id=@idP";
            string query2 = "UPDATE programmation SET datePassage=@date ,heureDebut=@debut,heureFin=@fin WHERE datePassage=@anciennedate AND heureDebut=@ancienneHeuredebut  ";
            string query3 = " DELETE FROM desiderata WHERE id=@idD  ";


            using (MySqlConnection connexion = new MySqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString))
            {
                connexion.Open();

                using (MySqlCommand cmd = new MySqlCommand(query, connexion))
                {
                    cmd.Parameters.AddWithValue("@idP", idD);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            date = Convert.ToDateTime(reader["dateDePassage"]);
                            heuredebut = TimeSpan.Parse(reader["heureDebut"].ToString());
                            heurefin = TimeSpan.Parse(reader["heureFin"].ToString());
                            anciennedatepassage = Convert.ToDateTime(reader["AncienneDateDePassage"]);
                            ancienneheuredebut = TimeSpan.Parse(reader["AncienneHeureDebut"].ToString());
                        }
                        reader.Close();

                        //mettre a jour les valeurs dans la table programmation

                        
                        using (MySqlCommand cmde = new MySqlCommand(query2, connexion))
                        {
                            //connexion2.Open();
                            cmde.Parameters.AddWithValue("@date", date);
                            cmde.Parameters.AddWithValue("@debut", heuredebut);
                            cmde.Parameters.AddWithValue("@fin", heurefin);
                            cmde.Parameters.AddWithValue("@anciennedate", anciennedatepassage);
                            cmde.Parameters.AddWithValue("@ancienneHeuredebut", ancienneheuredebut);

                            int rowsAffected = cmde.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                string scrip = "alert ('Desiderata accepte avec Success ')";
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", scrip, true);

                                //supprimer le desiderata de la BD

                                using (MySqlConnection connexion3 = new MySqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString))
                                {
                                    using (MySqlCommand cmd3 = new MySqlCommand(query3, connexion3))
                                    {
                                        connexion3.Open();
                                        cmd3.Parameters.AddWithValue("@idD", idD);
                                        cmd3.ExecuteNonQuery();
                                                
                                    }
                                    connexion3.Close();
                                }
                                Response.Redirect("AfficherDesideratas.aspx");

                            }
                            else
                            {
                                string scripte = "alert ('Erreur d acceptation ')";
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", scripte, true);
                            }
                        }
                        //connexion2.Close();
                        reader.Close();
                    }
                }
                connexion.Close();
            }
        }
        protected void refuser(object sender, EventArgs e)
        {
            using (MySqlConnection connexion = new MySqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString))
            {
                string idD = id.SelectedValue;
                string query = "DELETE FROM desiderata WHERE id=@idD";
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = connexion;
                    connexion.Open();
                    cmd.Parameters.AddWithValue("@idD", idD);
                    cmd.ExecuteNonQuery();
                    Response.Redirect("AfficherDesideratas.aspx");
                }
            }
        }

        protected void BindGridView()
        {
            using (MySqlConnection connexion = new MySqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString))
            {

                string query = "SELECT * FROM desiderata";
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = connexion;
                    connexion.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        griedview1.DataSource = reader;
                        griedview1.DataBind();
                    }
                    reader.Close();
                }
            }
        }*/

        protected void Page_Load(object sender, EventArgs e)
        {
            BindGridView();
            if (!IsPostBack)
            {
                /*if (Session["Username"] != null)
                {*/
                using (MySqlConnection connexion = new MySqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString))
                {
                    string query = "SELECT id FROM desiderata order by id asc ";
                    string query2 = "update compteadmin set nombreDesideratas=@nombre";

                    connexion.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, connexion))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int ID = reader.GetInt32("id");
                                DropDownListId.Items.Add(ID.ToString());
                            }
                        }

                    }
                    using (MySqlCommand cmd = new MySqlCommand(query2, connexion))
                    {
                        cmd.Parameters.AddWithValue("@nombre", Class1.nombreDesideratas);
                        cmd.ExecuteNonQuery();
                    }
                    connexion.Close();
                }
            }
            /*}
            else
            {
                string scripte = "alert ('Aucun utilisateur connecte ')";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", scripte, true);

            }*/

            //}

        }

        protected void accepter(object sender, EventArgs e)
        {
            DateTime date= DateTime.Now;
            string heureenvoi = DateTime.Now.ToString("HH:mm");//heure actuelle
            DateTime dateenvoi = DateTime.Now;//date actuelle
            TimeSpan heuredebut= TimeSpan.Zero;
            TimeSpan heurefin= TimeSpan.Zero;
            DateTime anciennedatepassage=DateTime.Now;
            TimeSpan ancienneheuredebut = TimeSpan.Zero;
            string matricule;
            int rowsAffected;

            string idD = DropDownListId.SelectedValue;
            /*string scrip = "alert ('"+idD+" ')";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", scrip, true);*/

            string query = "SELECT heureDebut,heureFin,dateDePassage ,AncienneHeureDebut , AncienneDateDePassage FROM desiderata WHERE id=@idP";
            string query2 = "UPDATE programmation set datePassage=@date, heureDebut=@debut, heureFin=@fin WHERE datePassage=@anciennedate AND heureDebut=@ancienneHeuredebut";
            string query3 = "DELETE FROM desiderata WHERE id=@idD";
            string query4 = "insert into message(message,dateEnvoi,heureEnvoi,destinataire) values (@message,@dateEnvoi,@heureEnvoi,@destinataire)";

            using (MySqlConnection connexion = new MySqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString))
            {
                connexion.Open();

                using (MySqlCommand cmd = new MySqlCommand(query, connexion))
                {
                    cmd.Parameters.AddWithValue("@idP", idD);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    /*if (reader.HasRows)
                    {*/
                    while (reader.Read())
                    {
                        date = DateTime.Parse(reader["dateDePassage"].ToString());
                        heuredebut = TimeSpan.Parse(reader["heureDebut"].ToString());
                        heurefin = TimeSpan.Parse(reader["heureFin"].ToString());
                        anciennedatepassage = DateTime.Parse(reader["AncienneDateDePassage"].ToString()); ;
                        ancienneheuredebut = TimeSpan.Parse(reader["AncienneHeureDebut"].ToString()); ;
                    }
                    reader.Close();
                    //mettre a jour les valeurs dans la table programmation
                }
                using (MySqlCommand cmde = new MySqlCommand(query2, connexion))
                {
                    cmde.Parameters.AddWithValue("@date", date);
                    cmde.Parameters.AddWithValue("@debut", heuredebut);
                    cmde.Parameters.AddWithValue("@fin", heurefin);
                    cmde.Parameters.AddWithValue("@anciennedate", anciennedatepassage);
                    cmde.Parameters.AddWithValue("@ancienneHeuredebut", ancienneheuredebut);

                    /*string scrip = "alert ('" + anciennedatepassage + " " + ancienneheuredebut + " " + date + " " + heuredebut + " " + heurefin + " ')";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", scrip, true);*/

                    rowsAffected = cmde.ExecuteNonQuery();

                    
                }
                if (rowsAffected > 0)
                {
                    /*string scrip = "alert ('ma position ')";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", scrip, true);*/
                    string query5 = "select matriculeEnseignant from desiderata  WHERE id=@idP";

                    using (MySqlCommand cmd3 = new MySqlCommand(query5, connexion))
                    {
                        cmd3.Parameters.AddWithValue("@idP", idD);
                        object mat = cmd3.ExecuteScalar();
                        /*if (mat != null)
                        {*/
                        matricule = mat.ToString();
                    }               
                    using (MySqlCommand cmd4 = new MySqlCommand(query4, connexion))
                    {
                        cmd4.Parameters.AddWithValue("@message", "Votre desiderata a ete accepté ");
                        cmd4.Parameters.AddWithValue("@dateEnvoi", dateenvoi);
                        cmd4.Parameters.AddWithValue("@heureEnvoi", heureenvoi);
                        cmd4.Parameters.AddWithValue("@destinataire", matricule);
                        int row = cmd4.ExecuteNonQuery();
                        /*if (row > 0)
                        {
                            string scripte = "alert ('Message  envoyé ')";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", scripte, true);
                        }
                        else
                        {
                            string scripte = "alert ('Message non envoye ')";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", scripte, true);
                        }*/
                    }
                        /*}
                        else
                        {
                            string scripte = "alert ('Message non envoye ')";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", scripte, true);
                        }*/
                    //}
                    using (MySqlCommand cmd3 = new MySqlCommand(query3, connexion))
                    {
                        cmd3.Parameters.AddWithValue("@idD", idD);
                        cmd3.ExecuteNonQuery();
                        Response.Redirect("AfficherDesideratas.aspx");
                    }
                }
                else
                {
                    string scripte = "alert ('Erreur d'acceptation ')";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", scripte, true);
                }
                //}
                        
                    //}
                //}
                connexion.Close();
            }
        }

        protected void refuser(object sender, EventArgs e)
        {
            string heureenvoi = DateTime.Now.ToString("HH:mm");//heure actuelle
            DateTime dateenvoi = DateTime.Now;//date actuelle

            string idD = DropDownListId.SelectedValue;
            string query = "DELETE FROM desiderata WHERE id=@idD";
            string query2 = "select matriculeEnseignant from desiderata  WHERE id=@idP";
            string query3 = "insert into message(message,dateEnvoi,heureEnvoi,matriculeProf,destinataire) values (@message,@dateEnvoi,@heureEnvoi,@matriculeProf,@destinataire)";

            using (MySqlConnection connexion2 = new MySqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString))
            {
                connexion2.Open();
                using (MySqlCommand cmd3 = new MySqlCommand(query2, connexion2))
                {
                    cmd3.Parameters.AddWithValue("@idP", idD);
                    object mat = cmd3.ExecuteScalar();
                    if (mat != null)
                    {
                        string matricule = mat.ToString();
                        using (MySqlConnection connexion4 = new MySqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString))
                        {
                            using (MySqlCommand cmd4 = new MySqlCommand(query3, connexion4))
                            {
                                connexion4.Open();
                                cmd4.Parameters.AddWithValue("@message", "Votre desiderata a ete refuse ");
                                cmd4.Parameters.AddWithValue("@dateEnvoi", dateenvoi);
                                cmd4.Parameters.AddWithValue("@heureEnvoi", heureenvoi);
                                cmd4.Parameters.AddWithValue("@matriculeProf", null);
                                cmd4.Parameters.AddWithValue("@destinataire", matricule);
                                int row = cmd4.ExecuteNonQuery();
                                if (row > 0)
                                {
                                    string scripte = "alert ('Message  envoyé ')";
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", scripte, true);
                                }
                                else
                                {
                                    string scripte = "alert ('Message non envoye ')";
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", scripte, true);
                                }
                                connexion4.Close();
                            }
                        }

                    }
                    else
                    {
                        string scripte = "alert ('Message non envoye ')";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", scripte, true);
                    }

                }


                using (MySqlCommand cmd = new MySqlCommand(query, connexion2))
                {

                    cmd.Parameters.AddWithValue("@idD", idD);
                    cmd.ExecuteNonQuery();
                    Response.Redirect("AfficherDesideratas.aspx");
                }
                connexion2.Close();
            }

        }

        protected void BindGridView()
        {
            using (MySqlConnection connexion = new MySqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString))
            {

                string query = "SELECT * FROM desiderata";
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = connexion;
                    connexion.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        griedview1.DataSource = reader;
                        griedview1.DataBind();
                    }
                    reader.Close();
                }
            }
        }
    }
}