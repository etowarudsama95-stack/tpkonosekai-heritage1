
namespace tpheritage;
public class technique
{
    private string nom;
    private int coutEnergie;
    private int Degat;
    private string Description;

    private personnage personnages;


    public technique(string nom, int coutEnergie, int Degat, string Description)
    {
        this.nom = nom;
        this.coutEnergie = coutEnergie;
        this.Degat = Degat;
        this.Description = Description;
    }

    public int GetDegat()
    {
        return this.Degat;
    }


    public int GetCoutEnergie()
    {
        return this.coutEnergie;
    }

    public string GetNom()
    {
        return this.nom;
    }

    public string Tostring()
    {
        return "NomTechnique :"
        + this.nom
        + "CoutEnergie :"
        + this.coutEnergie
        + "Degat :"
        + this.Degat
        + "Descrption :"
        + this.Description;
    }

    public technique copie()
    {
        return new technique(

        this.nom,
        this.coutEnergie,
        this.Degat,
        this.Description

        );
    }


}