using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeu_de_la_vie.Model
{
    class GererFichierTexte
    {
        /// <summary>
        /// Enregistre la grille dans le fichier
        /// </summary>
        /// <param name="grille">La grille à enregistrer</param>
        /// <param name="nomFichier">Le fichier dans le quel la grille sera sauvegarder</param>
        public void Enregistrer(Grille grille, string nomFichier)
        {
            try
            {
                //Envoie le chemain au constructeur
                StreamWriter sw = new StreamWriter(nomFichier);
                
                //Format d'enregistrement
                for(int i = 0; i < grille.grandeur; i++)
                {
                    for(int j=0; j < grille.grandeur; j++)
                    {
                        //Espace entre chaque enregistrement d'une colone
                        sw.Write(grille.laGrille[i, j].EtatVie + " ");
                    }
                    //Entrer à chaque enregistrement de ligne
                    sw.Write("\r");
                }

                //Close the file
                sw.Close();
            }
            catch (Exception e)
            {
                
            }
        }

        /// <summary>
        /// Charger/Lire un fichier d'une forme pré-enregistrer
        /// </summary>
        /// <param name="nomFichier">le nom du fichier à lire</param>
        /// <returns>la grille résultante</returns>
        public Grille Lire(string nomFichier)
        {
            string line;
            Grille grille = new Grille(20);
            try
            {
                //Envoie le chemin du fichier au constructeur 
                StreamReader sr = new StreamReader("../../../../" + nomFichier + ".txt");
                string[] cellules;
                //Lit chaque ligne
                for(int i = 0; i < 20; i++)
                {
                    line = sr.ReadLine().Trim();
                    //Sépare la ligne en cellule à chaque colone
                    cellules = line.Split(" ");
                    //Ajoute la cellule dans la grille
                    for (int j = 0; j < cellules.Count(); j++)
                    {
                        grille.laGrille[i, j].EtatVie = Convert.ToBoolean(cellules[j]);
                    }

                }
                //close the file
                sr.Close();
                return grille;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                grille.CréerGrille();
                return grille;
            }

        }

        /// <summary>
        /// Charger/Lire un fichier d'une forme enregistrer par l'utilisateur (à partir de n'importe où dans le pc)
        /// </summary>
        /// <param name="nomFichier">le chemin du fichier à lire</param>
        /// <returns>la grille résultante</returns>
        public Grille LireExterne(string nomFichier)
        {
            string line;
            Grille grille = new Grille(20);
            try
            {
                //Envoie le chemin du fichier au constructeur 
                StreamReader sr = new StreamReader(nomFichier);
                string[] cellules;
                //Lit chaque ligne
                for (int i = 0; i < 20; i++)
                {
                    line = sr.ReadLine().Trim();
                    //Sépare la ligne en cellule à chaque colone
                    cellules = line.Split(" ");
                    //Ajoute la cellule dans la grille
                    for (int j = 0; j < cellules.Count(); j++)
                    {
                        grille.laGrille[i, j].EtatVie = Convert.ToBoolean(cellules[j]);
                    }

                }
                //close the file
                sr.Close();
                return grille;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                grille.CréerGrille();
                return grille;
            }

        }
    }
}
