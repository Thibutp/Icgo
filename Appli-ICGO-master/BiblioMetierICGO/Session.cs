using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace BiblioMetierICGO
{
    public class Session
    {
        #region Attributs privés
        private Competence competence; 
        private int numSession;
        private DateTime dateSession;
        private Stage leStage;
        private Formateur leFormateur;
        private string nomAgence; 
        private List<Stagiaire> lesStagiaires;
        #endregion

        #region Constructeurs
        public Session ()
        {
            lesStagiaires = new List<Stagiaire>();
        }

        public Session (int numSession, DateTime dateSession, Stage leStage, Formateur leFormateur, string nomAgence)
        {
            this.numSession = numSession;
            this.dateSession = dateSession;
            this.leStage = leStage;
            this.leFormateur = leFormateur;
            this.nomAgence = nomAgence;
        }

        public Session(Competence competence, int numSession, DateTime dateSession, Stage leStage, Formateur leFormateur, string nomAgence)
        {
            this.competence = competence;
            this.numSession = numSession;
            this.dateSession = dateSession;
            this.leStage = leStage;
            this.leFormateur = leFormateur;
            this.nomAgence = nomAgence;
        }

            public Session(Competence competence, int numSession, DateTime dateSession, Stage leStage, Formateur leFormateur, string nomAgence, List<Stagiaire> lesStagiaires)
        {
            this.competence = competence;
            this.numSession = numSession;
            this.dateSession = dateSession;
            this.leStage = leStage;
            this.leFormateur = leFormateur;
            this.nomAgence = nomAgence; 
            this.lesStagiaires = lesStagiaires;
        }
        #endregion

        #region Accesseurs

        public Competence getCompetence()
        {
            return competence;
        }

        public int GetNumSession()
        {
            return numSession;
        }

        public void SetNumSession(int value)
        {
            numSession = value;
        }

        public DateTime GetDateSession()
        {
            return dateSession;
        }

        public void SetDateSession(DateTime value)
        {
            dateSession = value;    
        }

        public Stage GetLeStage()
        {
            return leStage;
        }

        public void SetLeStage(Stage value)
        {
            leStage = value;
        }

        public string GetNomAgence()
        {
            return nomAgence;
        }

        public void SetNomAgence(string value)
        {
            nomAgence = value;
        }

        public Formateur GetLeFormateur()
        {
            return leFormateur;
        }

        public void SetLeFormateur(Formateur value)
        {
            leFormateur = value;
        }

        public List<Stagiaire> GetLesStagiaires()
        {
            return lesStagiaires;
        }

        public void SetLesStagiaires(List<Stagiaire> value)
        {
            lesStagiaires = value;
        }

        #endregion
    }
}
