using System;
using System.Collections.Generic;
using System.Linq;

Dictionary<string, Dictionary<string, HashSet<string>>> vLoggers =
    new Dictionary<string, Dictionary<string, HashSet<string>>>();

string input;

while ((input = Console.ReadLine()) != "Statistics")
{
    string[] commandArguments = input.Split(" ", 3);

    string firstVloggerName = commandArguments[0];
    string command = commandArguments[1];
    string secondVloggerName = commandArguments[2];

    if (command == "joined")
    {
        if (!vLoggers.ContainsKey(firstVloggerName))
        {
            vLoggers[firstVloggerName] = new Dictionary<string, HashSet<string>>();
            vLoggers[firstVloggerName]["followers"] = new HashSet<string>();
            vLoggers[firstVloggerName]["following"] = new HashSet<string>();
        }
    }
    else if (command == "followed")
    {
        if (firstVloggerName != secondVloggerName && vLoggers.ContainsKey(firstVloggerName) && vLoggers.ContainsKey(secondVloggerName))
        {
            vLoggers[firstVloggerName]["following"].Add(secondVloggerName);
            vLoggers[secondVloggerName]["followers"].Add(firstVloggerName);
        }
    }
}

Console.WriteLine($"The V-Logger has a total of {vLoggers.Count} vloggers in its logs.");

int number = 0;

foreach (var (name, info) in vLoggers
             .OrderByDescending(x => x.Value["followers"].Count)
             .ThenBy(x => x.Value["following"].Count))
{
    number++;

    Console.WriteLine($"{number}. {name} : {info["followers"].Count} followers, {info["following"].Count} following");

    if (number == 1)
    {
        foreach (var folowerName in info["followers"].OrderBy(x => x))
        {
            Console.WriteLine($"*  {folowerName}");
        }
    }
}
