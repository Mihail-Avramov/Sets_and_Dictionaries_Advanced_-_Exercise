using System;
using System.Collections.Generic;

string text = Console.ReadLine();

SortedDictionary<char,int> charCounter = new SortedDictionary<char, int>();

foreach (var ch in text)
{
    if (!charCounter.ContainsKey(ch))
    {
        charCounter[ch] = 0;
    }

    charCounter[ch]++;
}

foreach (var (ch, count) in charCounter)
{
    Console.WriteLine($"{ch}: {count} time/s");
}