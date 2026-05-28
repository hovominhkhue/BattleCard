namespace BattleCard.Application.States;

using BattleCard.Application.Actions;
using BattleCard.Application.Combat;

public class PlayerTurnState : ICombatState
{
    public void Enter(CombatContext context)
    {
    }

    public ICombatState Execute(CombatContext context)
    {
        if (context.EnemiesAlive.Count == 0)
        {
            if (context.CurrentWave == 3)
                return new VictoryState();
            return new BetweenWavesState();
        }

        var hero = context.Hero;
        var firstAliveEnemy = context.EnemiesAlive.FirstOrDefault();

        if (firstAliveEnemy == null)
            return new BetweenWavesState();

        var action = new BasicAttackAction();
        action.Execute(hero, firstAliveEnemy);

        if (!firstAliveEnemy.IsAlive)
            context.RemoveDefeatedEnemy(firstAliveEnemy);

        hero.DecrementSkillCooldown();

        if (!hero.IsAlive)
            return new DefeatState();

        if (context.IsWaveCleared)
        {
            if (context.CurrentWave == 3)
                return new VictoryState();

            return new BetweenWavesState();
        }

        return new EnemyTurnState();
    }
}