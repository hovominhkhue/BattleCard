using BattleCard.Application.Combat;
using BattleCard.Application.Factories;
using BattleCard.Domain.Enums;

// Créer les factories
var heroFactory = new HeroFactory();
var enemyFactory = new EnemyFactory();

// Créer le héros via la factory
var hero = heroFactory.Create(HeroClass.Warrior, "Aragorn");

// Créer la session avec le WaveManager injecté
var waveManager = new WaveManager(enemyFactory);
var session = new CombatSession(waveManager);

Console.WriteLine($"Starting combat with {hero.Name} ({hero.Class})");
Console.WriteLine($"Hero Health: {hero.Health.Current}/{hero.Health.Maximum}\n");

session.Run(hero);

Console.WriteLine("\n--- Combat End ---");
Console.WriteLine($"Hero Health: {hero.Health.Current}/{hero.Health.Maximum}");
if (hero.IsAlive)
    Console.WriteLine("Victory!");
else
    Console.WriteLine("Defeat!");