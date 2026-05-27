namespace BattleCard.Domain.Entities.Base;

using BattleCard.Domain.Enums;
using BattleCard.Domain.ValueObjects;

public class Hero : Character
{
    public HeroClass Class { get; private set; }
    public Cooldown SkillCooldown { get; private set; }
    public int HealingPotionsLeft { get; private set; }

    private const int MaxHealingPotions = 2;
    private const int HealAmount = 25;

    protected Hero(string name, HeroClass heroClass, int maxHealth, int baseDamage, int cooldownTurns)
        : base(name, maxHealth, baseDamage)
    {
        Class = heroClass;
        SkillCooldown = new Cooldown(cooldownTurns);
        HealingPotionsLeft = MaxHealingPotions;
    }

    public void UseHealingPotion()
    {
        if (HealingPotionsLeft <= 0)
            throw new Exception("No healing potions left");

        Health.Heal(HealAmount);
        HealingPotionsLeft--;
    }

    public void DecrementSkillCooldown()
    {
        SkillCooldown.Decrement();
    }
}