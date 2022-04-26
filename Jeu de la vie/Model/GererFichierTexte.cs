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
        public void Enregistrer(Grille grille)
        {
            try
            {
                //Pass the filepath and filename to the StreamWriter Constructor
                StreamWriter sw = new StreamWriter("../../../../Forme2.txt");
                
                for(int i = 0; i < grille.grandeur; i++)
                {
                    for(int j=0; j < grille.grandeur; j++)
                    {
                        sw.Write(grille.laGrille[i, j].EtatVie + " ");
                    }
                    sw.Write("\r");
                }

                //Close the file
                sw.Close();
            }
            catch (Exception e)
            {
                
            }
        }

        public Grille Lire(string nomFichier)
        {
            string line;
            Grille grille = new Grille(20);
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("../../../../" + nomFichier + ".txt");
                string[] cellules;
                //Read the first line of text
                for(int i = 0; i < 20; i++)
                {
                    line = sr.ReadLine().Trim();
                    cellules = line.Split(" ");
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

        public Grille LireExterne(string nomFichier)
        {
            string line;
            Grille grille = new Grille(20);
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader(nomFichier);
                string[] cellules;
                //Read the first line of text
                for (int i = 0; i < 20; i++)
                {
                    line = sr.ReadLine().Trim();
                    cellules = line.Split(" ");
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
