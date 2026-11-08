using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.IO.Compression;
using System.Linq.Expressions;
using System.Net;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;

namespace tpheritage;

class Program
{
    static void Main(string[] args)
    {
        int? choix;
        int Age;
        string? Nom;

        Personnage Choisi = null;

        Personnage? P = null;
        Personnage personnage = new Celestia();
        Personnage personnage1 = new Ame();
        Personnage personnage2 = new Eto();
        Personnage Gobelin = new Gobelin();
        Personnage BossGobelin = new BossGobelin();

        List<Personnage> Konosekai = new List<Personnage>();
        List<Personnage> Ennemi = new List<Personnage>();
        List<Personnage> Principal = new List<Personnage>();
        if (Choisi != null)
        {
            Principal.Add(Choisi);
        }

        Konosekai.AddRange(personnage, personnage1, personnage2);
        do
        {
            Console.WriteLine("               Bienvenue dans konosekai                ");
            Console.WriteLine("fait ton choix ");

            Console.WriteLine(" 0 QUITTER");
            if (Choisi == null)
            {
                Console.WriteLine(" 1 Choisir un Perso");
            }
            else
            {
                Console.WriteLine(" 1 changer un perso (Perso Actuelle : " + Choisi.GetNom() + ")");
            }
            Console.WriteLine(" 2 Construire son personnage");
            Console.WriteLine(" 3 Choisir sa List De Personnage");
            choix = Convert.ToInt32(Console.ReadLine());
            int choix1;

            switch (choix)
            {
                case 1:
                    foreach (Personnage LesPersonnage in Konosekai)
                    {
                        Console.WriteLine("numero Personnage : " + LesPersonnage.GetNumero() + " Personnage : " + LesPersonnage.GetNom());
                    }

                    bool programInValide = true;

                    while (programInValide)
                    {
                        Choisi = null;
                        Console.WriteLine("Choisi/change ton personnage");
                        Console.Write("ton choix :");
                        while (!int.TryParse(Console.ReadLine(), out choix1))
                        {
                            Console.WriteLine("Choisi un vrai nombre");
                            Console.Write("ton choix : ");
                        }

                        for (int L = 0; L != Konosekai.Count; L++)
                        {
                            if (choix1 == Konosekai[L].GetNumero())
                            {
                                Choisi = Konosekai[L];
                                programInValide = false;
                                break;
                            }

                            if (L == Konosekai.Count - 1 && programInValide)
                            {
                                Console.WriteLine("choix invalide recommence");
                            }

                        }
                    }
                    Console.WriteLine("ton perso Actuelle :  " + Choisi.GetNom());

                    break;
                case 2:
                    int nbchoice;
                    bool enMarche = true;

                    while (enMarche)
                    {

                        Console.WriteLine("Combien de personnage veut tu crée ? ");
                        Console.Write("ton nombre :");

                        while (!int.TryParse(Console.ReadLine(), out nbchoice))
                        {
                            Console.WriteLine("Chosi un nombre Valide");
                            Console.Write("ton choix :");
                        }

                        if (nbchoice < 0)
                        {
                            Console.WriteLine("choisis un nombre positif");
                            continue;
                        }
                        else
                        {
                            List<Personnage> personnageCree = new List<Personnage>();

                            for (int i = 0; i < nbchoice; i++)
                            {

                                Console.WriteLine("choisi un nom");
                                string nom = Console.ReadLine().Replace(" ", "");
                                if (string.IsNullOrWhiteSpace(nom))
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("rentre un vrai nom !");
                                    Console.ResetColor();
                                    continue;
                                }
                                Console.WriteLine("Choisi son age");
                                int age;
                                while (!int.TryParse(Console.ReadLine(), out age))
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine(" Choisi un vrai nombre ! ");
                                    Console.ResetColor();
                                    continue;
                                }

                                personnageCree.Add(new Personnage(nom, age, 300, 500));

                            }

                            bool ProgramInvalideA = true;
                            int choice2;
                            Console.WriteLine("1. afficher le nom ET l'age des personnage cree ?");
                            Console.WriteLine("2. Combattre");
                            Console.Write("ton choix :");
                            while (!int.TryParse(Console.ReadLine(), out choice2))
                            {
                                Console.WriteLine("choisi un vrai nombre !");
                            }
                            if (choice2 == 1)
                            {
                                foreach (Personnage VoirPersonnage in personnageCree)
                                {
                                    Console.WriteLine(" Nom : " + VoirPersonnage.GetNom() + "\t Age : " + VoirPersonnage.GetAge());
                                }
                            }
                            else if (choice2 == 2)
                            {
                                int? choice3;
                                do
                                {
                                    Console.WriteLine("0. QUITTER");
                                    Console.WriteLine("1. Combien de gobelin voulez vous affrontez ?");
                                    Console.WriteLine(" 2 Affrontement avec un boss Gobelin");
                                    choice3 = LireEntier("ton choix : ");
                                    switch (choice3)
                                    {
                                        case 1 :
                                            int resultat = LireEntier("Entre Ton Nombre :");
                                            for (int i = 0; i < resultat; i++)
                                            {
                                                Ennemi.Add(new Gobelin());
                                            }
                                            bool match = true;
                                            while (match)
                                            {
                                                Console.WriteLine("           ENNEMI            ");

                                                foreach (Gobelin gobelin in Ennemi)
                                                {
                                                    Console.WriteLine(Gobelin.ToString());
                                                }

                                                Console.WriteLine("            ALLIE               ");

                                                foreach (Personnage perso in personnageCree)
                                                {
                                                    Console.WriteLine(perso.ToString());
                                                }
                                                try
                                                {
                                                    Console.WriteLine(Choisi.ToString());

                                                }
                                                catch (NullReferenceException)
                                                {
                                                    Console.WriteLine("aucun perso chosi");
                                                    Console.WriteLine("Choisi ton perso :");
                                                }

                                                int nombreKO = 0;
                                                foreach (Gobelin gobelin in Ennemi)
                                                {
                                                    if (gobelin.EstKo())
                                                    {
                                                        nombreKO++;
                                                    }
                                                }
                                                if (nombreKO == Ennemi.Count)
                                                {
                                                    Console.WriteLine("tu as gagné !");
                                                    enMarche = false;
                                                    break;
                                                }
                                                Console.WriteLine("TON TOUR :");
                                                Console.WriteLine("1 . Attaquer un ou des ennemi ?");
                                                Console.WriteLine("2 . soigner un allié");
                                                Console.WriteLine("3 . Quitter");
                                                int choice4 = LireEntier("ton choix :");

                                                if (choice4 == 1)
                                                {
                                                    List<Personnage> KO = new List<Personnage>();
                                                    Console.WriteLine("            ENNEMI          ");
                                                    foreach (Gobelin gobelin in Ennemi)
                                                    {
                                                        Console.WriteLine(Gobelin.ToString() + Gobelin.GetNumero());
                                                    }
                                                    int choice5 = LireEntier("numero ennemi : ");
                                                    foreach (Gobelin gobelin in Ennemi)
                                                    {
                                                        if (choice5 == gobelin.GetNumero())
                                                        {
                                                            Choisi.AttaqueNormal(gobelin);
                                                            if (gobelin.EstKo())
                                                            {
                                                                KO.Add(gobelin);
                                                            }
                                                        }
                                                    }
                                                    foreach (Personnage EstKO in KO)
                                                    {
                                                        if (EstKO.EstKo())
                                                        {
                                                            Ennemi.Remove(EstKO);
                                                        }
                                                    }
                                                    if (Ennemi.Count == 0)
                                                    {
                                                        Console.WriteLine(" TOUT LES PERSONNAGE ENNEMI ONT ETE VAINCU");
                                                    }

                                                }
                                                else if (choice4 == 2)
                                                {
                                                    Console.WriteLine("Cette action ne fait rien pour l'instant");

                                                }
                                                break;
                                            }
                                            break;
                                    }
                                } while (choice3 != 0);

                            }
                            enMarche = false;
                        }
                    }
                    break;

                case 3:

                            Console.WriteLine(P.ToString());
                            break;

                        }

                    } while (choix != 0) ;

            }

            static string LireCaractere(string message)
            {
                Console.Write(message);
                string? String = Console.ReadLine().Replace(" ", "");

                while (string.IsNullOrWhiteSpace(String))
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("sasie vide recommence !");
                    Console.ResetColor();
                    String = Console.ReadLine();
                }

                return String;
            }

            static int LireEntier(string message)
            {
                Console.Write(message);

                int valeur;
                while (!int.TryParse(Console.ReadLine(), out valeur))
                {
                    Console.WriteLine("Saisis un nombre entier valide !");
                    Console.Write(message);
                }

                return valeur;
            }

        }

