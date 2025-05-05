using static System.Net.Mime.MediaTypeNames;

namespace FrequencyAnalysis
{
    class MainProgram
    {
        static void Main(string[] args)
        {
            string text = "";

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

                Analyser analyser = new Analyser(text);

                 Console.WriteLine("Solution using Dictonary");
                var charFrequency = analyser.DirectorySolution();

                Console.WriteLine("Total Number of Charachters " + analyser.GetCharCountDirectory());
                foreach (KeyValuePair<char, int> keyValuePair in charFrequency.OrderByDescending(key => key.Value).Take(10))
                {
                    Console.WriteLine("{0} ({1})", keyValuePair.Key, keyValuePair.Value);
                }

                Console.WriteLine("===========================");
                Console.WriteLine("Solution using LINQ");
                
                var alphabetsCount = analyser.LinqSolution();

                Console.WriteLine("Total Number of Charachters " + analyser.getCharCountLinq());
                foreach (KeyValuePair<char, int> keyValuePair in alphabetsCount.OrderByDescending(key => key.Value).Take(10))
                {
                    Console.WriteLine("{0} ({1})", keyValuePair.Key, keyValuePair.Value);
                }

            }
            else
            {
                Console.WriteLine("File name expected as an argument");
            }
        }
    }
}