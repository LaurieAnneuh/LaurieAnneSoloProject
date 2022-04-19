using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jeu_de_la_vie.Model;
using System.ComponentModel;
using System.Windows.Input;
using Jeu_de_la_vie.VueModel;

namespace Jeu_de_la_vie.VueModel
{
    internal class JeuVM
    {
        Grille grille = new Grille(10);
        Iteration iteration;
        private int _NombreIteration = 1;

        #region Notification des changements aux propriétés
        public event PropertyChangedEventHandler PropertyChanged;


        //Fonction qui gère l'envoi de l'événément PropertyChanged
        protected virtual void ValeurChangee(string nomPropriete)
        {
            //Vérifie si il y a au moins 1 abonné
            if (this.PropertyChanged != null)
            {
                //Lance l'événement -> tous les abonnés seront notifiés
                this.PropertyChanged(this, new PropertyChangedEventArgs(nomPropriete));
            }
        }

        #endregion
        public int NombreIteration 
        { 
            get { return _NombreIteration; } 
            set { _NombreIteration = value;
                ValeurChangee("NombreIteration");
            } 
        }
        #region Afficher formes
        #region Afficher forme 1
        private ICommand _AfficherFormeP;
        public ICommand AfficherFormeP
        {
            get { return _AfficherFormeP; }
            set { _AfficherFormeP = value; }
        }
        private void AfficherFormeP_Execute(object sender)
        {
            grille.PremForm();
        }
        private bool AfficherFormeP_CanExecute(object parameter)
        {
            return true;
        }
        #endregion
        #region Afficher Forme 2 
        private ICommand _AfficherFormeD;
        public ICommand AfficherFormeD
        {
            get { return _AfficherFormeD; }
            set { _AfficherFormeD = value; }
        }
        private void AfficherFormeD_Execute(object sender)
        {
            grille.DeuForm();
        }
        private bool AfficherFormeD_CanExecute(object parameter)
        {
            return true;
        }
        #endregion
        #region Afficher forme 3
        private ICommand _AfficherFormeT;
        public ICommand AfficherFormeT
        {
            get { return _AfficherFormeT; }
            set { _AfficherFormeT = value; }
        }
        private void AfficherFormeT_Execute(object sender)
        {
            grille.TroiForm();
        }
        private bool AfficherFormeT_CanExecute(object parameter)
        {
            return true;
        }
        #endregion
        #region Afficher forme Aléatoire
        private ICommand _AfficherFormeA;
        public ICommand AfficherFormeA
        {
            get { return _AfficherFormeA; }
            set { _AfficherFormeA = value; }
        }
        private void AfficherFormeA_Execute(object sender)
        {
            grille.randomForm();
        }
        private bool AfficherFormeA_CanExecute(object parameter)
        {
            return true;
        }
        #endregion
        #endregion
        #region ChargerForme
        #endregion
        #region EnregistrerForme
        #endregion
        #region Demarrer
        private ICommand _Demarrer;
        public ICommand Demarrer
        {
            get { return _Demarrer; }
            set { _Demarrer = value; }
        }
        private void Demarrer_Execute(object sender)
        {
            for(int i = 0; i < NombreIteration; i++)
            {
                iteration.FaireIteration();
                grille  = iteration.Grille;
            }
        }
        private bool Demarrer_CanExecute(object parameter)
        {
            return true;
        }
        #endregion


        public JeuVM()
        {
            iteration = new Iteration(grille);
            this.AfficherFormeP = new CommandeRelais(AfficherFormeP_Execute, AfficherFormeP_CanExecute);
            this.AfficherFormeD = new CommandeRelais(AfficherFormeD_Execute, AfficherFormeD_CanExecute);
            this.AfficherFormeT = new CommandeRelais(AfficherFormeT_Execute, AfficherFormeT_CanExecute);
            this.AfficherFormeA = new CommandeRelais(AfficherFormeA_Execute, AfficherFormeA_CanExecute);
            this.Demarrer = new CommandeRelais(Demarrer_Execute, Demarrer_CanExecute);

            grille.VérifierCellulesVivantes();
        }
    }
}
