using System;
namespace Decorator
{
	public class Mage : IHero
    {
        public string GetDescription()
        {
            return "Mage: Wise and powerful in magic.";
        }
    }
}

