using tpheritage;

class Solar : personnage
{
    public Solar() : base("solar", 110, 300, 450)
    {

    }


    public override bool PeutParticiperCombo(string nomCombo, personnage Partenaire)
    {
        if (Partenaire is Stella || nomCombo == "explosion stellaire")
        {
            return true;
        }
        return false;
    }
}
