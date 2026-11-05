using System.ComponentModel;
using System.IO.Compression;
using System.Linq.Expressions;
using System.Runtime.InteropServices;

namespace tpheritage;

class Program
{
    static void Main(string[] args)
    {
        int? choix;
        int Age;
        string? Nom;



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
            Console.WriteLine(" 1 Choisir un perso");
            Console.WriteLine(" 2 Construire son personnage");
            Console.WriteLine(" 3 Choisir sa List De Personnage");
            choix = Convert.ToInt32(Console.ReadLine());

            switch (choix)
            {
                case 1 :
                    foreach (personnage LesPersonnage in Konosekai)
                    {
                        Console.WriteLine("numero Personnage : " + LesPersonnage.GetNumero() + " Personnage : " + LesPersonnage.GetNom());
                    }
                    personnage Choisi = null;
                    bool programInValide = true;

                    while (programInValide)
                    {
                        Choisi = null;
                        Console.WriteLine("Choisi ton personnage");
                        Console.Write("ton choix :");
                        int choix1 = Convert.ToInt32(Console.ReadLine());

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
                    Console.WriteLine("ton perso Actuelle2 :  " + Choisi.GetNom());
                  
                    break;
                case 2 :
                    Console.WriteLine("Nom du perso : ");
                    Nom = Console.ReadLine();
                    Console.WriteLine("Age du perso :");
                    Age = Convert.ToInt32(Console.ReadLine());

                      P = new personnage(Nom, Age, 200, 500);
                    break;
                    default:
                    Console.WriteLine("Choix Inconnu");
                    break;

                case 3:

                    Console.WriteLine(P.ToString());
                    break;

                
                    


            }
          
        } while (choix != 0);
        


     
        
        
    }
}
