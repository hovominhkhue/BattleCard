namespace BattleCard.Application.Commands;

using BattleCard.Application.Combat;

public class ShowJournalCommand : ICommand
{
    public CombatResult Execute(CombatContext context)
    {
        return new CombatResult(context.Hero, context.Hero, 0, false, "Journal: Not implemented yet");
    }
}