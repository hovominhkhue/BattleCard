namespace BattleCard.Domain.Entities.Enemies;

using BattleCard.Domain.Entities.Base;

public class Goblin : Enemy
{
    private const int GoblinMaxHealth = 40;
    private const int GoblinBaseDamage = 8;

    public Goblin()
        : base("Goblin", GoblinMaxHealth, GoblinBaseDamage)
    {
    }
}