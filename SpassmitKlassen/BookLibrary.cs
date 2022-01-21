public class BookLibrary
{

    private Buch?[] Buecher;

    public BookLibrary(int capacity)
    {
        this.Buecher = new Buch[capacity];
    }

    public void Add (Buch buch)
    {
        for (int i = 0; i< this.Buecher.Length; i++)
        {
            if(this.Buecher[i] == null)
            {
                this.Buecher[i] = buch;
                return;
            }
        }
        //Wenn wir hier ankommen, wurde kein freier Platz im Array gefunden
        throw new Exception("Bibliothek ist voll.");
    }

    //Auch eine Funktion für Suche nach GUID Bitte!

    public Buch? FindBook (Guid bookId)
    {
        foreach (Buch? buch in this.Buecher)
        {
            if(buch.EindID == bookId)
            {
                return buch;
            }
        }
        return null;
    }
    public Buch? FindBook (string title)
    {
        foreach (Buch? buch in this.Buecher)
        {
            if(buch.Titel.Equals(title, StringComparison.OrdinalIgnoreCase))
            {
                return buch;
            }
        }

        return null;
    }

    public int CountBooks()
    {
        int anzahl = 0;
        foreach ( Buch numero in Buecher)
        {
            if (numero != null)
            {
                anzahl++;
            }
        }
        return anzahl;
    }

    //public void RemoveBook(Buch buch)
    //{
    //    foreach(Buch eintrag in this.Buecher)
    //    {
    //        if(eintrag = this.Buecher)
    //        {

    //        }
    //    }
    //}

    //public static Buch DeleteBook()
    //{

    //}

    //public static Buch Suchen()
    //{

    //}
}