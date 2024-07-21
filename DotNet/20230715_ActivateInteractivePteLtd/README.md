1. 
Have the function ArrayChallenge(strArr) read the array of strings stored in strArr, which will contain 2 elements: the first element will be a sequence of characters, and the second element will be a long string of comma-separated words, in alphabetical order, that represents a dictionary of some arbitrary length. For example: strArr can be: ["hellocat", "apple,bat,cat,goodbye,hello,yellow,why"]. Your goal is to determine if the first element in the input can be split into two words, where both words exist in the dictionary that is provided in the second input. In this example, the first element can be split into two words: hello and cat because both of those words are in the dictionary.

Your program should return the two words that exist in the dictionary separated by a comma. So for the example above, your program should return hello,cat. There will only be one correct way to split the first element of characters into two words. If there is no way to split string into two words that exist in the dictionary, return the string not possible. The first element itself will never exist in the dictionary as a real word.


_**Sample Code:**__
```
using System;

class MainClass {

  public static string ArrayChallenge(string[] strArr) {

    // code goes here  
    return strArr[0];

  }

  static void Main() {  

    // keep this function call here
    
    Console.WriteLine(ArrayChallenge(Console.ReadLine()));
    
  } 

}
```

2.
Have the function SearchingChallenge(str) take the str parameter being passed and find the longest palindromic substring, which means the longest substring which is read the same forwards as it is backwards. For example: if str is "abracecars" then your program should return the string racecar because it is the longest palindrome within the input string.

The input will only contain lowercase alphabetic characters. The longest palindromic substring will always be unique, but if there is none that is longer than 2 characters, return the string none.


_**Sample Code:**__
```
class MainClass {

  public static string SearchingChallenge(string str) {

    // code goes here  
    return str;

  }

  static void Main() {  

    // keep this function call here
    Console.WriteLine(SearchingChallenge(Console.ReadLine()));
    
  } 

}
```


3.
In this MySQL challenge, your query should return the vendor information along with the values from the table cb_vendorinformation. You should combine the values of the two tables based on the GroupID column. The final query should consolidate the rows to be grouped by FirstName, and a Count column should be added at the end that adds up the number of times that person shows up in the table. The output table should be sorted by the Count column in ascending order and then sorted by CompanyName in alphabetical order. Your output should look like below: 




4.
Have the function ArrayChallenge(strArr) take strArr parameter being passed which will be an array containing one letter followed by 12 numbers representing a Tetris piece followed by the fill levels for the 12 columns of the board. Calculate the greatest number of horizontal lines that can be completed when the piece arrives at the bottom assuming it is dropped immediately after being rotated and moved horizontally from the top. Tricky combinations of vertical and horizontal movements are excluded. The piece types are represented by capital letters. 


_**Sample Code:**__
```
using System;

class MainClass {

  public static string ArrayChallenge(string[] strArr) {

    // code goes here  
    return strArr[0];

  }

  static void Main() {  

    // keep this function call here
    Console.WriteLine(ArrayChallenge(Console.ReadLine()));
    
  } 

}