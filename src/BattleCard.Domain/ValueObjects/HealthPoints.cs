namespace BattleCard.Domain.ValueObjects;

public class HealthPoints
{
    public int Current { get; private set; }
    public int Maximum { get; private set; }

    public bool IsAlive => Current > 0;
    public bool IsFull => Current == Maximum;

    public HealthPoints(int current, int maximum)
    {
        Current = current;
        Maximum = maximum;
    }

    public void TakeDamage(Damage damage)
    {
        Current = Current - damage.Value;
    }

    public void Heal(int amount)
    {
        Current = Math.Min(Maximum, Current + amount);
    }
}