namespace BattleCard.Application.Factories;

using BattleCard.Domain.Entities.Base;
using BattleCard.Domain.Entities.Heroes;
using BattleCard.Domain.Enums;

public class HeroFactory : IHeroFactory
{
    private readonly Dictionary<HeroClass, Func<string, Hero>> _registry;

    public HeroFactory()
    {
        _registry = new Dictionary<HeroClass, Func<string, Hero>>
        {
            { HeroClass.Warrior, name => new Warrior(name) },
            { HeroClass.Mage, name => new Mage(name) },
            { HeroClass.Thief, name => new Thief(name) }
        };
    }

    public Hero Create(HeroClass heroClass, string name)
    {
        if (!_registry.TryGetValue(heroClass, out var factory))
            throw new ArgumentException($"Unknown hero class: {heroClass}");

        return factory(name);
    }
}