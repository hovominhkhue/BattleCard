namespace BattleCard.Application.Commands;

using BattleCard.Application.Actions;
using BattleCard.Application.Combat;
using BattleCard.Domain.Entities.Base;
using BattleCard.Domain.Enums;

public class UseSkillCommand : ICommand
{
    public CombatResult Execute(CombatContext context)
    {
        var hero = (Hero)context.Hero;
        var target = context.EnemiesAlive.FirstOrDefault();

        if (target == null)
            return new CombatResult(hero, hero, 0, false, "No enemies to target");

        // Sélectionner l'action selon la classe du héros
        ICombatAction skillAction = hero.Class switch
        {
            HeroClass.Warrior => new WarriorSkillAction(),
            HeroClass.Mage => new MageSkillAction(),
            HeroClass.Thief => new ThiefSkillAction(new Random()),
            _ => throw new InvalidOperationException($"Unknown hero class: {hero.Class}")
        };

        // Vérifier si la compétence peut être utilisée
        if (!skillAction.CanExecute(hero))
            return new CombatResult(hero, hero, 0, false, "Skill not ready or unavailable");

        var result = skillAction.Execute(hero, target);

        if (!target.IsAlive)
            context.RemoveDefeatedEnemy(target);

        return result;
    }
}