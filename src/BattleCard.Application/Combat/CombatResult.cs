namespace BattleCard.Application.Combat;

using BattleCard.Domain.Entities.Base;

public record CombatResult(
    Character Attacker,
    Character Defender,
    int DamageDealt,
    bool DefenderDefeated,
    string Message
);