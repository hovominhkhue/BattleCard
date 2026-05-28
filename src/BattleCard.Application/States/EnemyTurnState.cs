namespace BattleCard.Application.States;

using BattleCard.Application.Combat;

public class EnemyTurnState : ICombatState
{
    public void Enter(CombatContext context)
    {
    }

    public ICombatState Execute(CombatContext context)
    {
        foreach (var enemy in context.EnemiesAlive.ToList())
        {
            if (!enemy.IsAlive)
                continue;

            var damage = new Damage(enemy.BaseDamage.Value);
            context.Hero.TakeDamage(damage);
        }

        if (!context.Hero.IsAlive)
            return new DefeatState();

        return new PlayerTurnState();
    }
}