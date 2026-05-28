namespace BattleCard.Application.Actions;

using BattleCard.Application.Combat;
using BattleCard.Domain.Entities.Base;

public class HealAction : ICombatAction
{
    private const int HealAmount = 25;

    public string Name => "Use Healing Potion";

    public bool CanExecute(Character actor)
    {
        if (actor is not Hero hero)
            return false;

        return hero.HealingPotionsLeft > 0 && actor.IsAlive;
    }

    public CombatResult Execute(Character actor, Character target)
    {
        var hero = (Hero)actor;

        hero.Health.Heal(HealAmount);
        hero.UseHealingPotion();

        string message = $"{actor.Name} uses a Healing Potion and recovers {HealAmount} HP. Potions left: {hero.HealingPotionsLeft}";

        return new CombatResult(
            actor,
            actor,
            HealAmount,
            false,
            message
        );
    }
}