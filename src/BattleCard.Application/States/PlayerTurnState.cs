namespace BattleCard.Application.States;

using BattleCard.Application.Commands;
using BattleCard.Application.Combat;

public class PlayerTurnState : ICombatState
{
    private readonly IPlayerInput _playerInput;
    private readonly ActionInvoker _actionInvoker;

    public PlayerTurnState(IPlayerInput? playerInput = null)
    {
        _playerInput = playerInput ?? new StubPlayerInput();
        _actionInvoker = new ActionInvoker();
    }

    public void Enter(CombatContext context)
    {
    }

    public ICombatState Execute(CombatContext context)
    {
        if (context.EnemiesAlive.Count == 0)
        {
            if (context.CurrentWave == 3)
                return new VictoryState();
            return new BetweenWavesState();
        }

        string choice = _playerInput.GetPlayerChoice(context);

        var result = _actionInvoker.InvokeCommand(choice, context);

        context.Hero.DecrementSkillCooldown();

        if (!context.Hero.IsAlive)
            return new DefeatState();

        if (context.IsWaveCleared)
        {
            if (context.CurrentWave == 3)
                return new VictoryState();
            return new BetweenWavesState();
        }

        return new EnemyTurnState();
    }
}