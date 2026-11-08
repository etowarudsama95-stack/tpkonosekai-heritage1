using System.Drawing;

namespace tpheritage;
public class FilleDuTemps : Personnage
{
    protected bool ModeCelesteEstActif;




    public FilleDuTemps(string nom, int age, int Energie, int PointDeVie, bool ModeCelesteEstActif) : base(nom, age, Energie, PointDeVie)
    {
        this.ModeCelesteEstActif = ModeCelesteEstActif;
    }



    public virtual void ActiverModeCeleste()
    {
        if (this.EstEnModeCeleste())
        {
            throw new KonoEvenementException("Le mode Céleste est déjà actif.");
        }

        if (this.Energie < 50)
        {
            throw new EnergieInsuffisante("Pas assez d'énergie.");
        }

        this.ModeCelesteEstActif = true;
        this.PointDeVie += 200;
        this.Energie -= 50;
    }


    public void DesactiverModeCeleste()
    {
        this.ModeCelesteEstActif = false;
    }

    public bool EstEnModeCeleste()
    {
        if (this.ModeCelesteEstActif)
        {
            return true;
        }
        else
        {
            return false;
        }



    }


}
