using HashTable;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace HashTableTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddInHeshTableIsCorrect()
        {
            OpenAddressHashTable<int, int> hashTable = new OpenAddressHashTable<int, int>();
            int[] array = new int[100];
            for (int i = 0; i < 100; i++)
            {
                array[i] = i;
                hashTable.Add(array[i], 0);
            }
            for (int i = 0; i < 100; i++)
            {
                Assert.AreEqual(hashTable.ContainsKey(array[i]), true);
            }
        }
        [TestMethod]
        public void IncreaseTableIsCorrect()
        {
            OpenAddressHashTable<int, int> hashTable = new OpenAddressHashTable<int, int>();
            int[] array = new int[11];
            array[0] = 4;
            hashTable.Add(4, 0);
            array[1] = 24;
            hashTable.Add(24, 0);
            array[2] = 16;
            hashTable.Add(16, 0);
            array[3] = 6;
            hashTable.Add(6, 0);
            array[4] = 22;
            hashTable.Add(22, 0);
            array[5] = 10;
            hashTable.Add(10, 0);
            array[6] = 7;
            hashTable.Add(7, 0);
            array[7] = 31;
            hashTable.Add(31, 0);
            array[8] = 9;
            hashTable.Add(9, 0);
            array[9] = 20;
            hashTable.Add(20, 0);
            array[10] = 26;
            hashTable.Add(26, 0);
            for (int i = 0; i < 11; i++)
            {
                Assert.AreEqual(hashTable.ContainsKey(array[i]), true);
            }
        }
        [TestMethod]
        public void ItemContainsInTable()
        {
            OpenAddressHashTable<int, int> hashTable = new OpenAddressHashTable<int, int>();
            int[] array = new int[100];
            for (int i = 0; i < 100; i++)
            {
                array[i] = i;
                hashTable.Add(array[i], 0);
            }
            for (int i = 0; i < 100; i++)
            {
                Assert.AreEqual(hashTable.ContainsKey(array[i]), true);
            }

        }
        [TestMethod]
        public void RemoveIsCorrect()
        {
            OpenAddressHashTable<int, int> hashTable = new OpenAddressHashTable<int, int>();
            int[] array = new int[100];
            for (int i = 0; i < 100; i++)
            {
                array[i] = i;
                hashTable.Add(array[i], 0);
            }
            for (int i = 0; i < 100; i++)
            {
                if (i % 10 == 0)
                    hashTable.Remove(i);

            }
            for (int i = 0; i < 100; i++)
            {
                if (i % 10 == 0)
                {
                    Assert.AreEqual(hashTable.ContainsKey(i), false);
                }
                else
                {
                    Assert.AreEqual(hashTable.ContainsKey(i), true);
                }
            }
        }
        [TestMethod]
        public void CountChangeAfterRemove()
        {
            OpenAddressHashTable<int, int> hashTable = new OpenAddressHashTable<int, int>();
            int[] array = new int[10];
            for (int i = 0; i < 10; i++)
            {
                array[i] = i;
                hashTable.Add(array[i], 0);
            }
            for (int i = 0; i < 100; i++)
            {
                if (i % 2 == 0)
                    hashTable.Remove(i);

            }
            Assert.AreEqual(hashTable.Count, 5);
        }
        [TestMethod]
        public void ClassTest()
        {
            OpenAddressHashTable<int, int> hashTable = new OpenAddressHashTable<int, int>();
            int[] array = new int[10];
            hashTable.Add(11, 0);
            hashTable.Add(22, 0);
            hashTable.Add(2, 0);
            hashTable.Add(33, 0);
            hashTable.Add(44, 0);
            hashTable.Add(55, 0);
            hashTable.Remove(11);
            hashTable.Remove(22);
            hashTable.Remove(33);
            Assert.AreEqual(hashTable.ContainsKey(2), true);

            Assert.AreEqual(hashTable.ContainsKey(44), true);

            Assert.AreEqual(hashTable.ContainsKey(55), true);
        }

    }
}
