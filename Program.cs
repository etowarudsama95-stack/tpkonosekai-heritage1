using System.ComponentModel;
using System.Data;
using System.IO.Compression;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace tpheritage;

class Program
{
    static void Main(string[] args)
    {
        int? choix;
        int Age;
        string? Nom;

      personnage Choisi = null;

        personnage? P= null;
         personnage personnage = new Celestia();
            personnage personnage1 = new Ame();
            personnage personnage2 = new Eto();

        List<personnage> Konosekai = new List<personnage>();

        
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
                Console.WriteLine(" 1 changer un perso (Perso Actuelle : " +  Choisi.GetNom()+ ")");
            }
            Console.WriteLine(" 2 Construire son personnage");
            Console.WriteLine(" 3 Choisir sa List De Personnage");
            choix = Convert.ToInt32(Console.ReadLine());
            int choix1;

            switch (choix)
            {
                case 1 :
                    foreach (personnage LesPersonnage in Konosekai)
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

                        for (int L = 0 ; L != Konosekai.Count; L++)
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
                case 2 :
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
                        }else
                        {
                            List<personnage> personnageCree;
                            bool programInValideT = true;
                            for (int i = 0; i < nbchoice; i++)
                            {
                                while (programInValideT && i > nbchoice)
                                {
                                    Console.WriteLine("choisi un nom");
                                    string nom = Console.ReadLine().Replace("","");
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
                                        Console.WriteLine("Choisi un vrai nombre !");
                                        Console.ResetColor();
                                        continue;
                                    }

                                    enMarche = false;
                                    programInValideT = false;
                                    
                                }

                                 
                            }
                        }



                    }

                    break;
                case 3:

                    Console.WriteLine(P.ToString());
                    break;

                
                    


            }
          
        } while (choix != 0);
        


     
        
        
    }
}
