using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player : NetworkBehaviour 
{

	public GameObject myCamera;
	private Cinemachine.CinemachineVirtualCamera myVirtualCamera;

	void Start ()
	{
		// First things first: We'll find the camera or use any camera already set.
		myCamera = GameObject.FindGameObjectWithTag ("MainCamera");
		if (DebugBehaviour.debuggingStatus == DebugTarget.CAMERA || DebugBehaviour.debuggingStatus == DebugTarget.ALL)
			Debug.Log (myCamera);

		// Switch On/Off the camera depends on Player is LocalPlayer
		myCamera.SetActive (isLocalPlayer);

		// Setting up some VirtualCamera only when Player is LocalPlayer
		if (isLocalPlayer == true) 
		{
			if (DebugBehaviour.debuggingStatus == DebugTarget.CAMERA || DebugBehaviour.debuggingStatus == DebugTarget.ALL)
				Debug.Log ("Is Local Player");

			myVirtualCamera = GameObject.FindObjectOfType<Cinemachine.CinemachineVirtualCamera> ();
			if (DebugBehaviour.debuggingStatus == DebugTarget.CAMERA || DebugBehaviour.debuggingStatus == DebugTarget.ALL)
				Debug.Log (myVirtualCamera);

			myVirtualCamera.Follow = transform.Find ("Camera Follow");
		}
	}
}
