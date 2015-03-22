using UnityEngine;
using System.Collections;

public class Keyboard : MonoBehaviour {

	
	GameObject[] keys;
	float lastUpdate;
	public bool gamePaused = false;
	public int lives = 3;
	void Start () {

		keys = GameObject.FindGameObjectsWithTag ("key");
	
	}
	
	// Update is called once per frame
	void Update () {

		if(!gamePaused)
		{
		if(Time.time - lastUpdate > Random.Range(1, 3))
		{
				int rand = Random.Range (0, keys.Length);
				if(!keys[rand].GetComponent<Key>().popped)
				{
					keys[rand].GetComponent<Key>().popped = true;
				}

			lastUpdate = Time.time;
		}
		}
	
	}
	
}
