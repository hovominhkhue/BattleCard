namespace BattleCard.Application.States;

using BattleCard.Application.Combat;

public class VictoryState : ICombatState
{
    public void Enter(CombatContext context)
    {
    }

    public ICombatState Execute(CombatContext context)
    {
        return this;
    }
}