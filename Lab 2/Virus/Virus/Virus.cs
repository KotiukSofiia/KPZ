using System;
using System.Collections.Generic;

public class Virus : ICloneable
{
    public string Name { get; set; }
    public string Species { get; set; }
    public int Age { get; set; }
    public double Weight { get; set; }
    public List<Virus> Children { get; set; }

    public Virus(string name, string species, int age, double weight)
    {
        Name = name;
        Species = species;
        Age = age;
        Weight = weight;
        Children = new List<Virus>();
    }

    public object Clone()
    {
        Virus clonedVirus = (Virus)this.MemberwiseClone();

        clonedVirus.Children = new List<Virus>();
        foreach (var child in this.Children)
        {
            clonedVirus.Children.Add((Virus)child.Clone());
        }

        return clonedVirus;
    }

    public void AddChild(Virus child)
    {
        Children.Add(child);
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Virus Name: {Name}, Species: {Species}, Age: {Age}, Weight: {Weight}");
        Console.WriteLine($"Children count: {Children.Count}");
        foreach (var child in Children)
        {
            Console.WriteLine($"- Child: {child.Name}");
            child.DisplayInfo();
        }
    }
}
