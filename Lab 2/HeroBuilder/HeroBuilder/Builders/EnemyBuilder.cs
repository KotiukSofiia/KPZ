using System;
using System.Collections.Generic;

public class EnemyBuilder : ICharacterBuilder
{
    private Character _enemy;

    public EnemyBuilder()
    {
        _enemy = new Character();
    }

    public ICharacterBuilder SetHeight(int height)
    {
        _enemy.Height = height;
        return this;
    }

    public ICharacterBuilder SetBuild(string build)
    {
        _enemy.Build = build;
        return this;
    }

    public ICharacterBuilder SetHairColor(string color)
    {
        _enemy.HairColor = color;
        return this;
    }

    public ICharacterBuilder SetEyeColor(string color)
    {
        _enemy.EyeColor = color;
        return this;
    }

    public ICharacterBuilder SetClothes(string clothes)
    {
        _enemy.Clothes = clothes;
        return this;
    }

    public ICharacterBuilder SetInventory(List<string> inventory)
    {
        _enemy.Inventory = inventory;
        return this;
    }

    public Character Build()
    {
        _enemy.EvilDeeds = new List<string> { "Burn the city", "He stole money from banks and abused people." };
        return _enemy;
    }
}
