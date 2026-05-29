namespace BattleCard.Application.Events;

using BattleCard.Domain.Entities.Base;

public record DamageDealtEvent(Character Attacker, Character Defender, int DamageAmount);