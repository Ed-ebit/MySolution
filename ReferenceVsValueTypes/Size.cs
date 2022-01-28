// Structs gibt es weil: die hier definierten Objekte und
// ihre Eigensschaften sind immer Value Types,
// die echte Werte im Stack bekommen, nicht nur Referenzen
// auf Objekte im Heap sind. In Klassen ist das anders.
//Weiterhin Kopiesemantik : bei Kopie von Variablen werden diese
//inklusive Ihres Werttes echt kopiert,
//2 getrennte Objekte die halt nur gleiche Werte haben
// Structs brauchen IMMER einen Constructor
public struct Size
{
    public int Width { get; private set; }
    public int Height { get; private set; }

    //Constructor

    public Size(int width, int height)
    {
        this.Width = this.Height = 0;// muss erstmal auf nen Wert gesetzt werden
        this.Set(width, height);
    }
    //public Set(int width, int height)
    //{
    //    this.Width = width;
    //    this.Height = height;
    //}

    public void Set(int width, int height) // negative Werte verhindern
    {
        this.Width = Math.Abs(width);
        this.Height = Math.Abs(height);
    }
}