﻿using Utility;
public class SpassmitKlassen
{
    public static void MainGeometrie()
    {
        KreisKlasse? circle = null;
        // ? sorgt hier dafür, das definiertes Objekt null sein darf
        circle = new KreisKlasse();
        KreisKlasse otherCircle = new KreisKlasse();
        KreisKlasse thirdCircle = otherCircle;
        // otherCircle und thirdCircle zeigen nun auf das selbe Objekt im Heap, NICHT AUFEINANDER
        // d.h. beide Kreise können weiterhin unabhängig behandelt, verändert etc. werden

        Console.WriteLine(circle.Equals(thirdCircle)); // Methode von System.Object
        Console.WriteLine(Object.Equals(circle, thirdCircle)); // Statische Methode von System.Object (kann nicht 'auf' Objekt ausgeführt werden)
        //Auch wenn Die Klasse "Kreisklasse" noch keinerlei Methoden für ihre Objekte besitzt,
        // so haben doch ALLE Objekte in C# (und auch alle anderen Datentypen, im ggstz zu z.B. Java) schon die vorgefertigten Methoden
        // der Klasse System.Objects, und klnnen mit diesen veerwendet werden (z.B. Equals, WriteLine etc.)

        // Achtung: Unterklassen können Methoden ihrer Oberklassen überschreiben (Klassenhierarchie),
        // also wir können eine andere Funktion für 'Equals' in unserer Kreisklasse festlegen.

        Console.WriteLine(Object.ReferenceEquals(otherCircle, thirdCircle));

        KreisKlasse.PrintMetadata();
        // thirdCircle.PrintDetails(); Fehler: PrintDetails ist statische Methode.

        circle.Radius = 10;
        otherCircle.Radius = 5.25;
        thirdCircle.Radius = 7; // überschreibt den Wert auf dem Heap Objekt, den otherCircle ihm zugewiesen hat,
                                // da beide Namen auf dasselbe Objekt zeigen

        circle.Describe();
        Console.WriteLine(circle.ToString());

        KreisKlasse neuerKreis = new KreisKlasse();
        neuerKreis.Describe();
        neuerKreis.Radius = -50; // Problem: negativer Radius macht keinen Sinn
        neuerKreis.Describe();

        // Achtung: hier kommt Arbeit mit besserer Kreisklasse, die über Getter- und Setter läuft

        BessereKreisKlasse geilererKreis = new BessereKreisKlasse();
        geilererKreis.SetRadius(10);
        geilererKreis.Describe();


        // Neu: Rechteck
        Console.WriteLine();

        RechteckKlasse einRechteck = new RechteckKlasse();
        einRechteck.SetHeight(10);
        einRechteck.SetWidth(15);

        einRechteck.Describe();

        //Jetzt: Dreieck
        Console.WriteLine();

        DreieckKlasse einDreieck = new DreieckKlasse(5,5);
        einDreieck.Describe();
        DreieckKlasse t = DreieckKlasse.CreateRightAngled(2, 5);
        t.Describe();







    }

    public static void Main()
    {
        Person p = new Person("Hans Meyer");
        Console.WriteLine(p.Name);
        p.Name = "Claire Grube";
        Console.WriteLine(p.Name);
    }
}
