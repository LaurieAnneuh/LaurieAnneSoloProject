using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Jeu_de_la_vie.VueModel;
namespace Jeu_de_la_vie.Model
{
    internal class Cellule : INotifyPropertyChanged
    {
        //Attribut
        bool etatVie;

        #region Propriété
        public Position Position { get; private set; }
        public bool EtatVie 
        {
            get { return etatVie; } 
            //Modifie l'état de vie et change la couleur
            set { etatVie = value;
                if (etatVie) { Couleur = "Red"; } 
                else { Couleur = "White"; } 
            } 
        }
        /// <summary>
        /// Nombre de cellule voisine vivante autour
        /// </summary>
        public int nbVivanteAuTour { get; set; }

        /// <summary>
        /// La couleur qu'elle est afficher
        /// </summary>
        public string Couleur { get; set; }
        #endregion

        /// <summary>
        /// Crée un bouton pour pouvoir cliquer sur la cellule
        /// </summary>
        #region Selectionner
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

        private ICommand _Selectionner;
        public ICommand Selectionner
        {
            get { return _Selectionner; }
            set { _Selectionner = value; }
        }
        /// <summary>
        /// Change l'état de vie et la couleur d'après l'état de vie
        /// </summary>
        /// <param name="sender"></param>
        private void Selectionner_Execute(object sender)
        {
            EtatVie = !EtatVie;
            ValeurChangee("EtatVie");
            ValeurChangee("Couleur");
        }
        private bool Selectionner_CanExecute(object parameter)
        {
            return true;
        }
        #endregion

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="pos">La position qu'à la cellule dans la grille</param>
        /// <param name="Etat">Si vivante ou non</param>
        public Cellule(Position pos, bool Etat)
        {
            Position = pos;
            EtatVie = Etat;
            nbVivanteAuTour = 0;
            this.Selectionner = new CommandeRelais(Selectionner_Execute, Selectionner_CanExecute);
        }
    }
}
