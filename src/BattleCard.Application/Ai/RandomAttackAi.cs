namespace BattleCard.Application.Ai;

using BattleCard.Domain.Entities.Base;
using BattleCard.Application.Combat;
using BattleCard.Application.Actions;

public class RandomAttackAi : IAiStrategy
{
    public ICombatAction ChooseAction(Enemy enemy, CombatContext context)
    {
        return new BasicAttackAction();
    }
}