namespace BattleCard.Application.Combat;

using BattleCard.Application.Events;
using BattleCard.Domain.Entities.Base;

public class CombatContext
{
    public Hero Hero { get; private set; }
    public List<Enemy> EnemiesAlive { get; private set; }
    public int CurrentWave { get; private set; }
    public CombatEventPublisher Publisher { get; private set; }

    public CombatContext(Hero hero, int wave, List<Enemy> enemies, CombatEventPublisher publisher)
    {
        Hero = hero;
        CurrentWave = wave;
        EnemiesAlive = enemies;
        Publisher = publisher;
    }

    public bool IsWaveCleared => EnemiesAlive.Count == 0;

    public bool IsCombatOver => !Hero.IsAlive;

    public void RemoveDefeatedEnemy(Enemy enemy)
    {
        EnemiesAlive.Remove(enemy);
        Publisher.PublishCharacterDefeated(new CharacterDefeatedEvent(enemy));
    }

    public void NextWave()
    {
        CurrentWave++;
    }
}