namespace BattleCard.Application.Actions;

using BattleCard.Application.Combat;
using BattleCard.Domain.Entities.Base;

public class WarriorSkillAction : ICombatAction
{
    private const double DamageMultiplier = 1.5;

    public string Name => "Heavy Strike";

    public bool CanExecute(Character actor)
    {
        if (actor is not Hero hero)
            return false;

        return hero.SkillCooldown.IsReady && actor.IsAlive;
    }

    public CombatResult Execute(Character actor, Character target)
    {
        var hero = (Hero)actor;
        int skillDamage = (int)(hero.BaseDamage.Value * DamageMultiplier);
        var damage = new Damage(skillDamage);

        target.TakeDamage(damage);
        hero.DecrementSkillCooldown();

        string message = $"{actor.Name} uses Heavy Strike on {target.Name} for {damage.Value} damage";

        return new CombatResult(
            actor,
            target,
            damage.Value,
            !target.IsAlive,
            message
        );
    }
}