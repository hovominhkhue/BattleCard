namespace BattleCard.Application.States;

using BattleCard.Application.Combat;
using BattleCard.Application.Events;
using BattleCard.Application.Ai;

public class EnemyTurnState : ICombatState
{
    public void Enter(CombatContext context) { }

    public ICombatState Execute(CombatContext context)
    {
        foreach (var enemy in context.EnemiesAlive)
        {
            if (enemy.AiStrategy is IAiStrategy ai)
            {
                var action = ai.ChooseAction(enemy, context);
                var result = action.Execute(enemy, context.Hero);

                context.Publisher.PublishDamageDealt(
                    new DamageDealtEvent(enemy, context.Hero, result.DamageDealt)
                );

                if (!context.Hero.IsAlive)
                {
                    context.Publisher.PublishCharacterDefeated(
                        new CharacterDefeatedEvent(context.Hero)
                    );
                    return new DefeatState();
                }
            }
        }

        return new PlayerTurnState();
    }
}