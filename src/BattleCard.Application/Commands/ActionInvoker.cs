namespace BattleCard.Application.Commands;

using BattleCard.Application.Combat;
using BattleCard.Application.Events;

public class ActionInvoker
{
    private readonly Dictionary<string, Func<ICommand>> _commandRegistry;
    private readonly JournalObserver _journalObserver;

    public ActionInvoker(JournalObserver? journalObserver = null)
    {
        _journalObserver = journalObserver ?? new JournalObserver();
        
        _commandRegistry = new Dictionary<string, Func<ICommand>>
        {
            { "1", () => new AttackCommand() },
            { "2", () => new UseSkillCommand() },
            { "3", () => new HealCommand() },
            { "4", () => new ShowJournalCommand(_journalObserver) }
        };
    }

    public CombatResult InvokeCommand(string choice, CombatContext context)
    {
        if (!_commandRegistry.TryGetValue(choice, out var commandFactory))
            return new CombatResult(context.Hero, context.Hero, 0, false, $"Invalid choice: {choice}");

        var command = commandFactory();
        return command.Execute(context);
    }
}