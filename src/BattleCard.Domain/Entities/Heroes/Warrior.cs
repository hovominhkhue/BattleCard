namespace BattleCard.Domain.Entities.Heroes;

using BattleCard.Domain.Enums;
using BattleCard.Domain.Entities.Base;

public class Warrior : Hero
{
    private const int WarriorMaxHealth = 120;
    private const int WarriorBaseDamage = 18;
    private const int WarriorCooldownTurns = 2;

    public Warrior(string name)
        : base(name, HeroClass.Warrior, WarriorMaxHealth, WarriorBaseDamage, WarriorCooldownTurns)
    {
    }
}