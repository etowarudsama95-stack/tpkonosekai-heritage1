using System.Linq.Expressions;
using System.Runtime.Serialization;



namespace tpheritage;

public class Eto : personnage
{

    private bool EstEnZadvanced;
    private Celestia Fille;


    public Eto() : base("eto", 500, 500, 300)
    {
        this.EstEnZadvanced = false;

    }

    public override bool PeutParticiperCombo(string nomCombo, personnage Partenaire)
    {
        if (Partenaire is Ame || nomCombo == "ValseEnflamme")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void AjouterTechnique(technique technique)
    {
        this.technique.Add(technique);
    }

    public void EnseignerTechnique(Celestia celestia)
    {
        if (celestia is null)
        {
            throw new EtoException("Eto veut sa fille");
        }

    }

    public technique ComboFamille(personnage  Famille)
    {
        if (Famille is not Ame && Famille is not Celestia && Famille is not Stella && Famille is not Akari)
        {
            throw new EtoException("il faut un membre de la famille de eto");

        }

        Famille = this.Fille;

        if (Famille is Ame)
        {
            return new technique("embrasement aille", 50, 300, "TechniqueCelesteDeFeu");

        }

        if (Famille is Celestia)
        {
            return  new technique("braisier explosive multiple", 50, 300, "TechniqueDefeu");
            
        }

        if (Famille is Stella)
        {
            return new technique("broyeur compressif", 50, 300, "TechniqueDeFeu");
        }

        if (Famille is Akari)
        {
            return new technique("vague infernal", 50, 300, "TechniqueCelesteDeFeu");
        }

        
        technique comboFille = new technique("braisier explosive multiple", 50, 300, "TechniqueDefeu");


        Fille.AjouterTechnique(comboFille);

        return null;


    }


    
    


        

    }
