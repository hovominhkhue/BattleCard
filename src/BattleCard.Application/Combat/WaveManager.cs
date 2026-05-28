namespace BattleCard.Application.Combat;

using BattleCard.Application.Factories;
using BattleCard.Domain.Entities.Base;

public class WaveManager
{
    private readonly IEnemyFactory _enemyFactory;

    public WaveManager(IEnemyFactory enemyFactory)
    {
        _enemyFactory = enemyFactory;
    }

    public List<Enemy> CreateWave(int waveNumber)
    {
        return waveNumber switch
        {
            1 => new List<Enemy> { _enemyFactory.Create("goblin") },
            2 => new List<Enemy> { _enemyFactory.Create("goblin"), _enemyFactory.Create("goblin_archer") },
            3 => new List<Enemy> { _enemyFactory.Create("orc_boss") },
            _ => throw new ArgumentException($"Wave {waveNumber} does not exist")
        };
    }
}