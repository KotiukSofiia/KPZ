using System;
using System.Collections.Generic;

public class HeroBuilder : ICharacterBuilder
{
    private Character _hero;

    public HeroBuilder()
    {
        _hero = new Character();
    }

    public ICharacterBuilder SetHeight(int height)
    {
        _hero.Height = height;
        return this;
    }

    public ICharacterBuilder SetBuild(string build)
    {
        _hero.Build = build;
        return this;
    }

    public ICharacterBuilder SetHairColor(string color)
    {
        _hero.HairColor = color;
        return this;
    }

    public ICharacterBuilder SetEyeColor(string color)
    {
        _hero.EyeColor = color;
        return this;
    }

    public ICharacterBuilder SetClothes(string clothes)
    {
        _hero.Clothes = clothes;
        return this;
    }

    public ICharacterBuilder SetInventory(List<string> inventory)
    {
        _hero.Inventory = inventory;
        return this;
    }

    public Character Build()
    {
        _hero.GoodDeeds = new List<string> { "Save the city", "Helping those in need." };
        return _hero;
    }
}
