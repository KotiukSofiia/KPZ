using System;
namespace Decorator
{
    public class ClothingDecorator : IHero
    {
        private readonly IHero _hero;
        private static List<string> _clothingList = new List<string>();

        public ClothingDecorator(IHero hero, params string[] clothing)
        {
            _hero = hero;

            foreach (var item in clothing)
            {
                if (!_clothingList.Contains(item))
                {
                    _clothingList.Add(item);
                }
            }
        }

        public string GetDescription()
        {
            string clothingDescription = _clothingList.Count > 0 ? "Wearing: " + string.Join(", ", _clothingList) + ". " : string.Empty;
            return $"{_hero.GetDescription()} {clothingDescription}";
        }
    }


}

