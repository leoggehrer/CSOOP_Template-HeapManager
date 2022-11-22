using System;

namespace HeapManager.Logic
{
    /// <summary>
    /// Die Klasse Heap kapselt die Zugriffe auf die 
    /// Speicherverwaltung und dient als Schnittstelle
    /// zum Unittest.
    /// </summary>
    public class Heap
    {
        /// <summary>
        /// Diese Eigenschaft berechnet die Anzahl der Bloecke. Ein Block besteht aus 
        /// einem freien oder einem belegten Speicherblock.
        /// </summary>
        public int Blocks
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Dieser Konstruktor uebernimmt die Speichergroesse vom Nutzer. Fall eine ungueltige Grosse 
        /// uebergeben wird, wird der Block mit einer Groesse von 1000 initialisiert.
        /// </summary>
        /// <param name="size">die zu verwaltende Speichergroesse</param>
        public Heap(int size)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Diese Methode waehlt einen Speicherblock nach der Methode "BestFit" aus und 
        /// liefert die Adresse an den Aufrufer zurueck. Falls kein Block der geforderten 
        /// Groesse ermittelt werden kann, liefert die Methode -1 an den Aufrufer zurueck.
        /// </summary>
        /// <param name="size">der geforderte Speicherblock</param>
        /// <returns>die Adresse des Speicherblocks, -1 sonst</returns>
        public int GetMem(int size)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Diese Methode gibt den Speicherblock an der angegebenen Adresse frei. Wird die Adresse 
        /// am Heap nicht gefunden, dann liefert die Methode -1 als Rueckgabewert.
        /// </summary>
        /// <param name="address">die Speicherblockadresse</param>
        /// <returns>true wenn Speicherblock gefunden, false sonst</returns>
        public bool FreeMem(int address)
        {
            throw new NotImplementedException();
        }
    }
}
