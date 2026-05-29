namespace BattleCard.Application.States;

using BattleCard.Application.Combat;
using BattleCard.Application.Events;

public class EnemyTurnState : ICombatState
{
    public void Enter(CombatContext context)
    {
        // Setup si besoin
    }

    public ICombatState Execute(CombatContext context)
    {
        // Chaque ennemi attaque
        foreach (var enemy in context.EnemiesAlive.ToList())
        {
            if (!enemy.IsAlive)
                continue;

            var damage = new Damage(enemy.BaseDamage.Value);
            context.Hero.TakeDamage(damage);

            // Publier l'événement dégâts
            context.Publisher.PublishDamageDealt(
                new DamageDealtEvent(enemy, context.Hero, damage.Value)
            );
        }

        // Vérifier si héros est mort
        if (!context.Hero.IsAlive)
        {
            context.Publisher.PublishCharacterDefeated(
                new CharacterDefeatedEvent(context.Hero)
            );
            return new DefeatState();
        }

        // Retour au tour du joueur
        return new PlayerTurnState();
    }
}