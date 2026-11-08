using tpheritage;

public class Solar : Personnage
{
    public Solar() : base("solar", 110, 300, 450)
    {

    }


    public override bool PeutParticiperCombo(string nomCombo, Personnage Partenaire)
    {
        if (Partenaire is Stella || nomCombo == "explosion stellaire")
        {
            return true;
        }
        return false;
    }
}
