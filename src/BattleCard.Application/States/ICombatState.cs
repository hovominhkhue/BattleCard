namespace BattleCard.Application.States;

using BattleCard.Application.Combat;

public interface ICombatState
{
    void Enter(CombatContext context);
    
    ICombatState Execute(CombatContext context);
}