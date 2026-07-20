using System.Collections.Concurrent;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Drawing;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using tpheritage;
public class Celestia : FilleDuTemps
{
    private bool EstEnZadavanced;
    private bool PerteDeControl;


    private Stella imouto1;
    private Akari imouto2;

    private Ame MamanCheri;

    private Eto PapaCheri;
    

    private personnage eto;
    private List<personnage> allie;

    protected List<Dialogue> message;

    public Celestia() : base("Celestia", 130, 300, 500, false)
    {
        this.EstEnZadavanced = false;
        this.PerteDeControl = false;
        this.allie = new List<personnage>();
        this.PointDeAttque = 200;
        this.message = new List<Dialogue>();
        this.MamanCheri = MamanCheri;
        this.PapaCheri = PapaCheri;
        this.imouto1 = imouto1;
        this.imouto2 = imouto2;

    }


    public void AjoutAllie(personnage allie)
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

            foreach (personnage allie in this.allie)
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
        foreach (personnage allies in this.allie)
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

    public void DesactiverZadvanced(personnage celestia)
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
            foreach (personnage allie in this.allie)
            {
                Console.WriteLine("allie de celestia :" + allie.GetNom());
            }
        }


    }
    public override void AttaqueNormal(personnage cible)
    {
        cible.RecevoirDegat(this.PointDeAttque);
    }


    public void TuVasDisparaitre(personnage cible)
    {
        if (this.PerteDeControl)
        {
            foreach (personnage allie in this.allie)
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
   List<personnage> personnages
) where T : personnage
    {
        return personnages.Any(perso => perso is T);
    }


    public void JevaisEmbenterMesSoeurs()
    {
        if (this.EstKo() || imouto1.EstKo() || imouto2.EstKo())
        {
            throw new CelestiaException("TOUT LE MONDE DOIT ETRE VIVANT SINON JE PEUX PAS VOUS TAQUINER");
        }
        if (imouto1 is null)
        {
            throw new CelestiaException("STELLLAAAAA T'ES OUUUUUU");
        }
        if (imouto2 is null)
        {
            throw new CelestiaException("AKARIIIIIIIIIII RAMENE TOI");
        }


        Random random = new Random();
        int chance = random.Next(1, 3);

        if (chance == 1)
        {
            new Dialogue("Celestia vole un packet de BN a stella");

            new Dialogue("Celestia : stella tu cherche quoi");

            new Dialogue("Stella : je cherche mon packet bn gout caramel edition limite");

            new Dialogue("Celestia : oh je vois bonne chance");

            new Dialogue("Stella : tu serai pas quelque chose par hasard ?");

            new Dialogue("Celestia : Je te promet que non, apres t'es ma imouto preferer ");

            new Dialogue(" Stella : MYTHO, je t'ai deja vu en flagrant delit en train de bouffer des bn");

            new Dialogue("Celestia : j'avais faim ");

            new Dialogue("Stella : Mytho, encore t'avais deja bouffer 6 de mes paquet et meme apres ta ca tu m'a encore voler");

            new Dialogue("Celestia : c'est pour ca t'es ma imouto preferer toujours a faire plaisir a ca soeur");

            new Dialogue("Stella : C'est pas te faire plaisir c'est plutot une faille de cybersecurite de mes bn contre CELESIACOROMPU.EXE");

            new Dialogue("Celestia : ca va aller c'est des biscuit");


            new Dialogue("Stella envoie valser Celestia dans du salon du manoir en faisant un trou de la fummee apparait");

            this.RecevoirDegat(20);

            new Dialogue("Celestia : Aie wesh ");

            new Dialogue("Stella : Bien fait");


            new Dialogue(" Celestia redonne le coup a sa petite soeur d'une vitesse superieur");

            new Dialogue("stella est envoyer valser dans la cuisine contre la chaise");

            imouto1.RecevoirDegat(20);


            new Dialogue("Celestia en dirait que faut retravailler ta vitesse petite soeur hehe");


            new Dialogue("Stella : Tu veux jouer a ca ?");


            new Dialogue("Stella concentre son aura");

            new Dialogue("Celestia : tu vas detruire le manoir arrete ca 😭");

            new Dialogue("Ame intervient");


            new Dialogue("Ca suffit toute les deux, je vous aime trop pour vous voir vous chamaillez comme ca");

            MamanCheri.ArreterDeVousChamailler(this, imouto1, imouto2);

            new Dialogue("Stella && Celestia : D'accord Maman");

            


        }


    }







}


