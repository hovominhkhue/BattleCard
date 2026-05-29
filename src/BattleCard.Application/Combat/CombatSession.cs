namespace BattleCard.Application.Combat;

using BattleCard.Application.Events;
using BattleCard.Application.States;
using BattleCard.Domain.Entities.Base;

public class CombatSession
{
    private readonly WaveManager _waveManager;
    private readonly CombatEventPublisher _eventPublisher;

    public CombatSession(WaveManager waveManager, CombatEventPublisher? eventPublisher = null)
    {
        _waveManager = waveManager;
        _eventPublisher = eventPublisher ?? new CombatEventPublisher();
    }

    public void Run(Hero hero)
    {
        var enemies = _waveManager.CreateWave(1);
        var context = new CombatContext(hero, 1, enemies, _eventPublisher);

        ICombatState currentState = new PlayerTurnState();

        while (currentState is not VictoryState && currentState is not DefeatState)
        {
            currentState.Enter(context);
            currentState = currentState.Execute(context);

            if (currentState is PlayerTurnState && context.EnemiesAlive.Count == 0)
            {
                if (context.CurrentWave < 3)
                {
                    var newEnemies = _waveManager.CreateWave(context.CurrentWave);
                    context.EnemiesAlive.Clear();
                    foreach (var enemy in newEnemies)
                        context.EnemiesAlive.Add(enemy);

                    _eventPublisher.PublishWaveEnded(new WaveEndedEvent(context.CurrentWave - 1));
                }
            }
        }
    }
}