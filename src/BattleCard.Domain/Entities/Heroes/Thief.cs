namespace BattleCard.Domain.Entities.Heroes;

using BattleCard.Domain.Enums;
using BattleCard.Domain.Entities.Base;

public class Thief : Hero
{
    private const int ThiefMaxHealth = 90;
    private const int ThiefBaseDamage = 14;
    private const int ThiefCooldownTurns = 2;

    public Thief(string name)
        : base(name, HeroClass.Thief, ThiefMaxHealth, ThiefBaseDamage, ThiefCooldownTurns)
    {
    }
}