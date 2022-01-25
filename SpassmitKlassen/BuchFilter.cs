// Filter bekommt Exemplar eines Buches übergeben,
// gibt als Ergebnis 'true' zurück, wenn das Buch auf den Filter
// passt, ansonsten False -> muss einen bool zurückgeben
// Bsp-Filter
// Delegates: man kann eine Methode als Datentyp deklarieren, damit kapseln und diese
// wie ein Objekt behandeln.

//Ein Delegate wird als Methodensignatur definiert.
//Der Name der "Methode" ist der Name des Delegate-Typs (ähnlich 'Funktionszeiger' in anderen Sprachen)
public delegate bool BuchFilter(Buch sample);