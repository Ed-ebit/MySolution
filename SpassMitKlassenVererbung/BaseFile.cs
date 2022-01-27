using System.Text;

public class BaseFile
{
    public string Path { get; private set; }
    public string Extension
    {
        get
        {
            int dotIndex = this.Path.LastIndexOf('.');// suche startet von Rechts
            
            if (dotIndex < 0)// wenn nix gefunden, liefert negativen Wert zurück
            {
                return "";
            }
            else
            {
                return this.Path.Substring(dotIndex);
            }
            // obiges als ternärer Operator ausgedrückt:
            // return dotIndex < 0 ? ""  : Path.Substring(dotIndex)
        }
    }
    public int SizeInBytes => Data.Count;
    protected List<byte> Data { get; set; } // protected: in eigener Klasse und unterKlassen sichtbar,
                                            // nicht aber für Fremdcode

    public BaseFile Copy(string destinationPath)
    {
        throw new NotImplementedException();
    }

    public void Rename (string newName) { throw new NotImplementedException(); }

    public void Remove () { throw new NotImplementedException();}

    // Constructor

    public BaseFile(string path)
    {
        this.Path = path;
        this.Data = new List<byte>();
       
    }

    // Objektmethoden - werden an Untermethoden vererbt

    public virtual string Describe() // virtual bedeutet, dass die Methode überschreibbar ist
                                     // D.h., Unterklassen (Nachfahren) können die Methode
                                     // für ihre Zwecke anpassen (z.B. zus. Infos ausgeben) oder komplett überschreiben
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendLine($"Path: {this.Path}")
            .AppendLine($"Size: {this.SizeInBytes} Bytes")
            .AppendLine($"Extension: {this.Extension}");

        return builder.ToString();
    }
}