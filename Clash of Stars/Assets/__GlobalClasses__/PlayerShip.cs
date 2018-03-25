using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StarGallaxy 
{	
	[System.Serializable]
	public class PlayerShip : Starship
	{
		// <Summary>
		//  This class will heritate from parent all Starship stats
		//  so, we only will have in this class the current stats for each instance.
		// </Summary>

		[Header("Player Ship Configuration")]
		public GameObject engines;
		public GameObject thisObject;
		public string pilotName;

		public override void MoveTo (Vector3 target)
		{
			Vector3 curPos = thisObject.transform.position;
			if (curPos.Equals (target)) {
				// This means that the ship arrived to the target. Engines off
				engines.SetActive (false);
				isFlying = false;
			} 
			else 
			{
				isFlying = true;
				RotateTo (target);

				if (!engines.activeSelf)
					engines.SetActive (true);

				float step = movementSpeed / 20 * Time.deltaTime;
				thisObject.transform.position = Vector3.MoveTowards (curPos, target, step);
			}
		}

		public override void RotateTo (Vector3 target)
		{
			Vector3 targetDir = target - thisObject.transform.position;
			//Debug.Log (targetDir);

			float step = 2f * Time.deltaTime;
			Vector3 newDir = Vector3.RotateTowards(thisObject.transform.forward, targetDir, step, 0.0F);

			thisObject.transform.rotation = Quaternion.LookRotation(newDir);
		}
	}

}
