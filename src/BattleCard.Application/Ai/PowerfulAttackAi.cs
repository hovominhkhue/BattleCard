namespace BattleCard.Application.Ai;

using BattleCard.Domain.Entities.Base;
using BattleCard.Application.Combat;
using BattleCard.Application.Actions;

public class PowerfulAttackAi : IAiStrategy
{
    public ICombatAction ChooseAction(Enemy enemy, CombatContext context)
    {
        return new BasicAttackAction();
    }
}