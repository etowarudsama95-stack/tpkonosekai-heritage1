using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Http.Headers;
using System.Runtime.ExceptionServices;
using tpheritage;

class MehdiSQL : personnage
{

    private int CorpsAbsorbeTout;

     public MehdiSQL() : base("Mehdi", 18, 300, 300)
    {
        this.CorpsAbsorbeTout = 0;
    }
    public void MehdiBisouStelle()
    {
        int[] pipiDeStelle = new int[10];
        int contenance = 50;
        int totalLitre = 0;

        for (int i = 0; i > pipiDeStelle.Length; i++)
        {
            pipiDeStelle[i] += contenance;
            totalLitre += pipiDeStelle[i];
        }
        Console.WriteLine(this.GetNom() + "vient de boire :" + this.ToutBoire(totalLitre) + "Litre de L'urine de stelle et a tres bien aimer" );
    }
    public int ToutBoire(int montant)
    {
          return this.CorpsAbsorbeTout += montant;
    }


    }
       
       
