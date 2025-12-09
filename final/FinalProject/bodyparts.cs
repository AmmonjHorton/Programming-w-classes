using System;
public abstract class BodyPart
{
    private string _name;
    private int _healthStat;
    private int _attackStat;
    private string _specialAbility;

    public BodyPart(string name, int healthStat, int attackStat, string specialAbility)
    {
        _name = name;
        _healthStat = healthStat;
        _attackStat = attackStat;
        _specialAbility = specialAbility;
    }
    public string GetName()
    {
        return _name;
    }
    public int GetHealthStat()
    {
        return _healthStat;
    }
    public int GetAttackStat()
    {
        return _attackStat;
    }
    public string GetSpecialAbility()
    {
        return _specialAbility;
    }
    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Body Part: {GetName()}");
        Console.WriteLine($"Health Stat: {GetHealthStat()}");
        Console.WriteLine($"Attack Stat: {GetAttackStat()}");
    }
    public abstract void Action();
}