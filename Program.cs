using System.ComponentModel;
using System.IO.Compression;
using System.Runtime.InteropServices;

namespace tpheritage;

class Program
{
    static void Main(string[] args)
    {

        try
        {


            Ame ame = new Ame();
            Eto eto = new Eto();
            personnage akari = new Akari();
            personnage Gobelin = new Gobelin();
            Console.WriteLine(ame.GetNom());
            Console.WriteLine(akari.GetNom());
            Console.WriteLine(akari.ToString());
            Console.WriteLine(eto.ToString());
            Console.WriteLine(Gobelin.ToString());
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine();
            }
            Console.WriteLine("attaque en cours");
            for (int i = 0; i < 3; i++)
            {
                eto.AttaqueNormal(Gobelin);
            }
            Console.WriteLine(eto.ToString());
            Console.WriteLine(Gobelin.ToString());
            Console.WriteLine(Gobelin.EstKo());

            personnage Rairyu = new Rairyu();
            personnage Celestia = new Celestia();
            personnage Gobelin2 = new Gobelin();
            Celestia celestia = new Celestia();

            Console.WriteLine(Rairyu.ToString());
            Console.WriteLine(Celestia.ToString());
            Console.WriteLine(Gobelin2.ToString());

            celestia.AjoutAllie(Rairyu);

            for (int i = 0; i < 10; i++)
            {
                Gobelin2.AttaqueNormal(Rairyu);
            }

            celestia.AfficherAllie();
            Console.WriteLine(Rairyu.ToString());
            Console.WriteLine(celestia.ToString());
            Console.WriteLine(celestia.EstenZadvanced());
            celestia.ActiverZadvanced();
            Console.WriteLine(celestia.EstenZadvanced());
            celestia.TuVasDisparaitre(Gobelin2);
            Console.WriteLine(celestia.ToString());
            Console.WriteLine(Gobelin2.ToString());


            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("-------------------------");

            }

            Console.WriteLine(ame.PeutParticiperCombo("valseEnflamme", eto));
            Console.WriteLine(eto.PeutParticiperCombo("ValseEnflamme", ame));
            personnage Gobelin3 = new Gobelin();


            ame.ValseEnflamee(eto, Gobelin3);

            eto.ComboFamille(Celestia);
            Console.WriteLine(eto.ComboFamille(celestia));

            celestia.JevaisEmbenterMesSoeurs();



        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);


        }
    }
}