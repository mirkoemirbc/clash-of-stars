using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarGallaxy;

public class MatchBehaviour : MonoBehaviour 
{
	public float waitColdDown = 2.5f;
	public GameObject[] listPlayers; 

	private IEnumerator timerCoroutine;

	public delegate void PlayerShipCreatedDelegate (PlayerShip ship, GameObject shipGO);
	public event PlayerShipCreatedDelegate OnPlayerShipCreated;

	void Start () 
	{
		if (listPlayers.Length == 0) 
		{
			SpawnPlayers ();
		}

		// Start the Match and ALL the stuff
		StartTheMatch ();

		// Start Coroutine for GivingExperience
		timerCoroutine = ExperienceOverTime (waitColdDown);
		StartCoroutine (timerCoroutine);
	}

	void StartTheMatch ()
	{
		// This function should start the match. It is where the magic occurs.
		return;	
	}

	public void SpawnPlayers ()
	{
		// This function should spawn all players into the map, according to their faction

		// Search for all Players
		listPlayers = GameObject.FindGameObjectsWithTag ("Player");
	}

	private IEnumerator ExperienceOverTime (float coldDown)
	{
		while (true) 
		{
			int vExp = Random.Range (20, 40);
			yield return new WaitForSeconds (coldDown);
			for (int i = 0; i < listPlayers.Length; i++) 
			{
				listPlayers [i].GetComponent<ShipBehaviour> ().ship.AddExperience (vExp);
			}
		}
	}
}
