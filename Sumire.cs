using tpheritage;

class Sumire : personnage 
{
    public Sumire() : base("sumire", 700, 250, 300)
    {

    }

    public void SoinsDesArbres(List <personnage> Allie)
    {
        foreach (personnage A in Allie)
        {
            if ( A.APerduDesDgt())
            {
                
            }
        }
    }

}