using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HeapManager.UnitTest
{
    [TestClass]
    public class HeapTestClass
    {
        Logic.Heap heap;

        public HeapTestClass()
        {
            this.heap = new Logic.Heap(100);
        }

        [TestMethod()]
        public void T01_TestToLarge()
        {
            Assert.AreEqual(-1, heap.GetMem(200), "Zu große Anforderung -> muss -1 ergeben");
        }

        [TestMethod()]
        public void T02_FirstAllocate()
        {
            Assert.AreEqual(0, heap.GetMem(10), "Erster Block muss auf 0 liegen");
            Assert.AreEqual(2, heap.Blocks, "Spaltung führt zu zwei Blöcken");
        }

        [TestMethod()]
        public void T03_FirstAllocateAndFree()
        {
            int adr = heap.GetMem(10);
            Assert.IsTrue(heap.FreeMem(adr), "Block an der Adresse 0 muss freigebbar sein");
            Assert.AreEqual(1, heap.Blocks, "Blöcke wurden nicht korrekt vereinigt");
        }

        [TestMethod()]
        public void T04_AllocateAndFreeTwoBlocks()
        {
            int adr1 = heap.GetMem(10);
            int adr2 = heap.GetMem(20);
            Assert.AreEqual(3, heap.Blocks, "Zwei Teilungen ==> 3 Blöcke");
            Assert.IsTrue(heap.FreeMem(adr1), "Block an der Adresse 0 muss freigebbar sein");
            Assert.AreEqual(3, heap.Blocks, "Mitte bleibt belegt ==> 3 Blöcke");
            Assert.IsTrue(heap.FreeMem(adr2), "Block an der Adresse 10 muss freigebbar sein");
            Assert.AreEqual(1, heap.Blocks, "Verschmelzung dreier Blöcke klappt nicht");
        }

        [TestMethod()]
        public void T05_AllocateFull()
        {
            int adr1 = heap.GetMem(10);
            int adr2 = heap.GetMem(90);
            Assert.AreEqual(10, adr2, "Block wurde nicht angelegt");
            Assert.AreEqual(2, heap.Blocks, "Keine Teilung, da Block genau passt");
            Assert.IsTrue(heap.FreeMem(adr1), "Block an der Adresse 0 muss freigebbar sein");
            Assert.IsTrue(heap.FreeMem(adr2), "Block an der Adresse 10 muss freigebbar sein");
            Assert.AreEqual(1, heap.Blocks, "Verschmelzung von zwei Blöcken klappt nicht");
        }

        [TestMethod()]
        public void T06_AllocateAndFreeMany()
        {
            int adr;
            bool[] isAlloc = { true, true, true, true, false, true, true, false, true };
            int[] allocSize = { 5, 10, 20, 10, 0, 25, 5, 0, 20 };
            int[] adresses = { 0, 5, 15, 35, 15, 45, 15, 35, 20 };
            int[] blocks = { 2, 3, 4, 5, 5, 6, 7, 6, 7 };
            for (int i = 0; i < isAlloc.Length; i++)
            {
                if (isAlloc[i])
                {
                    adr = heap.GetMem(allocSize[i]);
                    Assert.AreEqual(adresses[i], adr, "Fehler bei Allokation " + i.ToString());
                }
                else
                {
                    Assert.IsTrue(heap.FreeMem(adresses[i]), "Fehler bei Freigabe " + i.ToString());
                }
                Assert.AreEqual(blocks[i], heap.Blocks, "Blockfehler im Durchlauf: " + i.ToString());
            }
        }

        [TestMethod()]
        public void T07_FreeWrongBlock()
        {
            int adr = heap.GetMem(10);
            Assert.IsFalse(heap.FreeMem(10), "Freier Block wurde freigegeben");
        }

        [TestMethod()]
        public void T08_CorrectFreeBlock()
        {
            heap.GetMem(20);
            heap.GetMem(20);
            heap.GetMem(20);
            heap.GetMem(20);
            heap.GetMem(20);
            heap.FreeMem(80);
            heap.FreeMem(40);
            Assert.AreEqual(40, heap.GetMem(10), "Falscher freier Block zurückgegeben");
        }
    }
}
