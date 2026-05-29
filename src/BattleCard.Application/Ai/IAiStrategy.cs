namespace BattleCard.Application.Ai;

using BattleCard.Domain.Entities.Base;
using BattleCard.Application.Combat;
using BattleCard.Application.Actions;

public interface IAiStrategy
{
    ICombatAction ChooseAction(Enemy enemy, CombatContext context);
}