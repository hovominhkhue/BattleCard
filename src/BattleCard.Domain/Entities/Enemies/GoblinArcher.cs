namespace BattleCard.Domain.Entities.Enemies;

using BattleCard.Domain.Entities.Base;

public class GoblinArcher : Enemy
{
    private const int GoblinArcherMaxHealth = 35;
    private const int GoblinArcherBaseDamage = 12;

    public GoblinArcher()
        : base("Goblin Archer", GoblinArcherMaxHealth, GoblinArcherBaseDamage)
    {
    }
}