namespace BattleCard.Domain.Entities.Base;

using BattleCard.Domain.ValueObjects;

public abstract class Character
{
    public string Name { get; private set; }
    public HealthPoints Health { get; private set; }
    public Damage BaseDamage { get; private set; }

    public bool IsAlive => Health.IsAlive;

    protected Character(string name, int maxHealth, int baseDamage)
    {
        Name = name;
        Health = new HealthPoints(maxHealth, maxHealth);
        BaseDamage = new Damage(baseDamage);
    }

    public void TakeDamage(Damage damage)
    {
        Health.TakeDamage(damage);
    }
}