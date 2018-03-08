using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player : NetworkBehaviour {

	public GameObject myCamera;

	void Start () 
	{
		myCamera.SetActive (isLocalPlayer);

	}
	
	void Update () 
	{
		
	}
}
