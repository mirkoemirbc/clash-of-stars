using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DebugTarget
{
	NONE,
	ALL,
	MOVEMENT,
	CAMERA
}

public class DebugBehaviour : MonoBehaviour 
{
	// I don't care if there is any other instance. All must be the same value.
	public static DebugTarget debuggingStatus = DebugTarget.NONE;

}
