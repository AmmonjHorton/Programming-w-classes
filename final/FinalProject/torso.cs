using System;

public class Torso : BodyPart
{
    private string _healAmount;
    public Torso(int healthStat, int attackStat, string specialAbility, string name, string healAmount)
        : base(name, healthStat, attackStat, specialAbility)
    {
        _healAmount = healAmount;
    }
    public override void Action()
    {
        Console.WriteLine($"Your amalgam uses its {GetName()} to heal for {_healAmount} using {GetSpecialAbility()}!");
    }
}
