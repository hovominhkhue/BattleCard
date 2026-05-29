namespace BattleCard.Domain.Entities.Base;

public abstract class Enemy : Character
{
    public object? AiStrategy { get; set; }

    protected Enemy(string name, int hp, int baseDmg, int armor = 0)
        : base(name, hp, baseDmg)
    {
        Armor = armor;
    }
}