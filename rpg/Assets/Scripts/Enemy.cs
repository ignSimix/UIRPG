using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    [Header("Enemy Rewards")]
    [SerializeField] protected int expReward = 30;
    [SerializeField] protected int goldReward = 15;
    public int ExpReward => expReward;
    public int GoldReward => goldReward;

    protected override void Start()
    {
        base.Start();
        nameText.text = CharacterName;
    }

    public override void SpecialAbility()
    {
        // Enemy-specific special ability
        Debug.Log($"{CharacterName} uses special ability!");
    }
    public class Goblin : Enemy
    {
        private void Awake()
        {
            CharacterName = "Goblin";
            maxHealth = 60;
        }

        public override int Attack()
        {
            int damage = base.Attack();

            // 30% chance to attack twice
            if (Random.value < 0.3f)
            {
                damage += base.Attack();
                Debug.Log("Goblin attacks again!");
            }

            return damage;
        }
    }

    public class Orc : Enemy
    {
        private void Awake()
        {
            CharacterName = "Orc";
            maxHealth = 120;
        }

        public override int Attack()
        {
            return Mathf.RoundToInt(base.Attack() * 1.5f); // Orcs sit stiprak bet lenak
        }
    }

    public class Troll : Enemy
    {
        private const float healChance = 0.2f;
        private const float healAmount = 0.3f;

        private void Awake()
        {
            CharacterName = "Troll";
            maxHealth = 150;
        }

        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);

            // Chance to heal when hit
            if (Random.value < healChance && currentHealth > 0)
            {
                int heal = Mathf.RoundToInt(maxHealth * healAmount);
                currentHealth = Mathf.Min(maxHealth, currentHealth + heal);
                Debug.Log($"Troll regenerates {heal} health!");
                UpdateHealthUI();
            }
        }
    }
}
