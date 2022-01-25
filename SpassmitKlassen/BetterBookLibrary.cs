public class BetterBookLibrary
{

    private ICollection<Buch> Buecher;

    public BetterBookLibrary()
    {
        this.Buecher = new List<Buch>();
    }

    public void Add(Buch buch)
    {
        if (FindBook(buch.EindID) == null)
        {
            Buecher.Add(buch);
        }

        //for (int i = 0; i < this.Buecher.Length; i++)
        //{
        //    if (this.Buecher[i] == null)
        //    {
        //        this.Buecher[i] = buch;
        //        return;
        //    }
        //Wenn wir hier ankommen, wurde kein freier Platz im Array gefunden
        //throw new Exception("Bibliothek ist voll.");
    }

    //Auch eine Funktion für Suche nach GUID Bitte!

    public Buch? FindBook(Guid bookId)
    {
        foreach (Buch? buch in this.Buecher)
        {
            if (buch.EindID == bookId)
            {
                return buch;
            }
        }
        return null;
    }

    // Suche über Delegate function

    public Buch? FindBook (BuchFilter filter)
    {
        foreach ( Buch sample in this.Buecher)
        {
            if (filter(sample) == true)
            {
                return sample;
            }
        }
        return null;
    }
    public Buch? FindBook(string title)
    {
        foreach (Buch? buch in this.Buecher)
        {
            if (buch.Titel.Equals(title, StringComparison.OrdinalIgnoreCase))
            {
                return buch;
            }
        }

        return null;
    }

    // Filter bauen ( in ext. Datei, 1. Variante: wir definieren uns ein eigenes Interface(IBookSampleFilter)
    public Buch? FindBook(IBookSampleFilter filter)
    {
        foreach (Buch sample in Buecher)
        {
            if (filter.IsMatch(sample))
            {
                return sample;
            }
        }
        return null;
    }

    public int CountBooks()
    {
        int anzahl = 0;
        foreach (Buch numero in Buecher)
        {
            if (numero != null)
            {
                anzahl++;
            }
        }
        return anzahl;
    }

    public void RemoveBook(Buch exemplar)
    {
        RemoveBook(exemplar.EindID);
    }

    public void RemoveBook(Guid bookId)
    {
        Buch? buch = FindBook(bookId);
        if (buch is not null)
        {
            Buecher.Remove(buch);
        }
    }

 

    //public static Buch DeleteBook()
    //{

    //}

    //public static Buch Suchen()
    //{

    //}
}