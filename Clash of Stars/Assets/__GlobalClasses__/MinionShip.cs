using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StarGallaxy
{
	[System.Serializable]
	public class MinionShip : Starship 
	{
		[Header("Faction")]
		public string colorFactionTag;
		public LaneName currentLane;
		// TODO: We must create a class to store all waypoints in the Lanes, and manage them on each minion.

	}
}