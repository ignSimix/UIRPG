using UnityEngine;

public class LightEnemy : Enemy
{
    [Header("Light Enemy Properties")]
    [SerializeField] private float dodgeChance = 0.3f; 
    [SerializeField] private int maxConsecutiveAttacks = 3;
    [SerializeField] private float attackSpeedMultiplier = 1.5f;

    private int attacksPerformed = 0;

    public override int Attack()
    {
        attacksPerformed++;
        int baseDamage = Mathf.RoundToInt(base.Attack() * 0.7f);

        // Every third attack is faster but weaker
        if (attacksPerformed % maxConsecutiveAttacks == 0)
        {
            float rapidDamage = baseDamage * 0.5f;
            Debug.Log($"{name} uses rapid strike!");
            return Mathf.RoundToInt(rapidDamage);
        }

        return baseDamage;
    }

    public override void TakeDamage(int damage)
    {
 
        if (Random.value < dodgeChance)
        {
            Debug.Log($"{name} dodged the attack!");
            return;
        }

        base.TakeDamage(damage);
    }

    public override void SpecialAbility()
    {
        Debug.Log($"{name} backflips to safety!");
        ToggleShield(true);
        shieldDurability = 15f;

        // Small health regen
        CurrentHealth = Mathf.Min(CurrentHealth + 5, maxHealth);
    }

    protected override void Start()
    {
        base.Start();
        maxHealth = Mathf.RoundToInt(maxHealth * 0.6f);
        CurrentHealth = maxHealth;
    }
}