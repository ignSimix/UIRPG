# UIRPG Gustavs Janis Strujevics

# Mantošana (Inheritance)
	BBāzes klase - Character
		Mantojošās klases - Player.cs, Enemy.cs: BeserkerEnemy.cs un LightEnemy.cs manto no Enemy.

		Weapon.cs abstraktā klase

# Enkapsulācija (Encapsulation)
	Getter piemērs (Character.cs):
		public int CurrentHealth 
		{
   			get => currentHealth;
    			protected set => currentHealth = Mathf.Clamp(value, 0, maxHealth);
		}
	Setter piemērs (Player.cs):
		public string PlayerName 
		{
    			get => playerName;
    			set => playerName = string.IsNullOrEmpty(value) ? "Hero" : value;
		}
	Privāti lauki ar serializāciju:
		[SerializeField] private Weapon _activeWeapon;

# Polimorfisms (Polymorphism)
	Override piemērs (BeserkerEnemy.cs):
		public override int Attack() 
		{
    			aggressionLevel += AggressionGain;
    			return base.Attack();
		}

	Overload piemērs (Character.cs):
		
		public void TakeDamage(int damage)

		
		public void TakeDamage(Weapon weapon)

# Abstrakcija (Abstraction)
	Abstraktā klase (Weapon.cs):
		public abstract class Weapon : ScriptableObject
		{
   			 // Parastā metode
    			public virtual int GetDamage()
    			{
       				return Random.Range(minDamage, maxDamage + 1);
    			}
    
    			// Abstraktā metode
    			public abstract void ApplyEffect(Character target);
		}

	Implementējošās klases:
	Spear (Assets/Scripts/Weapons/Spear.cs):
	WoodenClub (Assets/Scripts/Weapons/WoodenClub.cs):

	public override void ApplyEffect(Character target)
	{
    		target.TakeDamage(armorPierce);
	}
--------------------------
	public override void ApplyEffect(Character target)
	{
    		if (Random.Range(0, 100) < stunChance)
        		target.ApplyStun(stunDuration);
	}
	