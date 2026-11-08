using System.Collections.Concurrent;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Drawing;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using tpheritage;
public class Celestia : FilleDuTemps
{
    private bool EstEnZadavanced;
    private bool PerteDeControl;
    public Stella imouto1;
    public Akari imouto2;
    public Ame MamanCheri;
    public Eto papaCheri;
    private List<Personnage> allie;

    protected List<Dialogue> message;
    public Celestia() : base("Celestia", 130, 300, 500, false)
    {
        this.EstEnZadavanced = false;
        this.PerteDeControl = false;
        this.PointDeAttque = 200;
       
    }
    public void AjoutAllie(Personnage allie)
    {
        if (allie is null)
        {
            throw new CelestiaException("celestia attennds un vrai allie");
        }
        this.allie.Add(allie);
    }
    public bool EstenZadvanced()
    {
        return this.EstEnZadavanced;
    }
    public void ActiverZadvanced()
    {
        bool APerduLeControle = this.PerteDeControleAdvanced();

        if (APerduLeControle)
        {
            this.EstEnZadavanced = true;
            this.PerteDeControl = true;

            Random random = new Random();

            int DGTAleatoire = random.Next(200, 400);

            DGTAleatoire += this.PointDeAttque;

            foreach (Personnage allie in this.allie)
            {
                if (allie.EstKo())
                {
                    this.spd += 50;
                }
                if (allie is Rairyu && allie.EstKo())
                {
                    this.PointDeAttque += 50;
                }
            }
        }
        else
        {
            int CoutEnergie = 70;
            if (this.Energie < CoutEnergie)
            {
                throw new EnergieInsuffisante("pas assez d'energie pour entrer en Zadvanced");
            }
            else
            {
                this.EstenZadvanced();
            }
            if (this.PointDeVie == 0 || EstKo())
            {
                throw new CelestiaException("Celestia est ko et ne peut pas tenter une transformation");

            }
            else
            {
                EstEnZadavanced = true;
                int boostAtq = 200;
                int boostspd = 100;
                this.Energie -= CoutEnergie;
                this.PointDeAttque += boostAtq;
                this.spd += boostspd;
            }
        }
    }
    public bool EstEnPerteControle()
    {
        return this.PerteDeControl;
    }
    public bool PerteDeControleAdvanced()
    {
        if (this.EstEnZadavanced)
        {
            int Pvperdu = PointDevieMax - this.PointDeVie;
            double DifferenceDePv = Pvperdu * 100 / this.PointDevieMax;

            if (DifferenceDePv >= 50)
            {
                Random random = new Random();
                int chance = random.Next(1, 101);

                if (chance <= 50)
                {
                    return true;
                }
            }
        }
        else if (this.Energie >= 50 && AllieEstKo())
        {
            return true;


        }
        return false;
    }
    public bool AllieEstKo()
    {
        foreach (Personnage allies in this.allie)
        {
            if (allies.EstKo())
            {
                return true;
            }
        }
        return false;
    }
    public bool DesactiverZadvanced()
    {
        return this.EstEnZadavanced = false;
    }

    public void DesactiverZadvanced(Personnage celestia)
    {
        if (celestia is Celestia)
        {
            this.spd = 200;
            this.PointDeAttque = 200;
            this.EstEnZadavanced = false;
        }
    }
    public void AfficherAllie()
    {
        if (this.allie.Count == 0)
        {
            Console.WriteLine("celestia n'a aucun allie");
        }
        else
        {
            foreach (Personnage allie in this.allie)
            {
                Console.WriteLine("allie de celestia :" + allie.GetNom());
            }
        }
    }
    public override void AttaqueNormal(Personnage cible)
    {
        cible.RecevoirDegat(this.PointDeAttque);
    }
    public void TuVasDisparaitre(Personnage cible)
    {
        if (this.PerteDeControl)
        {
            foreach (Personnage allie in this.allie)
            {
                if (allie is Rairyu && allie.EstKo())
                {
                    int DegatEnragee = 0;
                    while (!cible.EstKo())
                    {
                        DegatEnragee += this.PointDeAttque;
                        cible.RecevoirDegat(DegatEnragee);
                    }
                }
                else
                {
                    this.message.Add(new Dialogue("Je vais te detruire"));
                    int DegatdeDestruction;
                    int boostAtq = 200;
                    boostAtq += this.PointDeAttque;
                    DegatdeDestruction = boostAtq;
                    cible.RecevoirDegat(DegatdeDestruction);

                }
            }
        }
        else
        {
            throw new CelestiaException("Celestia n'a pas perdu le controle");
        }
    }
    public void DialogueDeCelestia()
    {
        this.message.AddRange(new List<Dialogue>


    
{
       new Dialogue("Ce n'est pas encore fini"),
       new Dialogue("Je vais te montrer la suite"),
       new Dialogue("Prépare-toi")
});
    }
    public void GetDialogue()
    {
        this.message = new List<Dialogue>();
    }
    public void ReprendreControle(Rairyu rairyu)
    {
        if (this.PerteDeControleAdvanced() && rairyu is Rairyu)
        {
            this.PerteDeControl = false;
            this.message.Add(new Dialogue("Merci rairyu tu me sauves"));
        }
        throw new NotImplementedException();
    
    }

    public static bool ContientPersonnage<T>(
   List<Personnage> personnages
) where T : Personnage
    {
        return personnages.Any(perso => perso is T);
    }




    







}



