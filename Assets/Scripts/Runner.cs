using UnityEngine;
using System.Collections;

public class Runner : MonoBehaviour {

	public GameObject StartPoint;
	public GameObject EndPoint;
	Keyboard kb;
	Vector3 Lane1 = new Vector3 (0, 0, 1.3f);
	Vector3 Lane3 = new Vector3 (0, 0, -1.3f);
	Vector3 StartMarker;
	Vector3 EndMarker;
	public float speed = 1.0f;
	private float startTime;
	private float journeyLength;

	// Use this for initialization
	void Start () {
		startTime = Time.time;

		kb = GameObject.Find ("KeyHolder").GetComponent<Keyboard> ();

		StartPoint = GameObject.Find ("StartPoint");
		EndPoint = GameObject.Find ("EndPoint");


		int rand = Random.Range (1, 4);
		switch(rand)
		{
		case 1:
			StartMarker = StartPoint.transform.position + Lane1;
			EndMarker = EndPoint.transform.position + Lane1;
			this.transform.position = StartMarker;
			this.name = "Runner Lane 1";
			break;
		case 2:
			StartMarker = StartPoint.transform.position;
			EndMarker = EndPoint.transform.position;
			this.transform.position = StartMarker;
			this.name = "Runner Lane 2";
			break;
		case 3:
			StartMarker = StartPoint.transform.position + Lane3;
			EndMarker = EndPoint.transform.position + Lane3;
			this.transform.position = StartMarker;
			this.name = "Runner Lane 3";
			break;
		default:
			StartMarker = StartPoint.transform.position;
			EndMarker = EndPoint.transform.position;
			this.transform.position = StartMarker;
			this.name = "Runner Lane ERROR";
			break;
		}

		journeyLength = Vector3.Distance (StartMarker, EndMarker);
	
	}
	
	// Update is called once per frame
	void Update () {

		float distCovered = (Time.time - startTime) * speed;
		float fracJourney = distCovered / journeyLength;
		transform.position = Vector3.Lerp(StartMarker, EndMarker, fracJourney);

		if(transform.position == EndMarker)
		{
			Destroy (this);
		}

	}
	
}
