namespace BattleCard.Application.Commands;

using BattleCard.Application.Actions;
using BattleCard.Application.Combat;
using BattleCard.Application.Events;

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

        // Publier l'événement dégâts
        context.Publisher.PublishDamageDealt(
            new DamageDealtEvent(hero, target, result.DamageDealt)
        );

        if (!target.IsAlive)
            context.RemoveDefeatedEnemy(target);

        return result;
    }
}