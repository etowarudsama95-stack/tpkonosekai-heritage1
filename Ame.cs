using System.Runtime.InteropServices;
using System.Security;
using System.Security.AccessControl;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace tpheritage;

public class Ame : FilleDuTemps
{

    private int NbActivation;

    private Celestia celestia;
    private Stella stella;

    private Akari akari;










    public Ame() : base("ame", 500, 400, 300, false)
    {
        this.NbActivation = 0;
        this.PointDevieMax = 300;
    }
    
    public void lierEnfant(Celestia c, Stella s, Akari a)
    {
        this.celestia = c;
        this.stella = s;
        this.akari = a;
    }



    public override void ActiverModeCeleste()
    {
        if (this.EstEnModeCeleste())
        {
            throw new AmeException("Amé est déjà en mode Céleste.");
        }

        int coutEnergie = 0;

        if (this.NbActivation >= 3)
        {
            coutEnergie = 50;
        }

        if (this.NbActivation >= 5)
        {
            coutEnergie = 80;
        }

        if (this.Energie < coutEnergie)
        {
            throw new EnergieInsuffisante("Amé n'a pas assez d'énergie.");
        }

        this.ModeCelesteEstActif = true;
        this.PointDeVie += 200;
        this.Energie -= coutEnergie;
        this.NbActivation++;

        if (this.NbActivation > 5)
        {
            this.PointDeVie -= 50;
            this.Energie -= 20;
        }
    }
    public void ValseEnflamee(Eto allie, personnage cible )
    {
        int cout = 50;
            
        if (allie is null)
        {
            throw new AmeException("mon cheri est null ?");
        }
        if (cible is null)
        {
            throw new AmeException("Je veux taper un ennemi");
        }
        if (cout > this.Energie)
        {
            throw new EnergieInsuffisante("ame n'a pas assez d'energie pour combo");
        }
        if (cout > allie.GetEnergie())
        {
            throw new EnergieInsuffisante("eto n'a pas assez d'energie pour ce combo");
        }
        if (this.EstKo())
        {
            throw new KonoEvenementException("ame est ko");
        }
        if (cible.EstKo())
        {
            throw new KonoEvenementException("la cible est deja ko");
        }
        if (allie.EstKo())
        {
            throw new KonoEvenementException("eto est ko");
        }
        this.Energie -= cout;
        allie.ConsommerEnergie(cout);
        int DGtValseEnflamme = this.PointDeAttque + allie.GetPointDeAttaque();
        int Degat = DGtValseEnflamme;
        cible.RecevoirDegat(Degat);
        Console.WriteLine(" La Valse Enflamme inflige " + DGtValseEnflamme + " Degat "  + " sur " + cible.GetNom());
        Console.WriteLine(this.ToString());
        Console.WriteLine(allie.ToString());
        Console.WriteLine(cible.ToString());
   }
    public override bool PeutParticiperCombo(string nomCombo, personnage Partenaire)
    {
        if (Partenaire is Eto || nomCombo == "ValseEnflamme")
        {
            return true;
        }
        else
        {
            return false;
        }
    }



    public List<personnage>MesFilles()
    {
        List<personnage> Enfants = new List<personnage>();
        Enfants.Add(this.celestia);
        Enfants.Add(this.stella);
        Enfants.Add(this.akari);
        return Enfants;
    }

    public void VerifierEtatDesFilles()
    {
        
    }






}



