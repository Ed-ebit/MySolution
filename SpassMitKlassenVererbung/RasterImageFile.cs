public class RasterImageFile : BaseFile
{
    public int PixelWidth { get; private set; }
    public int PixelHeight { get; private set; }

    public ColorSpace ColorSpace { get; private set; }
    public bool IsLossLess { get; private set; }

    //Constructor

    public RasterImageFile(string path) : base(path)
    {
        PixelHeight = 20;
        PixelWidth = 20;
        IsLossLess = false;
        ColorSpace = ColorSpace.RGB;
    }

    public override string Describe()
    {
        string describe = base.Describe();
        return $"{describe}\n Pixel-Höhe: {this.PixelHeight}, Weite: {this.PixelWidth}\n" +
            $"Verlust: {this.IsLossLess}, Color Space: {this.ColorSpace}";
    }
}
