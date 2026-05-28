namespace BattleCard.Application.Factories;

using BattleCard.Domain.Entities.Base;
using BattleCard.Domain.Entities.Enemies;

public class EnemyFactory : IEnemyFactory
{
    private readonly Dictionary<string, Func<Enemy>> _registry;

    public EnemyFactory()
    {
        _registry = new Dictionary<string, Func<Enemy>>
        {
            { "goblin", () => new Goblin() },
            { "goblin_archer", () => new GoblinArcher() },
            { "orc_boss", () => new OrcBoss() }
        };
    }

    public Enemy Create(string enemyType)
    {
        if (!_registry.TryGetValue(enemyType.ToLower(), out var factory))
            throw new ArgumentException($"Unknown enemy type: {enemyType}");

        return factory();
    }
}