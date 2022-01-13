
using System.Threading.Tasks;


//Klassensichtbarkeit: zwischen versch. Assemblies
internal class CalculatorUebung
{
    //Methodensichtbarkeit: innerhalb derselben Assembly für andere Klassen und deren Methoden
    public static void Main(string[] args) // string[] args hier nicht nötig, bleibt leer und wird nicht genutzt
    {
        Console.WriteLine("Willkommen beim Summatorrr numero zwo!");
        Console.WriteLine("bitte zwei oder mehr Summanden eingeben (durch Leerzeichen trennen): ");
        Console.WriteLine("[Ohne Leerzeichen wird nur die Quersumme gebildet :D]");
        string str = Console.ReadLine();
        string[] z = str.Split();
        if (z.Length < 2)
        {
            Console.WriteLine("Die Quersumme von {0} ist {1}",,);
        }
        else
        {
            Console.WriteLine("Die Summe von");

            int summe = 0;
            for (int i=0;i < z.Length; i++)
            {
                int zahl = Convert.ToInt32(z[i]);
                Console.WriteLine("{0},", zahl);
                summe += zahl;
            }
            Console.WriteLine("ist genau {0}!", summe);
        }

    }

    public int Quer(string eingabe)
    {
        int qsum = 0;
        char[] ch = Convert.ToChar(eingabe);
        foreach (char ch in eingabe)
        {
            int z = Convert.ToInt32(ch);
            qsum += z;
        }
    }
}

