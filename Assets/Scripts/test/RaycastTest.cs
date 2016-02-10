using UnityEngine;
using System.Collections;

/* Because there is an uncertain amount of interactable objects in the game,
 * this script might need changing at a later date
*/

/*
 * Bugs: 
 * 
 * - When in AOE, the raycast, despite length, still reacts to other objects - FIXED
 * - Box collider things it should have rigidbody...the boob.
 * 
*/

public class RaycastTest : MonoBehaviour {

	// Are we in the area of a pickup?
	public bool isInAOE = false;

	// What is the minimum distance of the ray?
	public float minRayDistance = 0.5f;

	// What is the maximum distance of the ray?
	public float maxRayDistance = 1.5f;

	// The custom GUI skin we want to use
	public GUISkin guiSkin;

	// How long till GUI should remove?
	public float guiResetTime = 2;

	// Script test for interaction
	public bool hasPickedCube = false;

	public GameObject chest;
	
	// Tell the ray the position it should go in
	Ray ray;
	
	// Raycast hit used to determine collison
	RaycastHit hit;

	// THE BOOLS THERE MIGHT BE A BETTER WAY
	private bool HitCube = false;
	private bool HitSphere = false;

	// Use this for initialization
	void Start () {
		chest = GameObject.FindGameObjectWithTag("LootableChest");
	}
	
	// Update is called once per frame
	void Update () {

		ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		// Center the mouse to screen every frame! 
		//Screen.lockCursor = true;
		//Screen.lockCursor = false;



		// Only if we are in the pickup area...
		if(isInAOE)
		{

			if(Input.GetMouseButtonDown(0))
			{

				if(Physics.Raycast(ray, out hit))
				{

					//Debug.Log("The Distance is " + hit.distance);

					// Restrict the hit distance of the raycast
					if(hit.distance > minRayDistance && hit.distance < maxRayDistance)
					{
						switch(hit.transform.gameObject.tag)
						{
							case "LootableChest":
								hasPickedCube = true;
								HitCube = true;
								Destroy(hit.transform.gameObject.collider);
								Destroy(hit.transform.gameObject);
							break;

							case "Sphere":
								
								if(hasPickedCube)
								{
								HitSphere = true;
									Destroy(hit.transform.gameObject.collider);
									Destroy(hit.transform.gameObject);
								}

							break;
						}
						//Debug.Log("Hit this object... " + hit.transform.gameObject.name);
					}

				}

			}

		}	

	}

	// Detect if we are in the area of a pickup
	void OnTriggerEnter(Collider other)
	{
		// Every area where a chance to pickup an item is, we can simply call it AOE or something...
		if(other.gameObject.name == "AOE")
		{
			// Considering Raycast only works in update, we need a bool to tell the Ray when and when not to activate
			//Debug.Log("Entered Pickup Area");

			// We are in an AOE. 
			isInAOE = true;
		}

	}

	void OnGUI()
	{
		// Enable the custom GUI Font
		GUI.skin = guiSkin;

		// When they look at the items

		if(Physics.Raycast(ray, out hit))
		{
			if(hit.distance > minRayDistance && hit.distance < maxRayDistance)
			{
				switch (hit.transform.gameObject.name)
				{
					case "Chest":
						GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 400, 100), "Pick Up Cube");
						chest.GetComponent<Chest>().isLooting = true;
					break;

					case "Sphere":
					if(hasPickedCube)
					{
						GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 400, 100), "Pick Up Sphere");
					}

					else
					{
						GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 400, 100), "You Need Cube.");
					}
						
					break;

				}
			}

		}

		// When they pick up the item

		if(HitCube == true)
		{
			GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 400, 100), "Got Cube");
			StartCoroutine(resetGUI());
		}

		if(HitSphere == true)
		{
			if(hasPickedCube)
			{
				GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 400, 100), "Picked Up Sphere");
				StartCoroutine(resetGUI());
			}
		}

		else
		{
			GUI.enabled = false;
		}
	
	}	

	IEnumerator resetGUI()
	{
		yield return new WaitForSeconds(guiResetTime);
		HitCube = false;
		HitSphere = false;
	}

}
