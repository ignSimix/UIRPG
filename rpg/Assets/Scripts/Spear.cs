using UnityEngine;

[CreateAssetMenu(fileName = "New Spear", menuName = "Weapons/Spear")]
public class Spear : Weapon
{
    [SerializeField] private int armorPierce = 8;

    public override int GetDamage()
    {
        return base.GetDamage() + 2;
    }

    public override void ApplyEffect(Character target)
    {
        target.TakeDamage(armorPierce);
        Debug.Log($"Spear pierces armor for {armorPierce} bonus damage!");
    }
}