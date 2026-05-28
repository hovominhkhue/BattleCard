namespace BattleCard.Application.Actions;

using BattleCard.Application.Combat;
using BattleCard.Domain.Entities.Base;

public interface ICombatAction
{
    string Name { get; }
    
    bool CanExecute(Character actor);
    
    CombatResult Execute(Character actor, Character target);
}