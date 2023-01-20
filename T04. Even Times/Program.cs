using System;
using System.Collections.Generic;
using System.Linq;

int numberCount = int.Parse(Console.ReadLine());

Dictionary<int, int> numbers = new Dictionary<int, int>();

for (int i = 0; i < numberCount; i++)
{
    int number = int.Parse(Console.ReadLine());

    if (!numbers.ContainsKey(number))
    {
        numbers.Add(number, 0);
    }

    numbers[number]++;
}


//Console.WriteLine(numbers.First(x => x.Value % 2 == 0).Key);
Console.WriteLine(numbers.Single(x => x.Value % 2 == 0).Key);
