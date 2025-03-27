using UnityEngine;

public abstract class Weapon : ScriptableObject
{
    [SerializeField] protected string weaponName = "New Weapon";
    [SerializeField] protected int minDamage = 1;
    [SerializeField] protected int maxDamage = 3;

    public string WeaponName => weaponName;

    public virtual int GetDamage()
    {
        return Random.Range(minDamage, maxDamage + 1);
    }

    public abstract void ApplyEffect(Character target);
}