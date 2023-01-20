using System;
using System.Collections.Generic;
using System.Linq;

HashSet<int> firstSet = new HashSet<int>();
HashSet<int> secondSet = new HashSet<int>();

string[] input = Console.ReadLine().Split(' ');

int firstNumber = int.Parse(input[0]);
int secondNumber = int.Parse(input[1]);

for (int n = 0; n < firstNumber; n++)
{
    firstSet.Add(int.Parse(Console.ReadLine()));
}

for (int m = 0; m < secondNumber; m++)
{
    secondSet.Add(int.Parse(Console.ReadLine()));
}

firstSet.IntersectWith(secondSet);

Console.WriteLine(string.Join(" ", firstSet));