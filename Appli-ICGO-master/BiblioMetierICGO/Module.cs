using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioMetierICGO
{
    public class Module
    {

        #region Attributs privés

        private int numModule;
        private string nomModule;
        private string nomSupportCours;
        private string nomPresentation;
        private string placeSupportCours;
        private string placePresentation;
        private List<Stage> lesStages;

        #endregion

        #region Accesseurs
        public int GetNumModule()
        {
            return numModule;
        }
        public void SetNumModule(int value)
        {
            this.numModule = value;
        }
       
        public string GetNomModule()
        {
            return nomModule;
        }
        public void SetNomModule(string value)
        {
            nomModule = value;
        }
        public string GetNomSupportCours()
        {
            return nomSupportCours;
        }
        public void SetNomSupportCours(string value)
        {
            nomSupportCours = value;
        }
        public string GetNomPresentation()
        {
            return nomPresentation;
        }
        public void SetNomPresentation(string value)
        {
            nomPresentation = value;
        }
        public string GetPlaceSupportCours()
        {
            return placeSupportCours;   
        }
        public void SetPlaceSupportCours(string value)
        {
            placeSupportCours = value;
        }
        public string GetPlacePresentation()
        {
            return placePresentation;
        }

        public void SetPlacePresentation(string value)
        {
            placePresentation = value;
        }
        public List<Stage> GetLesStages()
        {
            return lesStages;
        }
        public void SetLesStages(List<Stage> value)
        {
            lesStages = value;
        }




        #endregion

        #region Constructeurs

        public Module()
        {
            lesStages = new List<Stage>();
        }
       
        public Module(int numModule, string nomModule, string nomSupportCours, string nomPresentation, string placeSupportCours, string placePresentation)
        {
            this.numModule = numModule;
            this.nomModule = nomModule;
            this.nomSupportCours=nomSupportCours;
            this.nomPresentation = nomPresentation;
            this.placePresentation = placePresentation;
            this.placeSupportCours = placeSupportCours;

        }

        public Module (int numModule, string nomModule, string nomSupportCours, string nomPresentation, string placeSupportCours, string placePresentation, List<Stage> lesStages)
        {
            
            this.numModule = numModule;
            this.nomModule = nomModule;
            this.nomSupportCours = nomSupportCours;
            this.nomPresentation = nomPresentation;
            this.placeSupportCours = placeSupportCours;
            this.placePresentation = placePresentation;
            this.lesStages = lesStages;
        }




        #endregion

        



        

    }
}
