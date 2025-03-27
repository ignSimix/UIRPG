using UnityEngine;

[CreateAssetMenu(fileName = "New Wooden Club", menuName = "Weapons/Wooden Club")]
public class WoodenClub : Weapon
{
    [SerializeField] private int armorPierce = 1;

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