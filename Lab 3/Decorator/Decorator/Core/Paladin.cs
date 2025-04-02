using System;
namespace Decorator
{
	public class Paladin : IHero
    {
        public string GetDescription()
        {
            return "Paladin: A holy warrior with a sense of justice.";
        }
    }
}

