namespace BattleCard.Application.Events;

public class JournalObserver : ICombatObserver
{
    private readonly List<string> _entries = new();

    public void OnDamageDealt(DamageDealtEvent @event)
    {
        string entry = $"{@event.Attacker.Name} deals {@event.DamageAmount} damage to {@event.Defender.Name}";
        _entries.Add(entry);
    }

    public void OnCharacterHealed(CharacterHealedEvent @event)
    {
        string entry = $"{@event.Character.Name} heals for {@event.HealAmount} HP";
        _entries.Add(entry);
    }

    public void OnCharacterDefeated(CharacterDefeatedEvent @event)
    {
        string entry = $"{@event.Character.Name} is defeated!";
        _entries.Add(entry);
    }

    public void OnWaveEnded(WaveEndedEvent @event)
    {
        string entry = $"--- Wave {@event.WaveNumber} ended ---";
        _entries.Add(entry);
    }

    public string GetJournal()
    {
        return string.Join("\n", _entries);
    }

    public List<string> GetEntries()
    {
        return new List<string>(_entries);
    }
}