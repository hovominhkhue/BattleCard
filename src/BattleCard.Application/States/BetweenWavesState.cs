namespace BattleCard.Application.States;

using BattleCard.Application.Combat;

public class BetweenWavesState : ICombatState
{
    private const double BetweenWaveHealPercent = 0.2;

    public void Enter(CombatContext context)
    {
        int healAmount = (int)System.Math.Ceiling(context.Hero.Health.Maximum * BetweenWaveHealPercent);
        context.Hero.Health.Heal(healAmount);

        context.NextWave();
    }

    public ICombatState Execute(CombatContext context)
    {
        return new PlayerTurnState();
    }
}