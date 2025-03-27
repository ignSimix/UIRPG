using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] protected int maxHealth = 100;
    [SerializeField] protected int currentHealth;
    [SerializeField] protected Weapon activeWeapon;
    [SerializeField] protected bool shieldActive = false;
    [SerializeField] protected float shieldDurability = 100f;

    public int CurrentHealth
    {
        get { return currentHealth; }
        protected set { currentHealth = Mathf.Clamp(value, 0, maxHealth); }
    }

    public bool IsShieldActive => shieldActive;
    public float ShieldDurability => shieldDurability;

    protected virtual void Start()
    {
        CurrentHealth = maxHealth;
    }

    public virtual int Attack()
    {
        Debug.Log($"{name} attacks with {activeWeapon.WeaponName}!");
        return activeWeapon.GetDamage();
    }

    public virtual void TakeDamage(int damage)
    {
        if (shieldActive)
        {
            float reducedDamage = damage * 0.5f;
            CurrentHealth -= Mathf.RoundToInt(reducedDamage);
            shieldDurability -= damage;

            if (shieldDurability <= 0)
            {
                shieldActive = false;
                Debug.Log($"{name}'s shield broke!");
            }
        }
        else
        {
            CurrentHealth -= damage;
        }

        Debug.Log($"{name} took {damage} damage. Health: {CurrentHealth}");
    }

    public void ToggleShield(bool activate)
    {
        shieldActive = activate;
        Debug.Log($"{name} shield: {(activate ? "activated" : "deactivated")}");
    }

    public bool IsDead => CurrentHealth <= 0;
}