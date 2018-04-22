using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player : NetworkBehaviour 
{

	public GameObject myCamera;
	private Cinemachine.CinemachineVirtualCamera myVirtualCamera;

	void Awake () 
	{
		// First things first: We'll find the camera or use any camera already set.
		// This only happens when the Player is LocalPlayer
		if (isLocalPlayer == true)
		{
			if (myCamera == null)
			{
				myCamera = FindObjectOfType<Camera> ().transform.gameObject;
			}
			myCamera.SetActive (true);
		}
	}

	void Start ()
	{
		// Setting up some VirtualCamera only when Player is LocalPlayer
		if (isLocalPlayer == true) 
		{
			myVirtualCamera = GameObject.FindObjectOfType<Cinemachine.CinemachineVirtualCamera> ();
			if (DebugBehaviour.debuggingStatus == DebugTarget.CAMERA || DebugBehaviour.debuggingStatus == DebugTarget.ALL)
				Debug.Log (myVirtualCamera);

			myVirtualCamera.LookAt = transform.Find ("Camera LookAt Spot");
			myVirtualCamera.Follow = transform.Find ("Camera Follow");
		}
	}
}
