/* SWORD Programming Test 
 * Mukta S. Aphale */

using System.Collections;

namespace FrequencyAnalysis
{
    public class Analyser
    {
        private List<char> excludeCharsList = new List<char> { ' ', '\n', '\t', '\r' };
        private string text { get; set; }

        private int totalCharCount = 0;

        private int totalCharCountLinq = 0;

        public Analyser(string text)
        {
            this.text = text;
        }

        public int GetTotalCharCount()
        {
            return totalCharCount;
        }

        public int getTotalCharCountLinq() 
        {
            return totalCharCountLinq;
                
        }

        public Dictionary<char, int> GetCharCount()
        {
            /* Solution without using LINQ */           
             var charFrequency = new Dictionary<char, int>();
            foreach (var c in text)
            {
                if (!excludeCharsList.Contains(c))
                {
                    if (charFrequency.ContainsKey(c))
                        charFrequency[c]++;
                    else
                        charFrequency[c] = 1;
                    this.totalCharCount++;
                }
            }
            return charFrequency;
        }

        public Dictionary<char, int> GetCharCountLinq()
        {
             /* Solution using LINQ */
            totalCharCountLinq = text.Select(x => x).Where(x => !excludeCharsList.Contains(x)).Count();

            Dictionary<char, int> alphabetsCount = text
                                .GroupBy(x => x)
                                .Where(x => !excludeCharsList.Contains(x.Key))
                                .ToDictionary(x => x.Key, x => x.Count());

            return alphabetsCount;
        }
    }   
}
