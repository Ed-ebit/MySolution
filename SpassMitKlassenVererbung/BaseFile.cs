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


    // Objektmethoden - werden an Untermethoden vererbt
    public void Copy(string destinationPath)
    {
        int j = 0;
        try
        {
            // Anweisungsblock mit eventuellen
            // Exceptions (Ausnahmen)
            int i = 1 / j;
            throw new Exception("Das ist eine Ausnahme");
        }
        catch (DivideByZeroException e)
        {
            //Fehlerbehandungsroutine
            throw e;
        }
        catch (Exception e)
        {
            //Fehlerbehandlungsroutine
            //für alle möglichen Exceptions
            Console.WriteLine($"Ich bin die allg. Fehlerbehandlungsroutine {e.Message}");
            return;
        }
        // Weitere Anweisungen
    }

    public void Rename (string newName) { throw new NotImplementedException(); }

    public virtual void Remove() 
    { 
        Console.WriteLine("Remove von BaseFile yay"); 
    }
    public void Move (string newPath)
    {
        this.Copy(newPath);
        this.Remove();
    }

    public virtual string Describe() // virtual bedeutet, dass die Methode überschreibbar ist
                                     // D.h., Unterklassen (Nachfahren) können die Methode
                                     // für ihre Zwecke anpassen (z.B. zus. Infos ausgeben) oder komplett überschreiben
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendLine($"Klasse des Objekts: {this.GetType().Name }\n Path: {this.Path}")
            .AppendLine($"Size: {this.SizeInBytes} Bytes")
            .AppendLine($"Extension: {this.Extension}");

        return builder.ToString();
    }

    // Constructor

    public BaseFile(string path)
    {
        this.Path = path;
        this.Data = new List<byte>();
       
    }

}