using System.ComponentModel;
using System.Diagnostics;
using System.Linq.Expressions;
using tpheritage;

public class Stella : FilleDuTemps
{

    bool EstEnZadvanced;

    int DgtDeTransformation;


    Celestia SoeurChiante;
    Akari SoeurIntello;
    public Stella() : base("stella", 115, 300, 300, false)
    {
        this.DgtDeTransformation += this.PointDeAttque;
    }


    public bool ActiverZadvanced()
    {
        if (this.EstKo())
        {
            throw new StellaException("Stella est ko");
        }
        else if (this.Energie > 50)
        {
            throw new StellaException("L'energie de stella est insuffisante pour activer le Zadvanced");
        }

        return true;

    }
    public void Zadvanced()
    {

        if (ActiverZadvanced())
        {
            this.EstEnZadvanced = true;

        }

        int cout = 50;
        this.Energie -= cout;
        this.DgtDeTransformation = 100;
    }

    public void AttaqueNormal(personnage cible)
    {
        int Degat = this.PointDeAttque;
        cible.RecevoirDegat(Degat);

        if (ActiverZadvanced())
        {
            int DegatDeTransfo = this.DgtDeTransformation;
            cible.RecevoirDegat(DegatDeTransfo);
        }
    }

    public void ExplostionCataclysmique()
    {
        if (!ActiverZadvanced())
        {
            Console.WriteLine("Stella dois activer le Z advanced pour cette attaque");
            
        }
    }
    


      


    }
    

    

    
