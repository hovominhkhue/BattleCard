namespace BattleCard.Application.Commands;

using BattleCard.Application.Actions;
using BattleCard.Application.Combat;

public class AttackCommand : ICommand
{
    public CombatResult Execute(CombatContext context)
    {
        var hero = context.Hero;
        var target = context.EnemiesAlive.FirstOrDefault();

        if (target == null)
            return new CombatResult(hero, hero, 0, false, "No enemies to attack");

        var action = new BasicAttackAction();
        var result = action.Execute(hero, target);

        if (!target.IsAlive)
            context.RemoveDefeatedEnemy(target);

        return result;
    }
}