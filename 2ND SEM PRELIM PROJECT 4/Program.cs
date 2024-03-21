using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2ND_SEM_PRELIM_PROJECT_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Tiyan Text");
            Console.Write("Enter the Path to the Text File: ");
            string filePath = Console.ReadLine();


            while (!File.Exists(filePath))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Invalid file path. Please try again.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("▒▒▒▄██████████████▄▒▒▒ ▒▒▒▄██████████████▄▒▒▒");
                Console.WriteLine("▒▒▐███▒▒▒▀▒▒▀▒▒▒███▌▒▒ ▒▒▐███▒▒▒▀▒▒▀▒▒▒███▌▒▒");
                Console.WriteLine("▒▒▒██▒▒▀▀▀▀▀▀▀▀▒▒██▒▒▒ ▒▒▒██▒▒▀▀▀▀▀▀▀▀▒▒██▒▒▒");
                Console.WriteLine("▒▒▒▒▀████████████▀▒▒▒▒ ▒▒▒▒▀████████████▀▒▒▒▒");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("Enter the path to the text file: ");
                filePath = Console.ReadLine();


            }


            // Write analysis results to 'results.txt'
            WriteResultsToFile(filePath);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Analysis completed! Results written to 'results.txt'.");

            Console.ReadKey();

        }

        static string StreamRead(string file)
        {
            string readstring = "";
            using (StreamReader sr = new StreamReader(file))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    readstring = readstring + line;
                }
            }
            return (readstring);
        }
        static int[] CountUniqueWords(string text)
        {
            string[] splitText = text.Split(new[] { ' ', '\t', '\n', '\r', '.', ',', ';', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
            List<string> word = new List<string>();
            Array.Sort(splitText);
            word.Add(splitText[0]);
            for (int i = 1; i < splitText.Length; i++)
            {
                if (splitText[i] != splitText[i - 1])
                {
                    word.Add(splitText[i]);
                }
            }
            int[] uniquewordscount = new int[word.Count];
            for (int i = 0; i < word.Count; i++)
            {
                for (int j = 0; j < splitText.Length; j++)
                {
                    if (word[i] == splitText[j])
                        uniquewordscount[i]++;
                }
            }


            return uniquewordscount;
        }
        static int CountWords(string text)
        {
            string[] words = text.Split(new[] { ' ', '\t', '\n', '\r', '.', ',', ';', '!', '?', '"', '/', '|' }, StringSplitOptions.RemoveEmptyEntries);
            return words.Length;
        }
        static int CountSentences(string text)
        {
            string[] sentences = text.Split(new[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
            return sentences.Length - 1;
        }

        static void WriteResultsToFile(string fileContent)
        {
            string text = StreamRead(fileContent);
            text = text.ToLower();
            string[] words = text.Split(new[] { ' ', '\t', '\n', '\r', '.', ',', ';', '!', '?', '"', '/', '|' }, StringSplitOptions.RemoveEmptyEntries);
            List<string> word = new List<string>();
            Array.Sort(words);
            word.Add(words[0]);
            for (int i = 1; i < words.Length; i++)
            {
                if (words[i] != words[i - 1])
                {
                    word.Add(words[i]);
                }
            }

            int[] uniqueWordCounts = CountUniqueWords(text);

            using (StreamWriter writer = new StreamWriter("results.txt"))
            {
                writer.WriteLine($"Word count: {CountWords(text)}");
                writer.WriteLine($"Sentence count: {CountSentences(text)}");
                writer.WriteLine("Unique word counts:");

                for (int i = 0; i < word.Count && i < uniqueWordCounts.Length; i++)
                {
                    writer.WriteLine($"{word[i]}: {uniqueWordCounts[i]}");
                }
            }

        }
    }
}
