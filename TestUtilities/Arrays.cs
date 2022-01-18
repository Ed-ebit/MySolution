using Utility;

public class quadratArrays
{
    public static void Main()
    {
        string[] names = { "hamit", "ahmet", "lucy", "anna" };//Kurz
        string[] cities = new string[3]//Explizit
            {"berlin","hamburg","erfurt"};
        Console.WriteLine("Anzahl Namen: {0}", names.Length);
        foreach (string name in names)
        {
            Console.WriteLine($"Hallo {name}");
        }

        Ex08(names);
        Multiplik();
        ArrayAusgabe(Matrize());


    }

    public static void Ex08(string[] s)
    {
        foreach (string element in s)
        {

            string pali = "";
            if (Stringutils.IsPalindrome(element) == true)
            {
                pali = "(Palindrom)";
            }

            Console.WriteLine(element + " -> " + Stringutils.Reverse(element) + "{0}", pali);

        }
    }

    public static void Multiplik()
    {
        Console.WriteLine("Bitte eine ganze Zahl eingeben!");
        string temp = Console.ReadLine();
        int i = Convert.ToInt32(temp);

        int[] zahlen = new int[i];

        Console.WriteLine("n= {0}", i);

        for (i = 0; i < zahlen.Length; i++)
        {
            zahlen[i] = (i * i);
            Console.WriteLine("Zahlen[{0}] == {1}", i, zahlen[i]);
        }
    }

    public static int[,] Matrize()
    {

        Console.WriteLine("Bitte nochmal eine ganze Zahl eingeben!");
        string temp = Console.ReadLine();
        int zahl = Convert.ToInt32(temp);

        int[,] zahlen = new int[zahl + 1, zahl + 1];
        for (int i = 0; i <= zahl; i++)
        {


            Console.Write("{0,4}", i);
            for (int y = 1; y <= zahl; y++)
            {
                if (y * i == 0)
                {
                    Console.Write("{0,4}", y);
                }
                else
                {
                    Console.Write("{0,4}", y * i);
                    zahlen[i, y] = y * i;
                }

            }
            Console.WriteLine();

        }

        return zahlen;

    }

    public static void ArrayAusgabe(int[,] zahlen)
    {
        int reihe = zahlen.GetLength(0);
        int spalte = zahlen.GetLength(1);
        for (int i = 0; i < reihe; i++)
        {
            for (int y = 0; y < spalte; y++)
            {
                Console.WriteLine("{0}", zahlen[i, y]);
            }
        }
    }

    //public static int[,] multitabelle(int n) // übung 11
    //{



    //    int[,] table = new int[n, n];
    //    for (int row = 0; row < n; row++) // Enumerable.Range()
    //    {
    //        for (int col = 0; col < n; col++)
    //        {
    //            if (row * col == 0)
    //            {
    //                //Console.Write("{0,5}", col );
    //                table[row, col] = col;
    //            }s
    //            else
    //            {
    //                table[row, col] = row * col;
    //                //Console.Write("{0,5}", row * col);
    //            }

    //        }
    //        //Console.WriteLine();

    //    }



    //    return table;



    //}



    //public static void WriteTable(int[,] table)
    //{
    //    foreach (int row in Enumerable.Range(0, 10))
    //    {
    //        foreach (int col in Enumerable.Range(0, 10))
    //        {
    //            Console.Write("{0,5}", table[row, col]);
    //        }



    //        Console.WriteLine();
    //    }
    //}



    //public static void Multidimentional_table(int first_dimen, int second_dim, int third_dim) //übung 12
    //{
    //    int[,,] multi_tabel = new int[first_dimen, second_dim, third_dim];
    //    foreach (int first in Enumerable.Range(0, first_dimen))
    //    {
    //        foreach (int second in Enumerable.Range(0, second_dim))
    //        {
    //            foreach (int third in Enumerable.Range(0, third_dim))
    //            {
    //                multi_tabel[first, second, third] = first * second * third;
    //                Console.Write("{0,5}", second * third);
    //            }
    //            Console.WriteLine();
    //        }
    //        Console.WriteLine("Table {0}", first);
    //    }
    //}

    // aufg. 12: 3 dimensionales array auf konsole ausgeben (also 3 tabellen)
    // aufg. 13 definiere ein 2 dimens array 4 zeilen 2 spalten
    // werte: 1,2,3,4,5,6,7,8.

    //aufg.14: schreibe eine Methode, die ein 2dimensionales quadratisches array (abz.zeilen=anz.spalten) enthält und prüft, 
     //ob es sich um eine einheitsmatrix handelt (diagonale besteht nur aus einsen)
     // signatur: bool IsIdentityMatrix(int[,] matrix)


}