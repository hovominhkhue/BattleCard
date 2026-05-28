namespace BattleCard.Application.Combat;

using BattleCard.Domain.Entities.Base;

public class CombatContext
{
    public Hero Hero { get; private set; }
    public List<Enemy> EnemiesAlive { get; private set; }
    public int CurrentWave { get; private set; }

    public CombatContext(Hero hero, int wave, List<Enemy> enemies)
    {
        Hero = hero;
        CurrentWave = wave;
        EnemiesAlive = enemies;
    }

    public bool IsWaveCleared => EnemiesAlive.Count == 0;

    public bool IsCombatOver => !Hero.IsAlive;

    public void RemoveDefeatedEnemy(Enemy enemy)
    {
        EnemiesAlive.Remove(enemy);
    }

    public void NextWave()
    {
        CurrentWave++;
    }
}