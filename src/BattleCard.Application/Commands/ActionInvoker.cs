namespace BattleCard.Application.Commands;

using BattleCard.Application.Combat;

public class ActionInvoker
{
    private readonly Dictionary<string, Func<ICommand>> _commandRegistry;

    public ActionInvoker()
    {
        _commandRegistry = new Dictionary<string, Func<ICommand>>
        {
            { "1", () => new AttackCommand() },
            { "2", () => new UseSkillCommand() },
            { "3", () => new HealCommand() },
            { "4", () => new ShowJournalCommand() }
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