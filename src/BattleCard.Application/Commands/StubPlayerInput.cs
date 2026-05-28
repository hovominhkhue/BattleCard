namespace BattleCard.Application.Commands;

using BattleCard.Application.Combat;

public class StubPlayerInput : IPlayerInput
{
    public string GetPlayerChoice(CombatContext context)
    {
        return "1";
    }
}