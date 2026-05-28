namespace BattleCard.Application.Commands;

using BattleCard.Application.Combat;

public interface IPlayerInput
{
    string GetPlayerChoice(CombatContext context);
}