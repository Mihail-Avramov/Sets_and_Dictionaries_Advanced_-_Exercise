using System;
using System.Collections.Generic;

int n = int.Parse(Console.ReadLine());

Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

for (int i = 0; i < n; i++)
{
    string[] inputArguments = Console.ReadLine().Split(" -> ");

    string color = inputArguments[0];

    if (!wardrobe.ContainsKey(color))
    {
        wardrobe[color] = new Dictionary<string, int>();
    }

    string[] clothesToAdd = inputArguments[1].Split(",");

    foreach (var cloth in clothesToAdd)
    {
        if (!wardrobe[color].ContainsKey(cloth))
        {
            wardrobe[color].Add(cloth, 0);
        }

        wardrobe[color][cloth] ++;
    }
}

string[] findClothArguments = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
string findColor = findClothArguments[0];
string findCloth = findClothArguments[1];

foreach (var (color, clothes) in wardrobe)
{
    Console.WriteLine($"{color} clothes:");
    foreach (var (cloth, count) in clothes)
    {
        if (cloth == findCloth && color == findColor)
        {
            Console.WriteLine($"* {cloth} - {count} (found!)");
        }
        else
        {
            Console.WriteLine($"* {cloth} - {count}");
        }
    }
}