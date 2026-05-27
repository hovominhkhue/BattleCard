# BattleCard

A turn-based combat CLI game in C#.

## How to run

```bash
dotnet run --project src/BattleCard.Cli
```

## Project Structure
```
BattleCard/
│
└── src/
├── BattleCard.Domain/
│   ├── Entities/                    # The main business objects
│   ├── ValueObjects/                # Immutable simple objects
│   ├── Enums/                       # Enumeration types for fixed lists
│   ├── Exceptions/                  # Business domain exceptions
│   └── Services/                    # Pure business logic (no I/O)
│
├── BattleCard.Application/
│   ├── Combat/                      # Core combat orchestration
│   ├── Actions/                     # Strategy: ICombatAction + impl.
│   ├── Commands/                    # Command pattern
│   ├── States/                      # State pattern
│   ├── Factories/                   # Factory pattern
│   ├── Ai/                          # Enemy AI strategies
│   └── Events/                      # Observer: subject + events
│
├── BattleCard.Infrastructure/
│   ├── Console/                     # Menus, input, rendering
│   ├── Input/                       # User input handling
│   └── Persistence/                 # (bonus) Repository JSON
│
└── BattleCard.Cli/
└── Program.cs                       # Composition root (wiring)
└── tests/
└── BattleCard.Tests/                # Unit and integration tests
```

## Domain Implementation

**Value Objects:**
- `HealthPoints` : Current and maximum health
- `Damage` : Damage value
- `Cooldown` : Skill cooldown tracking

**Enums:**
- `HeroClass` : Warrior, Mage, Thief

**Entities:**
- **Base:** `Character`, `Hero`, `Enemy`
- **Heroes:** Warrior, Mage, Thief
- **Enemies:** Goblin, GoblinArcher, OrcBoss