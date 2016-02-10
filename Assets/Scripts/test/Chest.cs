using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Chest : VRGUI {
	public bool isLooting; // public booleans default to false

	public List<ItemDefine> possibleItems = new List<ItemDefine>();
	public List<ItemDefine> chosenItems = new List<ItemDefine>();

	public GameObject Target;
	public ItemDefine Item;
	public float collideDistance;

	public void Start()
	{
		int chosen = 0;
		for (int x =0; x< possibleItems.Count; x++)
		{
			chosen = Random.Range(0,3);
			Debug.Log (chosen);
			if (chosen == 1)
			{
				chosenItems.Add (possibleItems[x]);
			}
		}
	}

	public void Update()
	{
		if (chosenItems.Count == 0)
		{
			Destroy(gameObject);
		}


		// This allows chest to open when player collides with it, but disable  
		// mouse click due to the changing the Boolean to false on a constant basis
		//*
		Target = GameObject.FindGameObjectWithTag("Player");
		
		if (Vector3.Distance(transform.position, Target.transform.position) < collideDistance)
		{
			isLooting = true;
			//Inventory.Instance.AddItem(Item);
			//Destroy (gameObject);
		}
		else{
			isLooting = false;
		}
		//*/
	}

	/*
	public void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.name == "player")
		{
			Debug.Log ("collision with player");
		}
	}
*/

	public void OnMouseOver()
	{
		if (Input.GetKeyDown (KeyCode.Mouse0))
		{
			isLooting = !isLooting;
		}
	}


	public override void OnVRGUI()
	{
		if (isLooting){
			GUI.BeginGroup (new Rect(Screen.width - 310, 10, 300, 400), "", "Box");
			for (int x =0; x < chosenItems.Count; x++)
			{
				GUI.Box (new Rect(70,(x * 55) + 10, 220, 50), chosenItems[x].itemName);

				if (GUI.Button (new Rect(10,(x * 55) + 10, 50,50), chosenItems[x].Icon))
				{
					Inventory.Instance.AddItem(chosenItems[x]);
					chosenItems.RemoveAt(x);

				}
			}
			GUI.EndGroup();
		}
	}

}
