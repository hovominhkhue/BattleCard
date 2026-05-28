namespace BattleCard.Application.Commands;

using BattleCard.Application.Combat;

public interface ICommand
{
    CombatResult Execute(CombatContext context);
}