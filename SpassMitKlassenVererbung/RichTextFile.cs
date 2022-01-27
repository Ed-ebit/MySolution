public class RichTextFile : TextFile
{
    public string FontName { get; private set; }

    // base ist hier : TextFile

    public RichTextFile(string path, string FontName) : base(path)
    {
        this.FontName = FontName;
    }

    public override string Describe()
    {
        string description = base.Describe();
        return $"{description}\nFontName: {this.FontName}";
    }
}