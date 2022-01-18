using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestUtilities
{
    internal class ArraysVonArrays
    {
        public static void Main()
        {
            //aufg 15: Additionstabelle 1-5 unter Nutzung Arrays von Arrays

            int[][] tabelle = new int[5][];
            for (int reihe = 0; reihe < 5; reihe++)
            {
                tabelle[reihe] = new int[5]; 

                for(int spalte =0; spalte < 5; spalte++)
                {
                    tabelle[reihe][spalte] = reihe + spalte + 2;
                    Console.Write("{0,4}",tabelle [reihe][spalte]);
                }
                Console.WriteLine();
            }

        }
    }
}
