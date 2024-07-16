using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication_TPfinal_ICT203
{
    public class desiderata
    {
        public TimeSpan heureDebut;
        public TimeSpan heureFin;
        public DateTime dateDePassage;
        public DateTime dateEnvoi;
        public TimeSpan heureEnvoi;
        public string codeUE;
        public string matriculeEnseignant;

        public desiderata()
        {
        }
        public desiderata(TimeSpan heureDebut, TimeSpan heureFin, DateTime dateDePassage, DateTime dateEnvoi, TimeSpan heureEnvoi, string codeUE, string matriculeEnseignant)
        {
            this.heureDebut = heureDebut;
            this.heureFin = heureFin;
            this.dateDePassage = dateDePassage;
            this.dateEnvoi = dateEnvoi;
            this.heureEnvoi = heureEnvoi;
            this.codeUE = codeUE;
            this.matriculeEnseignant = matriculeEnseignant;
        }
    }
}