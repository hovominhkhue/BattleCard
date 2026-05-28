namespace BattleCard.Application.Combat;

using BattleCard.Domain.Entities.Base;

public class CombatSession
{
    private readonly WaveManager _waveManager;
    private const double BetweenWaveHealPercent = 0.2;

    public CombatSession()
    {
        _waveManager = new WaveManager();
    }

    public void Run(Hero hero)
    {
        for (int wave = 1; wave <= 3; wave++)
        {
            var enemies = _waveManager.CreateWave(wave);
            var context = new CombatContext(hero, wave, enemies);

            RunWave(context);

            if (!hero.IsAlive)
                break;

            if (wave < 3)
                ApplyBetweenWaveHeal(hero);
        }
    }

    private void RunWave(CombatContext context)
    {
        while (!context.IsCombatOver && !context.IsWaveCleared)
        {
            ExecutePlayerTurn(context);

            if (context.IsCombatOver || context.IsWaveCleared)
                break;

            ExecuteEnemyTurns(context);
        }
    }

    private void ExecutePlayerTurn(CombatContext context)
    {
        var hero = context.Hero;
        var firstAliveEnemy = context.EnemiesAlive.FirstOrDefault();

        if (firstAliveEnemy == null)
            return;

        var damage = new Damage(hero.BaseDamage.Value);
        firstAliveEnemy.TakeDamage(damage);

        if (!firstAliveEnemy.IsAlive)
            context.RemoveDefeatedEnemy(firstAliveEnemy);
    }

    private void ExecuteEnemyTurns(CombatContext context)
    {
        foreach (var enemy in context.EnemiesAlive.ToList())
        {
            if (!enemy.IsAlive)
                continue;

            var damage = new Damage(enemy.BaseDamage.Value);
            context.Hero.TakeDamage(damage);
        }
    }

    private void ApplyBetweenWaveHeal(Hero hero)
    {
        int healAmount = (int)Math.Ceiling(hero.Health.Maximum * BetweenWaveHealPercent);
        hero.Health.Heal(healAmount);
    }
}