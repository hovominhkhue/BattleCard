namespace BattleCard.Application.Actions;

using BattleCard.Application.Combat;
using BattleCard.Domain.Entities.Base;

public class ThiefSkillAction : ICombatAction
{
    private const double CriticalChance = 0.30;
    private const int CriticalMultiplier = 2;
    private readonly Random _random;

    public string Name => "Backstab";

    public ThiefSkillAction(Random? random = null)
    {
        _random = random ?? new Random();
    }

    public bool CanExecute(Character actor)
    {
        if (actor is not Hero hero)
            return false;

        return hero.SkillCooldown.IsReady && actor.IsAlive;
    }

    public CombatResult Execute(Character actor, Character target)
    {
        var hero = (Hero)actor;
        
        bool isCritical = _random.NextDouble() < CriticalChance;
        int skillDamage = isCritical 
            ? (int)(hero.BaseDamage.Value * CriticalMultiplier)
            : hero.BaseDamage.Value;

        var damage = new Damage(skillDamage);
        target.TakeDamage(damage);
        hero.DecrementSkillCooldown();

        string critText = isCritical ? " (Critical!)" : "";
        string message = $"{actor.Name} uses Backstab on {target.Name} for {damage.Value} damage{critText}";

        return new CombatResult(
            actor,
            target,
            damage.Value,
            !target.IsAlive,
            message
        );
    }
}