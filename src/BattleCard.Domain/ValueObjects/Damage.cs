public class Damage
{
    public int Value { get; private set; }

    public Damage(int value)
    {
        Value = value;
    }

    public static implicit operator int(Damage damage) => damage.Value;
}