using UnityEngine;
using System.Collections;
using UnityEngine.AI;
using UnityEngine.Networking;

public class ClickToMove : MonoBehaviour {

	public float shootDistance = 10f;
	public float shootRate = .5f;
	// public PlayerShooting shootingScript;

	private Animator anim;
	private NavMeshAgent navMeshAgent;
	private Transform targetedEnemy;
	private Ray shootRay;
	private RaycastHit shootHit;
	private bool walking;
	private bool fireClicked = false;
	private bool enemyClicked;
	private float nextFire;
	private NetworkIdentity playerNetworkId;

	// Use this for initialization
	void Awake () 
	{
		navMeshAgent = GetComponent<NavMeshAgent> ();
		playerNetworkId = GetComponent<NetworkIdentity> ();
	}

	// Update is called once per frame
	void Update () 
	{
		if (playerNetworkId.isLocalPlayer) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Input.GetMouseButtonDown (1)) {
				fireClicked = true;
				if (Physics.Raycast (ray, out hit, 1000f)) {
					if (hit.collider.CompareTag ("Enemy Champion") || hit.collider.CompareTag ("Enemy Ship")) {
						targetedEnemy = hit.transform;
						enemyClicked = true;
					} else {
						walking = true;
						enemyClicked = false;
						navMeshAgent.destination = hit.point;
						navMeshAgent.isStopped = false;
					}
				}
			}

			if (enemyClicked) {
				MoveAndShoot ();
			}

			if (fireClicked) {
				if (Vector3.Distance (transform.position, navMeshAgent.destination) <= navMeshAgent.stoppingDistance) {
					walking = false;
					navMeshAgent.isStopped = true;
					fireClicked = false;
					if (DebugBehaviour.debuggingStatus == DebugTarget.MOVEMENT || DebugBehaviour.debuggingStatus == DebugTarget.ALL)
						Debug.Log ("Stopped" + navMeshAgent.transform.position);
					transform.position = navMeshAgent.destination;
				} else {
					if (DebugBehaviour.debuggingStatus == DebugTarget.MOVEMENT || DebugBehaviour.debuggingStatus == DebugTarget.ALL)
						Debug.Log ("Walking" + navMeshAgent.transform.position + navMeshAgent.destination);
					walking = true;
				}
			}
		}
	}

	private void MoveAndShoot()
	{
		if (targetedEnemy == null)
			return;

		navMeshAgent.destination = targetedEnemy.position;
		if (navMeshAgent.remainingDistance >= shootDistance) {
			if (DebugBehaviour.debuggingStatus == DebugTarget.MOVEMENT || DebugBehaviour.debuggingStatus == DebugTarget.ALL)
				Debug.Log (navMeshAgent.remainingDistance.ToString () + " -> " + shootDistance.ToString ());
			navMeshAgent.isStopped = false;
			walking = true;
		}

		if (navMeshAgent.remainingDistance <= shootDistance) {

			transform.LookAt(targetedEnemy);
			Vector3 dirToShoot = targetedEnemy.transform.position - transform.position;
			if (Time.time > nextFire)
			{
				nextFire = Time.time + shootRate;
				//shootingScript.Shoot(dirToShoot);
			}
			navMeshAgent.isStopped = true;
			walking = false;
		}
	}

}
