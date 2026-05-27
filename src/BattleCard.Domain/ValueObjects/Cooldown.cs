namespace BattleCard.Domain.ValueObjects;

public class Cooldown
{
    public int RemainingTurns { get; private set; }
    public bool IsReady => RemainingTurns == 0;

    public Cooldown(int turns)
    {
        RemainingTurns = turns;
    }

    public void Decrement()
    {
        if (RemainingTurns > 0)
            RemainingTurns--;
    }
}