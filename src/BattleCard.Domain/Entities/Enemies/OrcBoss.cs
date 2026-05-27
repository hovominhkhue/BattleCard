namespace BattleCard.Domain.Entities.Enemies;

using BattleCard.Domain.Entities.Base;

public class OrcBoss : Enemy
{
    private const int OrcBossMaxHealth = 150;
    private const int OrcBossBaseDamage = 25;

    public OrcBoss()
        : base("Orc Boss", OrcBossMaxHealth, OrcBossBaseDamage)
    {
    }
}