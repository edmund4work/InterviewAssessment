Write a C# program which reads a line of input of words and separated by a space. The program will first split each word into 2 new words by the Capital letter in the middle of the original word, for example "RedShip" to "Red" and "Ship". The program should count the number of times each new word occurs. At the end, it should output a list of
the words and the counts, with the most frequent word at the top.
For instance, if the input is:
RedShip RedCar BlueBikes YellowBikes YellowCar RedCar
The output should be:
Red 3
Car 3
Yellow 2
Bikes 2
Ship 1
Blue 1


---------
Sample from chatGPT

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the input string:");
        string input = Console.ReadLine();

        // Split input into words
        string[] words = input.Split(' ');

        // Dictionary to store the word counts
        Dictionary<string, int> wordCounts = new Dictionary<string, int>();

        foreach (string word in words)
        {
            // Split the word by capital letters
            string[] splitWords = Regex.Split(word, "(?=[A-Z])");

            // Count each part
            foreach (string part in splitWords)
            {
                if (!string.IsNullOrEmpty(part))
                {
                    if (wordCounts.ContainsKey(part))
                    {
                        wordCounts[part]++;
                    }
                    else
                    {
                        wordCounts[part] = 1;
                    }
                }
            }
        }

        // Sort the word counts by descending frequency
        var sortedWordCounts = wordCounts.OrderByDescending(kvp => kvp.Value);

        // Output the results
        foreach (var kvp in sortedWordCounts)
        {
            Console.WriteLine($"{kvp.Key} {kvp.Value}");
        }
    }
}
