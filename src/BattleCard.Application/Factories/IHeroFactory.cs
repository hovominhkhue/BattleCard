namespace BattleCard.Application.Factories;

using BattleCard.Domain.Entities.Base;
using BattleCard.Domain.Enums;

public interface IHeroFactory
{
    Hero Create(HeroClass heroClass, string name);
}