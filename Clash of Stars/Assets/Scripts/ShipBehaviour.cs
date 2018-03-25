using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarGallaxy;

public class ShipBehaviour : MonoBehaviour 
{

	public PlayerShip ship;

	private Vector3 clickTerrain;
	private bool isMoving;

	void Start ()
	{
		isMoving = false;
		clickTerrain = this.transform.position;
		ship.AddExperience (1);
	}

	void Update ()
	{
//		if (Input.GetMouseButton (0))
//		{
//			RaycastHit hit;
//
//			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//
//			if (Physics.Raycast (ray, out hit, 100.0f)) 
//			{
//				clickTerrain = ray.GetPoint (hit.distance);
//			}
//			isMoving = true;
//		}
//
//		if (transform.position.Equals (clickTerrain)) 
//		{
//			isMoving = false;
//		}
	}

	void FixedUpdate ()
	{
		ship.MoveTo (clickTerrain);
	}
}
