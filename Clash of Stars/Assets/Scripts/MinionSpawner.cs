using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionSpawner : MonoBehaviour {

	public class WaveStruct 
	{
		public int kineticMinion;
		public int energyMinion;
		public int supportMinion;
		public int tankMinion;

		public WaveStruct (int k, int e, int s, int t)
		{
			kineticMinion = k;
			energyMinion = e;
			supportMinion = s;
			tankMinion = t;
		}
	}

	[Header("Wave Controller")]
	public float firstWaveColddown = 60.0f;
	public float waveColddown = 30.0f;

	[Header("GameObjects")]
	public GameObject[] minionPrefab;
	public GameObject spawnCenterTop;
	public GameObject spawnCenterBottom;

	[Header("Text on GUI")]
	public GameObject clockTime;
	public GameObject secondForMinionsText;

	[System.NonSerialized]
	public List<WaveStruct> wave = new List<WaveStruct> ();

	private IEnumerator timerCoroutine;

	// Use this for initialization
	void Start () {
		if (minionPrefab.Length < 4) 
		{
			Debug.LogError ("There is not enough Minion Prefabs!");
		} 
		else 
		{
			SpawnerConfig ();
			timerCoroutine = WaveSpawner (waveColddown);
			StartCoroutine (timerCoroutine);
		}
	}
	
	// Update is called once per frame
	void Update () {
		clockTime.GetComponent<GUIText>().text = "Time: " + Time.realtimeSinceStartup.ToString ("F1");
	}

	private IEnumerator WaveSpawner (float colddown)
	{
		yield return new WaitForSecondsRealtime (firstWaveColddown);

		secondForMinionsText.SetActive (true);
		yield return new WaitForSeconds (3.5f);
		secondForMinionsText.SetActive (false);


		while (true) 
		{
			for (int i = 0; i < wave.Count; i++) 
			{
				// Wait for next wave. Usually a fixed colddown.
				yield return new WaitForSeconds (colddown);

				// Loop through each KineticMinion
				for (int j = 0; j < wave[i].kineticMinion; j++) 
				{
					// Loop through each Minion in the wave
					yield return new WaitForSecondsRealtime (1.5f);
					Instantiate (minionPrefab[0],spawnCenterTop.transform.position,Quaternion.identity);
				}

				yield return new WaitForSeconds (1.5f);

				// Loop through each EnergyMinion
				for (int j = 0; j < wave[i].energyMinion; j++) 
				{
					// Loop through each Minion in the wave
					yield return new WaitForSecondsRealtime (1.5f);
					Instantiate (minionPrefab[1],spawnCenterTop.transform.position,Quaternion.identity);
				}

				yield return new WaitForSeconds (1.5f);

				// Loop through each SupportMinion
				for (int j = 0; j < wave[i].supportMinion; j++) 
				{
					// Loop through each Minion in the wave
					yield return new WaitForSecondsRealtime (1.5f);
					Instantiate (minionPrefab[2],spawnCenterTop.transform.position,Quaternion.identity);
				}

				yield return new WaitForSeconds (1.5f);

				// Loop through each TankMinion
				for (int j = 0; j < wave[i].tankMinion; j++) 
				{
					// Loop through each Minion in the wave
					yield return new WaitForSecondsRealtime (1.5f);
					Instantiate (minionPrefab[3],spawnCenterTop.transform.position,Quaternion.identity);
				}
			}
		}
	}

	private void SpawnerConfig ()
	{
		// <Summary>
		//  This function should configure how to spawn each wave 
		//  This could be done on the public Inspector... butttt...
		// </Summary>

		// FIRST WAVE
		wave.Add (new WaveStruct(3, 3, 0, 0));

		// SECOND WAVE
		wave.Add (new WaveStruct(3, 3, 1, 0));

		// THIRD WAVE
		wave.Add (new WaveStruct(3, 3, 0, 1));
	}
}
