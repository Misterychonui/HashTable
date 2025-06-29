using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HashTable;

namespace Program
{
    class Program
    {
        public static string[] GetWordsArray()
        {
            string[] words;
            char[] ArrayOfSeparatingСharacters ={',', ':', ' ', '.', '!', ';', '<', '?', '>', '-', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '/',
                '"', '*', '(', ')', '\'','\n','\r','\\'};
            StreamReader file = new StreamReader("WarAndWorld.txt");
            words = file.ReadToEnd().ToLower().Split(ArrayOfSeparatingСharacters, StringSplitOptions.RemoveEmptyEntries);
            return words;
        }
        private static void WorkWithHashTable(string[] words)
        {
            var hashTable = new OpenAddressHashTable<string, int>();
            var time = new Stopwatch();
            time.Start();
            for (int i = 0; i < words.Length; i++)
            {
                var word = words[i];
                if (hashTable.ContainsKey(word))
                {
                    hashTable[word] = hashTable[word] + 1;
                }
                else
                {
                    hashTable.Add(word, 1);
                }
            }
            var a = hashTable.Where(v => v.Value > 27).Select(v => v.Key).ToArray();
            var res = new List<string>();
            foreach (var d in hashTable)
            {
                if (d.Value > 27)
                    res.Add(d.Key);
            }
            foreach (var d in a)
            {
                hashTable.Remove(d);
            }
            time.Stop();
            Console.WriteLine(time.ElapsedMilliseconds);
        }
        static void WorkWithDictionary(string[] words)
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            var time1 = new Stopwatch();
            time1.Start();
            for (int i = 0; i < words.Length; i++)
            {
                var word = words[i];
                if (dictionary.ContainsKey(word))
                {
                    dictionary[word]++;
                }
                else
                {
                    dictionary.Add(word, 1);
                }
            }
                var a = dictionary.Where(v => v.Value > 27).Select(v => v.Key).ToArray();
            var res = new List<string>();
            foreach (var d in dictionary)
            {
                if (d.Value > 27)
                    res.Add(d.Key);
            }
            foreach (var d in a)
            {
                dictionary.Remove(d);
            }
            time1.Stop();
            Console.WriteLine(time1.ElapsedMilliseconds);
        }
        static void Main()
        {
            string[] Words = GetWordsArray();
            WorkWithDictionary(Words);
            WorkWithHashTable(Words);
           
         
            Console.ReadLine();
        }
    }
}


