/* SWORD Programming Test 
 * Mukta S. Aphale */

using System.Collections;

namespace FrequencyAnalysis
{
    class FrequencyAnalysis
    {
        private List<char> excludeCharsList = new List<char> { ' ', '\n', '\t', '\r' };
        private string text { get; set; }

        private int charCountDirectory = 0;

        private int charCountLinq = 0;

        public FrequencyAnalysis(string text)
        {
            this.text = text;
        }

        public int GetCharCountDirectory()
        {
            return charCountDirectory;
        }

        public int getCharCountLinq() 
        {
            return charCountLinq;
                
        }

        public Dictionary<char, int> DirectorySolution()
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
                    this.charCountDirectory++;
                }
            }
            return charFrequency;
        }

        public Dictionary<char, int> LinqSolution()
        {
             /* Solution using LINQ */
            charCountLinq = text.Select(x => x).Where(x => !excludeCharsList.Contains(x)).Count();

            Dictionary<char, int> alphabetsCount = text
                                .GroupBy(x => x)
                                .Where(x => !excludeCharsList.Contains(x.Key))
                                .ToDictionary(x => x.Key, x => x.Count());

            return alphabetsCount;
        }
    }   
}
