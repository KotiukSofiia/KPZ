using System;
namespace Decorator
{
	public class Warrior : IHero
    {
        public string GetDescription()
        {
            return "Warrior: Strong and brave.";
        }
    }
}

