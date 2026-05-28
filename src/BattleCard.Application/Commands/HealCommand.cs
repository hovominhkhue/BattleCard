namespace BattleCard.Application.Commands;

using BattleCard.Application.Actions;
using BattleCard.Application.Combat;
using BattleCard.Domain.Entities.Base;

public class HealCommand : ICommand
{
    public CombatResult Execute(CombatContext context)
    {
        var hero = (Hero)context.Hero;

        var action = new HealAction();

        if (!action.CanExecute(hero))
            return new CombatResult(hero, hero, 0, false, "No healing potions left");

        var result = action.Execute(hero, hero);

        return result;
    }
}