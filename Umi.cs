namespace tpheritage;

class Umi : FilleDuTemps
{
    
    private bool EauDesAbysse;


    public Umi() : base("umi", 750, 200, 300, false)
    {

    }



    public void DesactiverEauDesAbysse()
    {
     this.EauDesAbysse = false;
    }
    
    public void ActiveEaudesAbysse()
    {

        if (this.EstKo())
        {
            throw new UmiException("Umi est Ko");
        }
        if (this.EauDesAbysse)
        {
            throw new UmiException("Umi est deja en forme Eau des abysses");
        }

        int CoutEnergie = 50;
        int BoostHP = 150;
        this.EauDesAbysse = true;

      if (this.EstEnModeCeleste())
        {
            int boostatq = 100;
            this.PointDevieMax += BoostHP;
            this.PointDeAttque += boostatq;
            Random random = new Random();
            int montant = random.Next(100, 200);
            this.RecevoirSoins(montant);

        
            
        }else
        {
            Random random = new Random();
            int boostatq = 50;
            this.PointDeAttque += boostatq;
            int montant = random.Next(150, 300);
            this.RecevoirSoins(montant);
        }
    }


}