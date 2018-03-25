using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StarGallaxy 
{	
	// <Summary>
	// Following custom structures to have in account in Starships declaration
	// </Summary>
	public enum VesselType 
	{
		FLYING,
		LAND,
		FLYING_LAND,
		LAND_FLYING,
		UNDEFINED
	};

	public enum WeaponType
	{
		KINETIC,
		ENERGY,
		MIXED
	};

	public enum LaneName
	{
		TOP,
		MIDDLE,
		BOTTOM
	};

	[System.Serializable]
	public class Starship 
	{
		// Name and ID
		[Header ("Name and ID")]
		public string codeName;

		public int maximumLevel;
		public int currentLevel;
		public int currentExperience;

		// Life and Energy
		[Header ("Life and Energy")]
		public int maximumHitPoints;
		public int currentHitPoints;
		public int hitPointsPerLevel;

		public int maximumInnerEnergy;
		public int currentInnerEnergy;
		public int innerEnergyPerLevel;

		// Defences
		[Header ("Defences")]
		public float hullResist;
		public float hullResistPerLevel;

		public float energyResist;
		public float energyResistPerLevel;

		// Weapons and Damage
		[Header ("Weapons and Damage")]
		public WeaponType mainWeaponType;
		public float attackSpeed;
		public float attackDamage;
		public float attackDamagePerLevel;
		public float attackRange;

		public float criticalChance;

		// Movement
		[Header ("Movement")]
		public VesselType type;
		public float movementSpeed;
		public float tilt;

		// Protected declarations
		protected bool isFlying;

		void HealingHitPoints (int value)
		{
			int cValue = currentHitPoints + value;
			Mathf.Clamp (cValue, 0, maximumHitPoints);
		}

		public void AddExperience (int value)
		{
			// If it is a level 1
			if (currentLevel == 0) 
			{
				// Raise the Max HP and add same amount to current HP
				maximumHitPoints += (hitPointsPerLevel * 2);
				currentHitPoints = maximumHitPoints;

				// Raise the Max IE and add same amount to current IE
				maximumInnerEnergy += (innerEnergyPerLevel * 2);
				currentInnerEnergy = maximumInnerEnergy;

				currentLevel = 1;
			}

			if (currentLevel == maximumLevel)
				currentExperience = maximumLevel * 1000;
			else 
			{
				currentExperience += value;
				if (currentExperience >= (currentLevel + 1) * 1000 && currentLevel < maximumLevel) {
					LevelUp ();
				}
			}
		}

		public void LevelUp ()
		{
			if (currentLevel < maximumLevel)
			{
				// Raise the Max HP and add same amount to current HP
				maximumHitPoints += hitPointsPerLevel;
				currentHitPoints += hitPointsPerLevel;

				// Raise the Max IE and add same amount to current IE
				maximumInnerEnergy += innerEnergyPerLevel;
				currentInnerEnergy += innerEnergyPerLevel;

				// Raise Defences
				hullResist += hullResistPerLevel;
				energyResist += energyResistPerLevel;

				// Raise Attack
				attackDamage += attackDamagePerLevel;

				// Raise level
				currentLevel++;
				currentExperience = 0;
			}
		}

		public virtual void MoveTo (Vector3 target)
		{
			return;
		}

		public virtual void RotateTo (Vector3 target)
		{
			return;
		}

	}
}
