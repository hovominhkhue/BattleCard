namespace BattleCard.Application.Factories;

using BattleCard.Domain.Entities.Base;

public interface IEnemyFactory
{
    Enemy Create(string enemyType);
}