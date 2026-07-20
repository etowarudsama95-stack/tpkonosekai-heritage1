using System.Drawing;
namespace tpheritage;

public class Rairyu : personnage
{
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
}