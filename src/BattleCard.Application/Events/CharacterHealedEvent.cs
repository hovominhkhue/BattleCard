namespace BattleCard.Application.Events;

using BattleCard.Domain.Entities.Base;

public record CharacterHealedEvent(Character Character, int HealAmount);