using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jeu_de_la_vie.Model;
using System.ComponentModel;
using System.Windows.Input;
using Jeu_de_la_vie.VueModel;
using System.Threading;
using Microsoft.Win32;

namespace Jeu_de_la_vie.VueModel
{
    internal class JeuVM : INotifyPropertyChanged
    {
        #region Attribut 
        Grille grille;
        Iteration iteration;
        List<Cellule> _lalisteCell;
        private int _NombreIteration = 1;
        GererFichierTexte gererFichierTexte;
        #endregion

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

        /// <summary>
        /// Propriété du nombre d'itération voulue
        /// </summary>
        public int NombreIteration 
        { 
            get { return _NombreIteration; } 
            set { _NombreIteration = value;
                ValeurChangee("NombreIteration");
            } 
        }

        /// <summary>
        /// La liste de cellule afficher
        /// </summary>
        public List<Cellule> ListeCellule
        {
            get { return _lalisteCell; }
            set
            {
                _lalisteCell = new(value);
                ValeurChangee("ListeCellule");
            }
        }
        #region Afficher formes
        #region Afficher forme 1
        /// <summary>
        /// Bouton qui affiche la première forme enregistrer
        /// </summary>
        private ICommand _AfficherFormeP;
        public ICommand AfficherFormeP
        {
            get { return _AfficherFormeP; }
            set { _AfficherFormeP = value; }
        }
        private void AfficherFormeP_Execute(object sender)
        {
            //Vide la grille actuelle
            grille.viderGrille();
            //grille.PremForm();

            //Lit le fichier de la forme 1
            grille = gererFichierTexte.Lire("Forme1");

            //Met à jour la liste de cellule afficher
            ListeCellule = grille.cellules;
        }
        private bool AfficherFormeP_CanExecute(object parameter)
        {
            return true;
        }
        #endregion
        #region Afficher Forme 2 
        /// <summary>
        /// Bouton qui affiche la deuxième forme enregistrer
        /// </summary>
        private ICommand _AfficherFormeD;
        public ICommand AfficherFormeD
        {
            get { return _AfficherFormeD; }
            set { _AfficherFormeD = value; }
        }
        private void AfficherFormeD_Execute(object sender)
        {
            //vide la grille
            grille.viderGrille();

            //Fonction de base
            //grille.DeuForm();

            //Lis le fichier à afficher
            grille = gererFichierTexte.Lire("Forme2");

            //Met à jour la liste de cellule afficher
            ListeCellule = grille.cellules;
        }
        private bool AfficherFormeD_CanExecute(object parameter)
        {
            return true;
        }
        #endregion
        #region Afficher forme 3
        /// <summary>
        /// Bouton qui affiche la troisième forme enregistrer
        /// </summary>
        private ICommand _AfficherFormeT;
        public ICommand AfficherFormeT
        {
            get { return _AfficherFormeT; }
            set { _AfficherFormeT = value; }
        }
        private void AfficherFormeT_Execute(object sender)
        {
            //Vide la grille actuelle
            grille.viderGrille();

            //Lit le fichier de la forme 3
            grille = gererFichierTexte.Lire("Forme3");

            //Met à jour la liste de cellule afficher
            ListeCellule = grille.cellules;
        }
        private bool AfficherFormeT_CanExecute(object parameter)
        {
            return true;
        }
        #endregion
        #region Afficher forme Aléatoire
        /// <summary>
        /// Bouton qui affiche la première forme enregistrer
        /// </summary>
        private ICommand _AfficherFormeA;
        public ICommand AfficherFormeA
        {
            get { return _AfficherFormeA; }
            set { _AfficherFormeA = value; }
        }
        private void AfficherFormeA_Execute(object sender)
        {
            //Vide la grille actuelle
            grille.viderGrille();

            //Demande une nouvelle grille avec des cellules vivante aléatoire
            grille.randomForm();

            //Met à jour la liste de cellule afficher
            ListeCellule = grille.cellules;
        }
        private bool AfficherFormeA_CanExecute(object parameter)
        {
            return true;
        }
        #endregion
        #endregion
        #region ChargerForme
        private ICommand _ChargerForme;

        /// <summary>
        /// Bouton Charger un fichier externe
        /// </summary>
        public ICommand ChargerForme
        {
            get { return _ChargerForme; }
            set { _ChargerForme = value; }
        }
        private async void ChargerForme_Execute(object sender)
        {
            //ouvre la fenetre
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Select File";
            open.ShowDialog();
            if(open.FileName != "")
            {
                //lit le fichier 
                grille = gererFichierTexte.LireExterne(open.FileName);
                //Modifie l'affichage de la grille visible
                ListeCellule = grille.cellules;
            }
        }
        private bool ChargerForme_CanExecute(object parameter)
        {
            return true;
        }
        #endregion
        #region EnregistrerForme
        private ICommand _EnregistrerForme;
        /// <summary>
        /// Bouton enregistrer la grille actuel sur un fichier externe
        /// </summary>
        public ICommand EnregistrerForme
        {
            get { return _EnregistrerForme; }
            set { _EnregistrerForme = value; }
        }
        private async void EnregistrerForme_Execute(object sender)
        {
            //Ouvre la fênetre à remplir
            SaveFileDialog open = new SaveFileDialog();
            open.Title = "Save File";
            open.ShowDialog();
            open.DefaultExt = "txt";
            open.CheckFileExists = true;
            open.CheckPathExists = true;
            open.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            //Si le nom et emplacement choisi
            if (open.FileName != "")
            {
                //Enregistre la grille dans le fichier
                gererFichierTexte.Enregistrer(grille, open.FileName);
            }
        }
        private bool EnregistrerForme_CanExecute(object parameter)
        {
            return true;
        }
        #endregion
        #region Demarrer
        /// <summary>
        /// Bouton pour démarrer le jeu
        /// </summary>
        private ICommand _Demarrer;
        public ICommand Demarrer
        {
            get { return _Demarrer; }
            set { _Demarrer = value; }
        }
        private async void Demarrer_Execute(object sender)
        {
            //Vérifie si itération infinie
            if(NombreIteration != -1)
            {
                //itére pour le nombre de fois demander
                for (int i = 0; i < NombreIteration; i++)
                {
                    //Grille actuelle
                    iteration.Grille = grille;

                    //Vérifie grille
                    grille.VérifierCellulesVivantes();

                    //Fait une itération
                    iteration.FaireIteration();

                    //actualise l'object grille
                    grille = iteration.Grille;

                    //actualise la liste de cellule affichier
                    ListeCellule = grille.cellules;

                    //Affiche la grille pendant 0.1 seconde
                    await Task.Delay(100);
                }
            }
            else
            {
                //Itére à l'infini
                for (;;)
                {
                    //Grille actuelle
                    iteration.Grille = grille;

                    //Vérifie grille
                    grille.VérifierCellulesVivantes();

                    //Fait une itération
                    iteration.FaireIteration();

                    //actualise l'object grille
                    grille = iteration.Grille;

                    //actualise la liste de cellule affichier
                    ListeCellule = grille.cellules;

                    //Affiche la grille pendant 0.1 seconde
                    await Task.Delay(100);
                }
            }
        }
        private bool Demarrer_CanExecute(object parameter)
        {
            return true;
        }
        #endregion


        /// <summary>
        /// Constructeur de la VM Jeu
        /// </summary>
        public JeuVM()
        {
            //Initie les objets 
            grille = new Grille(20);
            iteration = new Iteration(grille); //Cree l'objet itération avec le tableau vide
            ListeCellule = new List<Cellule>();
            ListeCellule = grille.cellules; //Liste des cellules à affichier
            gererFichierTexte = new GererFichierTexte();


            //Crée les boutons
            this.AfficherFormeP = new CommandeRelais(AfficherFormeP_Execute, AfficherFormeP_CanExecute);
            this.AfficherFormeD = new CommandeRelais(AfficherFormeD_Execute, AfficherFormeD_CanExecute);
            this.AfficherFormeT = new CommandeRelais(AfficherFormeT_Execute, AfficherFormeT_CanExecute);
            this.AfficherFormeA = new CommandeRelais(AfficherFormeA_Execute, AfficherFormeA_CanExecute);
            this.Demarrer = new CommandeRelais(Demarrer_Execute, Demarrer_CanExecute);
            this.ChargerForme = new CommandeRelais(ChargerForme_Execute, ChargerForme_CanExecute);
            this.EnregistrerForme = new CommandeRelais(EnregistrerForme_Execute, EnregistrerForme_CanExecute);

            
        }
    }
}
