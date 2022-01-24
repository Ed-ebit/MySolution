public class TitleFilter : IBookSampleFilter
{

    public string Title { get; set; }

    public TitleFilter(string title)
    {
        this.Title = title;
    }
    public bool IsMatch(Buch sample)
    {
        return sample.Titel.Equals(Title, StringComparison.OrdinalIgnoreCase);
    }
}