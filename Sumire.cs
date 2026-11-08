using tpheritage;

class Sumire : Personnage 
{
    public Sumire() : base("sumire", 700, 250, 300)
    {

    }

    public void SoinsDesArbres(List <Personnage> Allie)
    {
        foreach (Personnage A in Allie)
        {
            if ( A.APerduDesDgt())
            {
                
            }
        }
    }

}
