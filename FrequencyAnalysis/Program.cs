/* SWORD Programming Test 
 * Mukta S. Aphale */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using static System.Net.Mime.MediaTypeNames;

namespace FrequencyAnalysis
{
    class Program
    {
        private static List<char> excludeCharsList = new List<char> { ' ', '\n', '\t', '\r' };
        private static string text = "";
        
        static void Main(string[] args)
        {            
            if (args.Count() > 0)
            {
               try
                {
                    text = System.IO.File.ReadAllText(args[0]);
                }
                catch (System.IO.FileNotFoundException)
                {
                    Console.WriteLine($"File {args[0]} not found");
                    return;
                }

                if ((args.Count() == 2) && (args[1] != null) && (args[1].Equals("ignorecase")))
                    text = text.ToUpper();

                DirectorySolution();
                LinqSolution();
            }
            else
            {
                Console.WriteLine("File name expected as an argument");
            }
        }
        public static void DirectorySolution()
        {

            /* Solution without using LINQ */
            Console.WriteLine("===========================");
            Console.WriteLine("Solution using Dictonary");

            int charCount = 0;
            var charFrequency = new Dictionary<char, int>();
            foreach (var c in text)
            {
                if (!excludeCharsList.Contains(c))
                {
                    if (charFrequency.ContainsKey(c))
                        charFrequency[c]++;
                    else
                        charFrequency[c] = 1;
                    charCount++;
                }
            }
            Console.WriteLine("Total Number of Charachters " + charCount);

            foreach (KeyValuePair<char, int> keyValuePair in charFrequency.OrderByDescending(key => key.Value).Take(10))
            {
                Console.WriteLine("{0} ({1})", keyValuePair.Key, keyValuePair.Value);
            }
        }

        public static void LinqSolution()
        {
            Console.WriteLine("===========================");

            /* Solution using LINQ */
            Console.WriteLine("Solution using LINQ");
            Console.WriteLine("Total Number of Charachters " + text.Select(x => x).Where(x => !excludeCharsList.Contains(x)).Count());

            var alphabetsCount = text.GroupBy(x => x).Where(x => !excludeCharsList.Contains(x.Key))
                          .Select(x => new
                          {
                              Character = x.Key,
                              Count = x.Count()
                          });

            foreach (var keyValuePair in alphabetsCount.OrderByDescending(key => key.Count).Take(10))
            {
                Console.WriteLine("{0} ({1})", keyValuePair.Character, keyValuePair.Count);
            }
            Console.WriteLine("===========================");
        }
    }   
}
