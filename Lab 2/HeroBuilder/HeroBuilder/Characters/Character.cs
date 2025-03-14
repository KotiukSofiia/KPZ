using System;
using System.Collections.Generic;

public class Character
{
    public int Height { get; set; }
    public string Build { get; set; }
    public string HairColor { get; set; }
    public string EyeColor { get; set; }
    public string Clothes { get; set; }
    public List<string> Inventory { get; set; }
    public List<string> GoodDeeds { get; set; }
    public List<string> EvilDeeds { get; set; }

    public void DisplayCharacterInfo()
    {
        Console.WriteLine($"Height: {Height}, Build: {Build}, Hair Color: {HairColor}, Eye Color: {EyeColor}");
        Console.WriteLine($"Clothes: {Clothes}");
        Console.WriteLine("Inventory: " + string.Join(", ", Inventory));
        Console.WriteLine("Good Deeds: " + string.Join(", ", GoodDeeds ?? new List<string>()));
        Console.WriteLine("Evil Deeds: " + string.Join(", ", EvilDeeds ?? new List<string>()));
    }
}
