namespace BattleCard.Application.Factories;

using BattleCard.Domain.Entities.Base;
using BattleCard.Domain.Entities.Enemies;
using BattleCard.Application.Ai;

public class EnemyFactory : IEnemyFactory
{
    private readonly Dictionary<string, Func<Enemy>> _registry = new()
    {
        { "goblin", () => new Goblin { AiStrategy = new RandomAttackAi() } },
        { "goblin_archer", () => new GoblinArcher { AiStrategy = new RandomAttackAi() } },
        { "orc_boss", () => new OrcBoss { AiStrategy = new PowerfulAttackAi() } }
    };

    public Enemy Create(string type)
    {
        if (!_registry.TryGetValue(type.ToLower(), out var factory))
            throw new ArgumentException($"Unknown enemy type: {type}");

        return factory();
    }
}