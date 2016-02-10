using UnityEngine;
using System.Collections;

public class EventHandler : MonoBehaviour {

	public static bool isBasementTouched = false;
	public static bool isFuseBoxTouched = false;
	public static bool isMirrorTouched = false;

	// Variables for opending doors
	private float doorOpenSpeed = 3.0f;

	private GameObject _basementDoor;

	// Use this for initialization
	void Start () {
		_basementDoor = GameObject.Find("BasementDoor");
		Debug.Log("Called event handler");
	}
	
	// Update is called once per frame
	void Update () {

		if(isBasementTouched)
		{
			Debug.Log("EventHandler for basement door called");
			OpenBasement();
			_basementDoor.transform.parent.Rotate(Vector3.up * doorOpenSpeed * Time.deltaTime);

		}


	}

	void OpenBasement()
	{
		_basementDoor.transform.parent.Rotate(Vector3.up * doorOpenSpeed * Time.deltaTime);
	}
}
