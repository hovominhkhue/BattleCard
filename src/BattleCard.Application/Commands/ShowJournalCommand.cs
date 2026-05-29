namespace BattleCard.Application.Commands;

using BattleCard.Application.Combat;
using BattleCard.Application.Events;

public class ShowJournalCommand : ICommand
{
    private readonly JournalObserver _journalObserver;

    public ShowJournalCommand(JournalObserver journalObserver)
    {
        _journalObserver = journalObserver;
    }

    public CombatResult Execute(CombatContext context)
    {
        string journalContent = _journalObserver.GetJournal();
        
        if (string.IsNullOrEmpty(journalContent))
            journalContent = "Journal is empty";

        return new CombatResult(
            context.Hero,
            context.Hero,
            0,
            false,
            $"Journal:\n{journalContent}"
        );
    }
}