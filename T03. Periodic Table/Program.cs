using System;
using System.Collections.Generic;

int counter = int.Parse(Console.ReadLine());

SortedSet<string> periodicTable = new SortedSet<string>();

for (int i = 0; i < counter; i++)
{
    string[] chElements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

    foreach (var element in chElements)
    {
        periodicTable.Add(element);
    }
}

Console.WriteLine(string.Join(" ", periodicTable));