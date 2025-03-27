using UnityEngine;

public class BeserkerEnemy : Enemy
{
    [SerializeField] private int AggressionGain = 5;

    public override int Attack()
    {
        aggressionLevel += AggressionGain;
        return base.Attack();
    }

    public override void SpecialAbility()
    {
        aggressionLevel += 2;
        shieldActive = false;
        Debug.Log($"{name} enters a berserker rage! Damage increased but defense lowered.");
    }

    public override void TakeDamage(int damage)
    {
        if (CurrentHealth < maxHealth / 2)
        {
            damage = Mathf.RoundToInt(damage * 1.5f);
            Debug.Log($"{name} is in a frenzy and takes more damage!");
        }
        base.TakeDamage(damage);
    }
}