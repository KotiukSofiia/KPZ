using System;
namespace Decorator
{
    public class ArtifactDecorator : IHero
    {
        private readonly IHero _hero;
        private static List<string> _artifactList = new List<string>();

        public ArtifactDecorator(IHero hero, params string[] artifacts)
        {
            _hero = hero;

            foreach (var item in artifacts)
            {
                if (!_artifactList.Contains(item))
                {
                    _artifactList.Add(item);
                }
            }
        }

        public string GetDescription()
        {
            string artifactDescription = _artifactList.Count > 0 ? "Artifact: " + string.Join(", ", _artifactList) + ". " : string.Empty;
            return $"{_hero.GetDescription()} {artifactDescription}";
        }
    }

}

