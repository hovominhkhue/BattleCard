namespace BattleCard.Application.Combat;

using BattleCard.Domain.Entities.Base;
using BattleCard.Domain.Entities.Enemies;

public class WaveManager
{
    public List<Enemy> CreateWave(int waveNumber)
    {
        return waveNumber switch
        {
            1 => new List<Enemy> { new Goblin() },
            2 => new List<Enemy> { new Goblin(), new GoblinArcher() },
            3 => new List<Enemy> { new OrcBoss() },
            _ => throw new ArgumentException($"Wave {waveNumber} does not exist")
        };
    }
}