using System;
using System.Collections.Generic;

public interface ICharacterBuilder
{
    ICharacterBuilder SetHeight(int height);
    ICharacterBuilder SetBuild(string build);
    ICharacterBuilder SetHairColor(string color);
    ICharacterBuilder SetEyeColor(string color);
    ICharacterBuilder SetClothes(string clothes);
    ICharacterBuilder SetInventory(List<string> inventory);
    Character Build();
}
