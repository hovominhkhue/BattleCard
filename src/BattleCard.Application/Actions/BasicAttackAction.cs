namespace BattleCard.Application.Actions;

using BattleCard.Application.Combat;
using BattleCard.Domain.Entities.Base;

public class BasicAttackAction : ICombatAction
{
    public string Name => "Attack";

    public bool CanExecute(Character actor)
    {
        return actor.IsAlive;
    }

    public CombatResult Execute(Character actor, Character target)
    {
        var damage = new Damage(actor.BaseDamage.Value);
        target.TakeDamage(damage);

        string message = $"{actor.Name} attacks {target.Name} for {damage.Value} damage";
        
        return new CombatResult(
            actor,
            target,
            damage.Value,
            !target.IsAlive,
            message
        );
    }
}