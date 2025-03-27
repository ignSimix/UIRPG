using UnityEngine;

public class Player : Character
{
    [SerializeField] private string playerName = "Hero";
    [SerializeField] private int specialAttackCost = 30;
    [SerializeField] private int specialAttackMultiplier = 2;

    public string PlayerName
    {
        get => playerName;
        set => playerName = string.IsNullOrEmpty(value) ? "Hero" : value;
    }

    public override int Attack()
    {
        return activeWeapon.GetDamage();
    }

    public int SpecialAttack()
    {
        if (CurrentHealth > specialAttackCost)
        {
            CurrentHealth -= specialAttackCost;
            int baseDamage = activeWeapon.GetDamage();
            return baseDamage * specialAttackMultiplier;
        }
        return 0;
    }

    public void Heal(int amount)
    {
        CurrentHealth += amount;
        Debug.Log($"{PlayerName} healed for {amount}. Current health: {CurrentHealth}");
    }
}