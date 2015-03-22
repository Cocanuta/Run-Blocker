using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour {

	public KeyCode key;
	public Vector3 upPos;
	public Vector3 downPos;
	public bool popped;
	public Material mat1;
	public Material mat2;
	Keyboard kb;

	// Use this for initialization
	void Start () {
		kb = GameObject.Find ("KeyHolder").GetComponent<Keyboard> ();
		downPos = this.transform.position;
		upPos = this.transform.position - new Vector3 (0, -0.4f, 0);
		this.gameObject.GetComponent<Renderer> ().material = mat1;
		this.gameObject.tag = "key";
	}
	
	// Update is called once per frame
	void Update () {

		if(popped)
		{
			this.transform.position = upPos;
			this.gameObject.GetComponent<Renderer>().material = mat2;
		}
		else
		{
			this.transform.position = downPos;
			this.gameObject.GetComponent<Renderer> ().material = mat1;
		}
		if(Input.GetKeyDown(key))
		{
			popped = false;
		}

	
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.name == "Runner") {
			Destroy(col.gameObject);
			if (popped) {
				kb.lives--;
			}
		}
	}
}
