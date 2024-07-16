using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;

namespace WebApplication_TPfinal_ICT203
{
    public class Class1
    {

        public static string departementActuel = "";

        public static string type="";
        public static int semestre;
        public static string filiere = "";
        public static string niveau = "";
        public static string enseignant = "Tous les enseignants";
        public static string salle = "Toutes les salles";
        public static string matriculeEnseignant="";

        public static int nombreDesideratas = 0;
        public static int nombreMessages = 0;

        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}