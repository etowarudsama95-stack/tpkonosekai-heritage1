using System.ComponentModel;
using System.Diagnostics;
using System.Linq.Expressions;
using tpheritage;

public class Stella : FilleDuTemps
{

    private bool EstEnZadvanced;





    public Celestia SoeurChiante;
    public Akari SoeurIntello;
    public Solar Partenaire;  
    public Stella() : base("stella", 115, 300, 300, false)
    {
        this.DgtDeTransformatiom += this.PointDeAttque;
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
        this.DgtDeTransformatiom = 100;
    }

    public void AttaqueNormal(Personnage cible)
    {
        int Degat = this.PointDeAttque;
        cible.RecevoirDegat(Degat);

        if (ActiverZadvanced())
        {
            int DegatDeTransfo = this.DgtDeTransformatiom;
            cible.RecevoirDegat(DegatDeTransfo);
        }
    }

    public void ExplostionCataclysmique(Personnage cible)
    {
        if (!ActiverZadvanced())
        {
            Console.WriteLine("Stella dois activer le Z advanced pour cette attaque");
        }
        else
        {
            int DegatDattaque;
            DegatDattaque = this.DgtDeTransformatiom;
            cible.RecevoirDegat(DegatDattaque);
        }

        
    }

    public void EnchainementDynamique(Solar solar, Personnage ennemi)

    {
        int DegatDeCombo;
        if (solar is null)
        {
            throw new StellaException("je veux solar sinon je plante cette attaque");
        }

        if (solar.EstKo() is true)
        {
            throw new StellaException("Solar me laisse pas toute seule je peux pas utiliser ce combo sinon....");
        }
        if (this.EstKo())
        {
            throw new StellaException("stella est ko");
        }


        Random random = new Random();

        DegatDeCombo = random.Next(200, 400);
        ennemi.RecevoirDegat(DegatDeCombo);



    }



    public void FusionDynamique(Personnage ennemi)
    {
        int DegatDeCombo;
        if (Partenaire is null)
        {
            throw new StellaException("je veux solar sinon je plante cette attaque");
        }

        if (Partenaire.EstKo() is true)
        {
            throw new StellaException("Solar me laisse pas toute seule je peux pas utiliser ce combo sinon....");
        }
        if (this.EstKo())
        {
            throw new StellaException("stella est ko");
        }



        Random Combo = new Random();
        DegatDeCombo = Combo.Next(300, 450);
        ennemi.RecevoirDegat(DegatDeCombo);

    }
    
    



    


      


    }
    

    

    
