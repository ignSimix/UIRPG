using UnityEngine;

public abstract class Enemy : Character
{
    [SerializeField] protected int aggressionLevel = 1;

    public override int Attack()
    {
        int baseDamage = activeWeapon.GetDamage();
        return baseDamage * aggressionLevel;
    }

    public abstract void SpecialAbility();
}

public class BerserkerEnemy : Enemy
{
    [SerializeField] private int rageThreshold = 50;

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);

        if (CurrentHealth < rageThreshold && aggressionLevel == 1)
        {
            aggressionLevel = 2;
            Debug.Log($"{name} enters rage mode!");
        }
    }

    public override void SpecialAbility()
    {
        CurrentHealth += 5;
        Debug.Log($"{name} heals from bloodlust!");
    }
}

public class MageEnemy : Enemy
{
    [SerializeField] private int spellPower = 15;

    public override int Attack()
    {
        if (Random.value > 0.5f)
        {
            Debug.Log($"{name} casts a spell!");
            return spellPower + Random.Range(1, 10);
        }
        return base.Attack();
    }

    public override void SpecialAbility()
    {
        ToggleShield(true);
        shieldDurability = 30f;
        Debug.Log($"{name} summons a magical barrier!");
    }
}