using System;
public class CharacterDirector
{
    private ICharacterBuilder _builder;

    public CharacterDirector(ICharacterBuilder builder)
    {
        _builder = builder;
    }

    public Character ConstructCharacter()
    {
        return _builder.SetHeight(180)
                        .SetBuild("Muscular")
                        .SetHairColor("Black")
                        .SetEyeColor("Gray")
                        .SetClothes("Spider-Man costume")
                        .SetInventory(new List<string> { "Power", "Spider Web", "Sixth Sense" })
                        .Build();
    }
}