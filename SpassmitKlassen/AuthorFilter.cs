public class AuthorFilter : IBookSampleFilter
{
    public string Author { get; set; }

    public AuthorFilter(string author)
    {
        this.Author = author;
    }

    public bool IsMatch (Buch sample)
    {
        foreach (string einAutor in sample.Autoren)
        {
            if (einAutor.Equals(this.Author, StringComparison.CurrentCultureIgnoreCase))
            {
                return true;
            }
        }
        return false;
    }
}