namespace BattleCard.Application.Events;

using BattleCard.Domain.Entities.Base;

public record CharacterDefeatedEvent(Character Character);