public class RasterImageFile : BaseFile
{
    public int PixelWidth { get; private set; }
    public int PixelHeight { get; private set; }

    public ColorSpace ColorSpace { get; private set; }
    public bool IsLossLess { get; private set; }

    //Constructor

    public RasterImageFile(string path) : base(path) // hat die Basisklasse einen Parameterlosen Konstruktor,
                                                     // kann man sich das :Base sparen
    {
        PixelHeight = 20;
        PixelWidth = 20;
        IsLossLess = false;
        ColorSpace = ColorSpace.RGB;
    }

    // ObjektMethoden

    public void SetDimensions(int width, int height)
    {
        this.PixelWidth = width;
        this.PixelHeight = height;
    }
    public override string Describe()
    {
        string describe = base.Describe();
        return $"{describe}Pixel-Höhe: {this.PixelHeight}, Weite: {this.PixelWidth}\n" +
            $"Verlust: {this.IsLossLess}, Color Space: {this.ColorSpace}\n";
    }
}
