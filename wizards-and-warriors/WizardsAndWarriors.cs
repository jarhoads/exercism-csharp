using System;

abstract class Character
{
    public string CharacterType { get; set; }

    protected Character(string characterType) => CharacterType = characterType;

    public abstract int DamagePoints(Character target);

    public virtual bool Vulnerable() => false;

    public override string ToString() => $"Character is a {CharacterType}";
}

class Warrior : Character
{
    private const int VulnerableDamage = 10;
    private const int Damage = 6;
    
    public Warrior() : base("Warrior")
    { }

    public override int DamagePoints(Character target) => target.Vulnerable() ? VulnerableDamage : Damage;

}

class Wizard : Character
{
    private bool _preparedSpell;
    private const int PreparedDamage = 12;
    private const int Damage = 3;

    public Wizard() : base("Wizard") =>  _preparedSpell = false;

    public override bool Vulnerable() => !_preparedSpell;
    public override int DamagePoints(Character target) => (_preparedSpell) ? PreparedDamage : Damage;
    public void PrepareSpell() => _preparedSpell = true;
}
