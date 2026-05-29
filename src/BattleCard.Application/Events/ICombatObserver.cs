namespace BattleCard.Application.Events;

public interface ICombatObserver
{
    void OnDamageDealt(DamageDealtEvent @event);
    
    void OnCharacterHealed(CharacterHealedEvent @event);
    
    void OnCharacterDefeated(CharacterDefeatedEvent @event);
    
    void OnWaveEnded(WaveEndedEvent @event);
}