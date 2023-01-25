using System;
using System.Collections.Generic;
using System.Linq;

SortedDictionary<string, SortedSet<string>> forcesList = new SortedDictionary<string, SortedSet<string>>();

string input = string.Empty;

while ((input = Console.ReadLine()) != "Lumpawaroo")
{
    if(input.Contains(" | "))
    {
        string[] commandArguments = input.Split(" | ", StringSplitOptions.RemoveEmptyEntries);

        string forceSide = commandArguments[0];
        string forceUser = commandArguments[1];

        if (!forcesList.Values.Any(u => u.Contains(forceUser)))
        {
            if (!forcesList.ContainsKey(forceSide))
            {
                forcesList[forceSide] = new SortedSet<string>();
            }

            forcesList[forceSide].Add(forceUser);
        }
        continue;
    }

    if (input.Contains(" -> "))
    {
        string[] commandArguments = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
        string forceSide = commandArguments[1];
        string forceUser = commandArguments[0];

        if (forcesList.Values.Any(u => u.Contains(forceUser)))
        {
            forcesList.Values.First(u => u.Remove(forceUser));
        }

        if (!forcesList.ContainsKey(forceSide))
        {
            forcesList[forceSide] = new SortedSet<string>();
        }

        forcesList[forceSide].Add(forceUser);

        Console.WriteLine($"{forceUser} joins the {forceSide} side!");
    }
}

foreach (var (forceName, userNames) in forcesList.OrderByDescending(u => u.Value.Count))
{
    if (userNames.Count > 0)
    {
        Console.WriteLine($"Side: {forceName}, Members: {userNames.Count}");
    }

    foreach (var userName in userNames)
    {
        Console.WriteLine($"! {userName}");
    }
}