namespace BattleCard.Application.Events;

public class CombatEventPublisher
{
    private readonly List<ICombatObserver> _observers = new();

    public void Subscribe(ICombatObserver observer)
    {
        if (!_observers.Contains(observer))
            _observers.Add(observer);
    }

    public void Unsubscribe(ICombatObserver observer)
    {
        _observers.Remove(observer);
    }

    public void PublishDamageDealt(DamageDealtEvent @event)
    {
        foreach (var observer in _observers)
            observer.OnDamageDealt(@event);
    }

    public void PublishCharacterHealed(CharacterHealedEvent @event)
    {
        foreach (var observer in _observers)
            observer.OnCharacterHealed(@event);
    }

    public void PublishCharacterDefeated(CharacterDefeatedEvent @event)
    {
        foreach (var observer in _observers)
            observer.OnCharacterDefeated(@event);
    }

    public void PublishWaveEnded(WaveEndedEvent @event)
    {
        foreach (var observer in _observers)
            observer.OnWaveEnded(@event);
    }
}