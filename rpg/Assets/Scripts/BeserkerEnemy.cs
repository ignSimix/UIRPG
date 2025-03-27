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
        // Berserker's special ability: Enter a rage that increases damage but lowers defense
        aggressionLevel += 2;
        shieldActive = false; // Berserkers can't use shields when raging
        Debug.Log($"{name} enters a berserker rage! Damage increased but defense lowered.");
    }

    public override void TakeDamage(int damage)
    {
        // Berserkers take more damage when their health is low but deal more damage
        if (CurrentHealth < maxHealth / 2)
        {
            damage = Mathf.RoundToInt(damage * 1.5f);
            Debug.Log($"{name} is in a frenzy and takes more damage!");
        }
        base.TakeDamage(damage);
    }
}