using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarGallaxy;
using UnityEngine.AI;

public class MinionBehaviour : MonoBehaviour {

	public MinionShip minion;
	public float lookSphereCastRadius = 1f;
	public float lookRange = 40f;

	public Transform goal;

	public bool WantToMove (Vector3 waypoint)
	{
		NavMeshAgent agent = GetComponent <NavMeshAgent> ();
		agent.destination = waypoint;

		return true;
	}

	void Start ()
	{
//		WantToMove (goal.position);
	}
}
