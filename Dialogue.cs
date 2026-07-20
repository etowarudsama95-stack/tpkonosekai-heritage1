namespace tpheritage;

public class Dialogue
{
    private string texte;

    private int Numero;


    


    public Dialogue( string texte)
    {
        this.texte = texte;
        Console.WriteLine(this.texte);
    }

    public string GetTexte()
    {
        return this.texte;
    }
    
    public int GetNumero()
    {
        return this.Numero;
    }

    public override string ToString()
    {
        return this.texte;
    }
}