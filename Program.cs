using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastermind
{
    class Program
    {
        /* vérifie que le caractère saisie fait partie des choix
        */
        static bool verif (char input)
        {
            bool output = false;
            char[] tabCouleur = { 'B', 'R', 'N', 'V', 'J', 'O', 'G' };

            for (int i = 0; i < 7; i++)
            {
                if (tabCouleur[i] == input)
                {
                    output = true;
                }
            }

            return output;
        }
        /*valide la saisie et renvoie le caractère en output
         */
        static char saisie (int c, int l)
        {
            char output;
            bool validation = false;

            do
            {
                Console.SetCursorPosition(c, l);
                output = Console.ReadKey().KeyChar;
                validation = verif(output);
            } while (validation == false);

            return output;

        }
        /* ajoute la saisie dans le vecteur des choix du joueur
         */
        static char[] vecCombinaison (int c, int l)
        {
            char[] output = new char[5];

            for (int i = 0; i < 5; i++)
            {
                char entree;
                entree = saisie(c, l);
                output[i] = entree;
                c += 2;
            }
            return output;
        }

        static int bonnePlace (char[] j1, char[] j2)
        {
            int output = 0;
            for (int i = 0; i < 5; i++)
            {
                if (j2[i] == j1[i])
                {
                    output++;
                }

            }
            return output;
        }

        static int mauvaisePlace (char[] j1, char[] j2, int input)
        {
            int output = 0;
            for (int i = 0; i < 5; i++)
            {
                if (j1[i] == j2[i] )
                {
                    j2[i] = 'X';
                }
                else
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (j1[i] == j2[j])
                        {
                            output++;
                            j2[j] = 'X';
                        }
                    }
                }

            }
            return output;
        }

        static string messageFin (int input)
        {
            string output;
            if (input <= 5 )
            {
                output = "Bravo !";
            } else if (input <= 10)
            {
                output = "Correct.";
            } else
            {
                output = "Décevant ...";
            }

            return output;
        }
        static void Main(string[] args)
        {
            char[] saisieJ1 = new char[5];

            Console.Write("1er joueur : ");

            saisieJ1 = vecCombinaison(15, 0);

            Console.WriteLine();
            Console.Write("Appuyez sur entrée pour passer au joueur 2.");
            Console.ReadLine();
            Console.Clear();

            Console.Write("2ème joueur : ");
            Console.SetCursorPosition(27, 0);
            Console.Write("Bien placé  Mal placé");

            char[] saisieJ2 = new char[5];

            bool trouve = false;
            int j = 1;
            int nbrBonnePlace = 0, nbrMauvaisePlace = 0;

            do
            {
                Console.SetCursorPosition(4, j);
                Console.Write("essai " + j);
                saisieJ2 = vecCombinaison(15, j);

                nbrBonnePlace = bonnePlace(saisieJ1, saisieJ2);
                Console.SetCursorPosition(31, j);
                Console.Write(nbrBonnePlace);

                nbrMauvaisePlace = mauvaisePlace(saisieJ1, saisieJ2, nbrBonnePlace);
                Console.SetCursorPosition(37, j);
                Console.Write(nbrMauvaisePlace);


                if (nbrBonnePlace == 5)
                {
                    trouve = true;
                    j--;
                }
                j++;

            } while (trouve == false);

            string message = messageFin(j);
            Console.SetCursorPosition(0, j + 2);
            Console.WriteLine("La formule a été trouvé en " + j + " essais : " + message);
            Console.ReadLine();
        }
    }
}
