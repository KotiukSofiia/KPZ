using System;
using Decorator;

class Program
{
    static void Main()
    {
        IHero warrior = new Warrior();

        warrior = new ClothingDecorator(warrior, "steel armor", "leather boots");
        warrior = new WeaponDecorator(warrior, "sword");
        warrior = new ArtifactDecorator(warrior, "magic ring");

        Console.WriteLine(warrior.GetDescription());

        IHero mage = new Mage();

        mage = new ClothingDecorator(mage, "hat");
        mage = new WeaponDecorator(mage, "shield", "sword");
        mage = new ArtifactDecorator(mage, "amulet");

        Console.WriteLine(mage.GetDescription());

        IHero paladin = new Paladin();

        paladin = new ClothingDecorator(paladin, "armor");
        paladin = new WeaponDecorator(paladin, "hammer");
        paladin = new ArtifactDecorator(paladin, "liquid stone", "compass");

        Console.WriteLine(paladin.GetDescription());
        Console.ReadLine();
    }
}
