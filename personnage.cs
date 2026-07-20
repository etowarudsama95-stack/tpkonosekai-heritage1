using System.Drawing;
using System.Net.Security;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
namespace tpheritage;

public abstract class personnage
{
    private int age;
    protected string nom;
    protected int Energie;
    protected int PointDeVie;
    protected int PointDevieMax = 500;
    protected int PointDeAttque;
    protected int spd;
    protected List<Element> elements;
    protected List<Dialogue> Message;
    protected List<technique> technique;


    public personnage(string nom, int age, int Energie, int PointDeVie)
    {

        if (Energie < 0)
        {
            throw new EnergieInsuffisante("l'energie ne peut pas etre negatif");
        }
        if (PointDeVie < 0 || PointDeVie == 0)
        {
            throw new KonoEvenementException("les point de Vie doivent etre superieur a 0");
        }
        if (age < 0 && this is not Gobelin)
        {
            throw new KonoEvenementException("l'age ne peut pas etre un nombre negatif");
        }
        if (PointDeVie > PointDevieMax && this is not Umi)
        {
            throw new KonoEvenementException("les point de vie ne peuvent pas etre superieur au pointDeVieMax");
        }


        this.nom = nom;
        this.age = age;
        this.Energie = Energie;
        this.PointDeVie = PointDeVie;
        this.technique = new List<technique>();
        this.PointDevieMax = PointDevieMax;
        this.PointDeAttque = 50;
        this.spd = 120;


    }



    public static bool ContientPersonnage<T>(
        List<personnage> personnages) where T : personnage
    {
        return personnages.Any(perso => perso is T);
    }






    public string GetNom()
    {
        return this.nom;
    }
    public void AjouterTechnique(technique technique)
    {
        this.technique.Add(technique);
    }

    public void RecevoirDegat(int Degat)
    {
        if (this.EstKo())
        {
            Console.WriteLine("Frerot tu l'a deja vaincu a moins que tu veuille detruire son ame");
        }
        if (Degat < 0)
        {
            throw new KonoEvenementException("les degat ne peuvent pas etre negatif");
        }

        this.PointDeVie -= Degat;

        if (this.PointDeVie < 0)
        {
            this.PointDeVie = 0;
            this.EstKo();
        }


    }

    public int GetAge()
    {
        return this.age;
    }

    public override string ToString()
    {
        return "Nom : " + this.nom +
               " | Age : " + this.age +
               " | Energie : " + this.Energie +
               " | PointDeVie : " + this.PointDeVie +
               " | PointDeAttaque : " + this.PointDeAttque;
    }

    public void AffcherTechnique()
    {

        if (!this.technique.Any())
        {
            throw new TechniqueException("le personnage de possede aucune technique");
        }


        foreach (technique UneTechnique in this.technique)
        {

            Console.WriteLine(UneTechnique.GetNom());
        }
    }

    public void UtiliserTechnique(string nomTechnique, personnage Cible)
    {

        foreach (technique uneTechnique in this.technique)
        {
            if (nomTechnique == uneTechnique.GetNom())
            {
                int cout = uneTechnique.GetCoutEnergie();
                int Degat = uneTechnique.GetDegat();

                if (this.Energie < cout)
                {
                    throw new EnergieInsuffisante("energie insuffisante");
                }
                Cible.RecevoirDegat(uneTechnique.GetDegat());
                this.Energie = this.Energie - uneTechnique.GetCoutEnergie();

                Console.WriteLine(this.nom, "utilise", uneTechnique.GetNom(), "sur", Cible.GetNom(), "et inflige", uneTechnique.GetDegat(), "degat");

            }
            else
            {
                if (nomTechnique == null)
                {
                    throw new TechniqueException(" Technique introuvable");
                }
            }

        }


    }


    public bool EstKo(personnage personnage)
    {
        if (personnage.EstKo())
        {
            return true;
        }
        return false;
    }

    public virtual bool EstKo()
    {
        if (this.PointDeVie == 0)
        {
            return true;
        }
        else
        {
            return false;
        }

    }


    public virtual bool PeutParticiperCombo(string nomCombo, personnage Partenaire)
    {
        return false;
    }

    public int GetEnergie()
    {
        return this.Energie;

    }


    public void ConsommerEnergie(int montant)
    {
        if (montant < 0)
        {
            throw new KonoEvenementException("Le coût ne peut pas être négatif.");
        }

        if (this.Energie < montant)
        {
            throw new EnergieInsuffisante("Energie insuffisante.");
        }

        this.Energie -= montant;
    }

    public int GetPointDeAttaque()
    {
        return this.PointDeAttque;
    }

    public virtual void AttaqueNormal(personnage cible)
    {
        if (EstKo())
        {
            throw new KonoEvenementException(GetNom() + "Est KO et ne peut pas utilier ne serait ce qu'une attaque normal");
        }


        cible.RecevoirDegat(this.PointDeAttque);

    }

    public virtual bool PeutSoigner()
    {
        return false;
    }

    public void RecevoirSoins(int Montant)
    {

        if (this.PeutSoigner())
        {
            this.PointDeVie += Montant;

            if (Montant > this.PointDeVie)
            {
                this.PointDeVie = PointDevieMax;
            }

        }


    }


    public virtual void DialoguePersonnage()
    {
        if (this.EstKo())
        {
            this.Message.Add(new Dialogue("Ahhh je suis mort"));
        }
    }



    public virtual void Possedertechnique()
    {
        foreach (technique techniques in this.technique)
        {
            Console.WriteLine(techniques.Tostring());
        }
    }



    public virtual bool APerduDesDgt()
    {

        if (this.PointDeVie != this.PointDevieMax)
        {
            return true;
        }
    return false;

    }


    public int GetPointDeVie()
    {
        return this.PointDeVie;

    }


    public  int GetPointDeVieMax()
    {
       return this.PointDevieMax;
    }


}







