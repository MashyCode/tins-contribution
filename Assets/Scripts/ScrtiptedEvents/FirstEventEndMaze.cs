using UnityEngine;
using System.Collections;

public class FirstEventEndMaze : MonoBehaviour {

	public bool eventTriggered = false;

	public GameObject player;

	void OnTriggerEnter(Collider col){

		if (col.collider.name == "Player") {
			Debug.Log ("INITIALISE FIRST EVENT");

			mainGameScript.seated = false;

		}

	}

	void Update () {

	
	}
}
