public class Adress
{
    //Properties
    public string Strasse
    {
        get; set;
    }
    public string Hausnr
    {
        get; set;
    }

    public string Ort
    {
        get; set;
    }

    public string Land
    {
        get; set;
    }

    // Konstruktoren

    public Adress (string strasse, string hausnr, string ort, string land)
    {
        this.Strasse = strasse;
        this.Hausnr = hausnr;
        this.Ort = ort;
        this.Land = land;
    }
    public Adress()
    {
        this.Strasse = "Musterstrasse";
        this.Hausnr = "10b";
        this.Ort = "Musterhausen";
        this.Land = "Musterland";
    }

    //Instanzmethoden

    public void Describe()
    {
        Console.WriteLine("{0}, {1}, {2}, {3}",this.Strasse,this.Hausnr,this.Ort,this.Land);
    }
}
