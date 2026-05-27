namespace BattleCard.Domain.Entities.Base;

public class Enemy : Character
{
    protected Enemy(string name, int maxHealth, int baseDamage)
        : base(name, maxHealth, baseDamage)
    {
    }
}