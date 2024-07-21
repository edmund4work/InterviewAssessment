using System;

class MainClass {

  public static string ArrayChallenge(string[] strArr) {
    char pieceType = strArr[0][0];
    int[] fillLevels = new int[12];

    for (int i = 0; i < 12; i++) {
      fillLevels[i] = int.Parse(strArr[i + 1]);
    }

    int[] pieceShape = GetPieceShape(pieceType);
    int maxCompletedLines = CalculateMaxCompletedLines(pieceShape, fillLevels);

    return maxCompletedLines.ToString();
  }

  static int[] GetPieceShape(char pieceType) {
    if (pieceType == 'I')
      return new int[] { 1, 1, 1, 1 };
    else if (pieceType == 'O')
      return new int[] { 2, 2 };
    else if (pieceType == 'T')
      return new int[] { 3, 2, 3 };
    else if (pieceType == 'S')
      return new int[] { 3, 2, 2 };
    else if (pieceType == 'Z')
      return new int[] { 2, 3, 3 };
    else if (pieceType == 'J')
      return new int[] { 2, 3, 2 };
    else if (pieceType == 'L')
      return new int[] { 2, 3, 2 };
    else
      return new int[] { }; // Invalid piece type
  }

  static int CalculateMaxCompletedLines(int[] pieceShape, int[] fillLevels) {
    int maxCompletedLines = 0;

    for (int i = 0; i < pieceShape.Length; i++) {
      int completedLines = fillLevels[i] - pieceShape[i];
      if (completedLines > maxCompletedLines)
        maxCompletedLines = completedLines;
    }

    return maxCompletedLines;
  }

  static void Main() {  
    Console.WriteLine(ArrayChallenge(Console.ReadLine()));
  } 

}
