using UnityEngine;
using System.Collections;

/* Because there is an uncertain amount of interactable objects in the game,
 * this script might need changing at a later date
*/

/*
 * Bugs: 
 * 
 * - When in AOE, the raycast, despite length, still reacts to other objects - FIXED
 * 
 * 
*/

public class FPRayCast : MonoBehaviour {

	// What is the maximum distance of the ray?
	public float maxRayDistance = 2f;

	// How long till GUI should remove?
	public float guiResetTime = 2;

	// Tell the ray the position it should go in
	Ray ray;
	
	// Raycast hit used to determine collison
	public static RaycastHit hit;

	// One Bool.
	private bool HitObject = false;

	public float doorOpenSpeed = 3.0f;

	public bool doorClick = false;
	public GameObject gamepad;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		// Center the mouse to screen every frame! 
		Screen.lockCursor = true;

		//Screen.lockCursor = false;

		Vector3 forward = transform.TransformDirection(Vector3.forward) * maxRayDistance;

		Debug.DrawRay(transform.position, forward ,Color.green);

		if(Physics.Raycast(ray, out hit))
		{
			if(Input.GetMouseButtonDown(0))
			{

				// Determine what object we hit...
				switch (hit.transform.gameObject.name)
				{
							
					case "BasementDoor":
						
						// Very messy way of doing doors. Because we are using this switch statement, Update will only run this part of the code ONCE i.e. One frame, 
						// which WILL make the door rotate 1 degree to 90 every time it is clicked instead of one continous motion. Proving a booling and an object reference, 
						// the door will rotate to how we need it to

						if(EventHandler.isBasementTouched)
						{
							EventHandler.isBasementTouched = false;
						}

						else if(!EventHandler.isBasementTouched)
						{
							EventHandler.isBasementTouched = true;
						}

						
						Debug.Log("Basement Door Clicked");
						
							
					break;

					case "control3":
						mainGameScript.seated = true;
						Debug.Log("RAYCAST ON THE CONTROLLER");
						//HitObject = true;

					break;
				}

			}

		}

	}


}