using UnityEngine;
using System.Collections;

public class Keyboard : MonoBehaviour {

	
	GameObject[] keys;
	public GameObject Runner;
	float keyUpdate;
	float runnerUpdate;
	public bool gamePaused = false;
	public int lives = 3;
	void Start () {

		keys = GameObject.FindGameObjectsWithTag ("key");
	
	}
	
	// Update is called once per frame
	void Update () {

		if (!gamePaused) {
			if (Time.time - keyUpdate > Random.Range (3, 5)) {
				int rand = Random.Range (0, keys.Length);
				if (!keys [rand].GetComponent<Key> ().popped) {
					keys [rand].GetComponent<Key> ().popped = true;
				}

				keyUpdate = Time.time;
			}
			if (Time.time - runnerUpdate > Random.Range (3, 6)) {

				Instantiate (Runner);
				
				runnerUpdate = Time.time;
			}
		} else {
			Time.timeScale = 0;
		}

		if(lives < 1)
		{
			gamePaused = true;
		}
	
	}

	void OnGUI()
	{
		GUILayout.Box ("Lives: " + lives);
		if (gamePaused) {
			GUILayout.Box("GAME OVER");
		}
	}
	
}
