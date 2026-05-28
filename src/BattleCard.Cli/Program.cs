using BattleCard.Domain.Entities.Heroes;
using BattleCard.Application.Combat;

var hero = new Warrior("Aragorn");
var session = new CombatSession();

Console.WriteLine($"Starting combat with {hero.Name} ({hero.Class})");
Console.WriteLine($"Hero Health: {hero.Health.Current}/{hero.Health.Maximum}\n");

session.Run(hero);

Console.WriteLine("\n--- Combat End ---");
Console.WriteLine($"Hero Health: {hero.Health.Current}/{hero.Health.Maximum}");
if (hero.IsAlive)
    Console.WriteLine("Victory!");
else
    Console.WriteLine("Defeat!");