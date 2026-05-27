namespace BattleCard.Domain.Entities.Heroes;

using BattleCard.Domain.Enums;
using BattleCard.Domain.Entities.Base;

public class Mage : Hero
{
    private const int MageMaxHealth = 80;
    private const int MageBaseDamage = 12;
    private const int MageCooldownTurns = 3;

    public Mage(string name)
        : base(name, HeroClass.Mage, MageMaxHealth, MageBaseDamage, MageCooldownTurns)
    {
    }
}