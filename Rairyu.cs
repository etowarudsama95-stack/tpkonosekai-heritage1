using System.Drawing;
using System.Runtime.CompilerServices;
namespace tpheritage;

public class Rairyu : personnage
{
private  bool EstEnFusionFoudroyante;


    public Rairyu() : base("rairyu", 129, 300, 400)
    {



    }


    public void CalmerCelestia(Celestia celestia)
    {
        if (this.EstKo())
        {
            throw new RairyuException("rairyu est ko et ne peut pas calmer celestia");
        }
        if (celestia is Celestia || celestia.PerteDeControleAdvanced() &this.GetEnergie() > 0)
        {
            celestia.ReprendreControle(this);
        }

    }


    public void FusionFoudroyante()
    {
        int cout = 40;
        if (this.EstKo())
        {
           throw new RairyuException("raiyuu est ko pour cette transformation");
        }
        if (this.Energie < cout)
        {
           throw new EnergieInsuffisante ("Energie insuffisante pour cette transformation");
        }
        EstEnFusionFoudroyante = true;
        int boostDetransfo = 100;
        this.DgtDeTransformatiom += boostDetransfo;
    }
    public override void AttaqueNormal(personnage cible)
    {

        if (this.EstKo())
        {
           throw new RairyuException("raiyu est ko");
        }
        if (!EstEnFusionFoudroyante)
        {
            int degat = 50 + this.PointDeAttque;
            cible.RecevoirDegat(degat);

        }
        int DegatDeDestruction = 0;
        DegatDeDestruction += this.DgtDeTransformatiom;
        if (EstEnFusionFoudroyante)
        {
           cible.RecevoirDegat(DegatDeDestruction);
        }

    }

    public bool DesactiverFusionFoudroyante()
    {
        if (this.EstEnFusionFoudroyante)
        {
         this.DgtDeTransformatiom -= 100;
        }
         return this.EstEnFusionFoudroyante = false;
    }
}   
