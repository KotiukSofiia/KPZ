using System;

class Program
{
    static void Main()
    {
        Virus parentVirus = new Virus("NecroVirus", "Necrosis", 5, 20.5);

        Virus childVirus1 = new Virus("FrostbiteVirus", "Frost", 2, 15.0);
        parentVirus.AddChild(childVirus1);

        Virus childVirus2 = new Virus("ShadowVirus", "Shadow", 1, 10.0);
        childVirus1.AddChild(childVirus2);

        Console.WriteLine("Original Virus Family:");
        parentVirus.DisplayInfo();

        Virus clonedVirus = (Virus)parentVirus.Clone();

        Console.WriteLine("\nCloned Virus Family:");
        clonedVirus.DisplayInfo();

        Console.WriteLine("\nChecking if children are cloned:");
        Console.WriteLine($"Original First Child Name: {parentVirus.Children[0].Name}, Cloned First Child Name: {clonedVirus.Children[0].Name}");

        Console.WriteLine($"Original Child of FrostbiteVirus Name: {parentVirus.Children[0].Children[0].Name}, Cloned Child of FrostbiteVirus Name: {clonedVirus.Children[0].Children[0].Name}");
        Console.ReadLine();

    }
}
