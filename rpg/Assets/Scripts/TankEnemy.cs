using UnityEngine;

public class TankEnemy : Enemy
{
    [SerializeField] private int defenseBoost = 10;
    [SerializeField] private float shieldRepairAmount = 20f;
    [SerializeField] private int tauntChance = 30; // Chance to taunt player

    public override int Attack()
    {
        // Tank attacks are slower but more consistent
        int baseDamage = Mathf.RoundToInt(activeWeapon.GetDamage() * 0.8f);
        return baseDamage;
    }

    public override void SpecialAbility()
    {
        // Tank's special ability: Fortify position
        ToggleShield(true);
        shieldDurability += shieldRepairAmount;
        CurrentHealth += defenseBoost;
        Debug.Log($"{name} fortifies their position! Health and shield increased.");
    }

    public override void TakeDamage(int damage)
    {
        // Chance to taunt the player when hit
        if (Random.Range(0, 100) < tauntChance)
        {
            Debug.Log($"{name} taunts you: \"Is that all you've got?\"");
        }

        // Tanks take reduced damage when shield is active
        if (shieldActive)
        {
            damage = Mathf.RoundToInt(damage * 0.7f);
        }

        base.TakeDamage(damage);
    }

    protected override void Start()
    {
        base.Start();
        // Tanks start with a shield
        ToggleShield(true);
        shieldDurability = 50f;
    }
}