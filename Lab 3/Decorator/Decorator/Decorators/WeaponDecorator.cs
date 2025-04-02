using System;
namespace Decorator
{
    public class WeaponDecorator : IHero
    {
        private readonly IHero _hero;
        private static List<string> _weaponList = new List<string>();

        public WeaponDecorator(IHero hero, params string[] weapons)
        {
            _hero = hero;

            foreach (var item in weapons)
            {
                if (!_weaponList.Contains(item))
                {
                    _weaponList.Add(item);
                }
            }
        }

        public string GetDescription()
        {
            string weaponDescription = _weaponList.Count > 0 ? "Weapon: " + string.Join(", ", _weaponList) + ". " : string.Empty;
            return $"{_hero.GetDescription()} {weaponDescription}";
        }
    }


}

