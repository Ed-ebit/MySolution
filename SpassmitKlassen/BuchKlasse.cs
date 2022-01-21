public class Buch
{
    // Properties
    public Guid EindID { get;}

    public string Titel { get; set; }
    public string[] Autoren { get;}
    public int SeitenZahl { get; set; }
    public string SachGebiet { get; set; }

    public BookMedium Medium { get; set; }

    public string Isbn { get; set; }
    public string ZusatzInfos { get; set; }


    // Konstruktoren

    public Buch(string titel, string[] autoren, int seitenZahl, string sachGebiet, BookMedium medium, string isbn, string zusatzInfos)
    {
        this.EindID = Guid.NewGuid();
        this.Titel = titel;
        this.Autoren = autoren.ToArray();//wir kopieren die Angabe in ein neues Array,
                                         //das nur innerhalb unserer Klasse existiert und von außen nicht geändert werden kann.
        this.SeitenZahl = seitenZahl;
        this.SachGebiet = sachGebiet;
        this.Medium = medium;
        this.Isbn = isbn;
        this.ZusatzInfos = zusatzInfos;
    }

    public Buch(string titel) : this(titel, new string[0], 0, "", BookMedium.None, "", "")
    {
    }

    // Instanzmethoden

    public void Describe()
    {
        Console.WriteLine(" Das Buch heisst:{0}, Autoren: {1}, Seitenzahl: {2}, Sachgebiet: {3}, " +
            "Medium: {4}, ISBN: {5}, interne ID: {6}", this.Titel, String.Join(", ",this.Autoren), this.SeitenZahl, 
            this.SachGebiet, this.Medium, this.Isbn, this.EindID);
        Console.WriteLine();
    }

    public Buch CopyBook()
    {
        return new Buch(this.Titel, this.Autoren, this.SeitenZahl, this.SachGebiet, this.Medium, this.Isbn, this.ZusatzInfos);        
    }

}