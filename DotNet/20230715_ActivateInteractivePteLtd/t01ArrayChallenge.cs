using System;

class MainClass
{

    public static string ArrayChallenge(string[] strArr)
    {
        string sequence = strArr[0];
        string dictionary = strArr[1];

        string[] words = dictionary.Split(',');

        foreach (string word in words)
        {
            if (sequence.StartsWith(word) && dictionary.Contains(sequence.Substring(word.Length)))
            {
                return $"{word},{sequence.Substring(word.Length)}";
            }
        }

        return "not possible";
    }

    static void Main()
    {
        /*
        string[] input = { "hellocat", "apple,bat,cat,goodbye,hello,yellow,why" };
        string result = ArrayChallenge(input);
        Console.WriteLine(result);
        */
        Console.WriteLine(ArrayChallenge(Console.ReadLine().Split()));
    }

}
