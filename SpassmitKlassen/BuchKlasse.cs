public class Buch
{
    // Properties
    public Guid EindID { get; set; }

    public string Titel { get; set; }
    public string[] Autoren { get; set; }
    public int SeitenZahl { get; set; }
    public string SachGebiet { get; set; }

    public Medium Medium { get; set; }

    public string ISBN { get; set; }
    public string Zusatzinfos { get; set; }


    // Konstruktoren

    public Buch(string titel, string[] autoren, int seitenZahl, string sachGebiet, Medium medium, string isbn, string zusatzInfos )
    {
        this.EindID = Guid.NewGuid();
        this.Titel = titel;
        this.Autoren = autoren;
        this.SeitenZahl = seitenZahl;
        this.SachGebiet = sachGebiet;
        this.Medium = medium;
        this.ISBN = isbn;
        this.Zusatzinfos = zusatzInfos;
    }


}