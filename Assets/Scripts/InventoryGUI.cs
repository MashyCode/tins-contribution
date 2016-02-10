using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryGUI : VRGUI {

	private Rect inventoryWindowRect = new Rect(300,100,400,400);
	private bool showInventory = false;
	Vector2 mousePos = Event.current.mousePosition;
	
	// Item dictionary
	static public Dictionary<int,Texture2D> inventoryNameDictionary = new Dictionary<int, Texture2D>()
	{
		{0,ItemClass.emptySlot},
		{1,ItemClass.emptySlot},
		{2,ItemClass.emptySlot},
		{3,ItemClass.emptySlot},
		{4,ItemClass.emptySlot},
		{5,ItemClass.emptySlot}
	};


	// Usually would have multiple game icons
	//public Texture2D icon;
	//public Texture2D empty;

	static public List<int> dictionaryAmounts = new List<int>()
	{ 0,0,0,0,0,0 }; // Correlates with the number of slots in Dictionary (see above)


	//Create instance of item
	ItemClass itemObject = new ItemClass();

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void OnVRGUI(){
		 //new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);
		// Toggle button
		showInventory = GUI.Toggle(new Rect(800, 50, 100, 50), showInventory, "Inventory");

		if (showInventory)
		{
			inventoryWindowRect = GUI.Window (0, inventoryWindowRect, inventoryWindowMethod, "Inventory");

			/*
			GUILayout.BeginVertical();
				GUILayout.Button ("First");
				GUILayout.Button ("Second");
				GUILayout.Button ("Third");
			GUILayout.EndVertical();
*/
			if (Event.current.type == EventType.Repaint &&
			    GUILayoutUtility.GetLastRect().Contains(Event.current.mousePosition))
			{
				GUILayout.Label ("Mouse Over!");
			}
			else
			{
				GUILayout.Label ("Mouse Not Over!");
			}
		}
	}

	void inventoryWindowMethod(int windowID)
	{

		// Display
		GUILayout.BeginArea (new Rect(0,50,400,400));

			GUILayout.BeginHorizontal ();

				GUILayout.Button (inventoryNameDictionary[0], GUILayout.Height(50));
				if (dictionaryAmounts[0] != 0){
					GUILayout.Box (dictionaryAmounts[0].ToString(), GUILayout.Height (50));
				}

				GUILayout.Button (inventoryNameDictionary[1], GUILayout.Height(50));
				if (dictionaryAmounts[1] != 0){
					GUILayout.Box (dictionaryAmounts[1].ToString(), GUILayout.Height (50));
				}

				GUILayout.Button (inventoryNameDictionary[2], GUILayout.Height(50));
				if (dictionaryAmounts[2] != 0){
					GUILayout.Box (dictionaryAmounts[2].ToString(), GUILayout.Height (50));
				}
			GUILayout.EndHorizontal();

			GUILayout.BeginHorizontal ();
				GUILayout.Button (inventoryNameDictionary[3], GUILayout.Height(50));
				if (dictionaryAmounts[3] != 0){
					GUILayout.Box (dictionaryAmounts[3].ToString(), GUILayout.Height (50));
				}

				GUILayout.Button (inventoryNameDictionary[4], GUILayout.Height(50));
				if (dictionaryAmounts[4] != 0){
					GUILayout.Box (dictionaryAmounts[4].ToString(), GUILayout.Height (50));
				}

				GUILayout.Button (inventoryNameDictionary[5], GUILayout.Height(50));
				if (dictionaryAmounts[5] != 0){
					GUILayout.Box (dictionaryAmounts[5].ToString(), GUILayout.Height (50));
				}
			GUILayout.EndHorizontal();
		/*
			GUILayout.BeginHorizontal ();
				GUILayout.Button ("Item 7", GUILayout.Height(50));
				GUILayout.Button ("Item 8", GUILayout.Height(50));
				GUILayout.Button ("Item 9", GUILayout.Height(50));
			GUILayout.EndHorizontal();

			GUILayout.BeginHorizontal ();
				GUILayout.Button ("Item 10", GUILayout.Height(50));
				GUILayout.Button ("Item 11", GUILayout.Height(50));
				GUILayout.Button ("Item 12", GUILayout.Height(50));
			GUILayout.EndHorizontal();
		*/
		GUILayout.EndArea ();
	}
}
