using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using tpheritage;

namespace tpheritage;




class Gobelin : personnage
{

 private static int NumeroGobelin = 0;

protected static string GenererNom()
    {
    
   
    NumeroGobelin++;

        return "Gobelin" + NumeroGobelin;
    
   
}
    public Gobelin() : base(GenererNom(), 0, 70, 100)
    {
        this.PointDeAttque = 70;
        this.spd = 50;



    }

    protected Gobelin (string nom, int Energie, int PointDeVie) : base(nom, 0, Energie, PointDeVie)
    {
      
    }

}


class BossGobelin : Gobelin
{
    List<Gobelin> Gobelin = new List<Gobelin>();

    public BossGobelin(int Energie, int PointDeVie) : base(GenererNom(), 150, 300)
    {
        foreach (Gobelin gobelins in this.Gobelin)
        {

            int NbAllie = 50;
            this.PointDeAttque += NbAllie;
            this.PointDevieMax += NbAllie;
        }
    }

    public void ajouterGobelin(Gobelin gobelin)
    {
        this.Gobelin.Add(gobelin);
    }

    
    
    
}