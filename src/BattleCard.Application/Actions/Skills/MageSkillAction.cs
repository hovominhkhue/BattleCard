namespace BattleCard.Application.Actions;

using BattleCard.Application.Combat;
using BattleCard.Domain.Entities.Base;

public class MageSkillAction : ICombatAction
{
    private const int LightningDamage = 30;

    public string Name => "Lightning";

    public bool CanExecute(Character actor)
    {
        if (actor is not Hero hero)
            return false;

        return hero.SkillCooldown.IsReady && actor.IsAlive;
    }

    public CombatResult Execute(Character actor, Character target)
    {
        var hero = (Hero)actor;
        int armorReduction = target.Armor / 2;
        int skillDamage = LightningDamage - armorReduction;
        
        var damage = new Damage(skillDamage);

        target.TakeDamage(damage);
        hero.DecrementSkillCooldown();

        string message = $"{actor.Name} casts Lightning on {target.Name} for {damage.Value} damage";

        return new CombatResult(
            actor,
            target,
            damage.Value,
            !target.IsAlive,
            message
        );
    }
}