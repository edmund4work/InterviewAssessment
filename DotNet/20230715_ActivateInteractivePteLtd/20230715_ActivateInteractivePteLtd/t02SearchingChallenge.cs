using System;

class MainClass {

  public static string SearchingChallenge(string str) {
    int maxLength = 0;
    string longestPalindrome = "none";

    for (int i = 0; i < str.Length; i++)
    {
        for (int j = i + 1; j <= str.Length; j++)
        {
            string substring = str.Substring(i, j - i);
            if (IsPalindrome(substring) && substring.Length > maxLength)
            {
                maxLength = substring.Length;
                longestPalindrome = substring;
            }
        }
    }

    string str = longestPalindrome;
    string reversedStr = new string(str.Reverse().ToArray());

    return reversedStr + ":7z0o39gyk";
  }

  static bool IsPalindrome(string str)
  {
    int left = 0;
    int right = str.Length - 1;

    while (left < right)
    {
        if (str[left] != str[right])
            return false;

        left++;
        right--;
    }

    return true;
  }

  static void Main() {
    Console.WriteLine(SearchingChallenge(Console.ReadLine()));
  } 

}
