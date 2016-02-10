using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DisplayLootableObject : MonoBehaviour {

	private Rect inventoryWindowRect = new Rect(300,100,400,400);
	private bool showInventory = false;

	//public bool fixedLoot = false;

	private LootableObject lootObject;


	private List<Texture2D> lootDictionary = new List<Texture2D>()
	{
		{ItemClass.emptySlot},
		{ItemClass.emptySlot},
		{ItemClass.emptySlot}
	};


	private List<int> lootDictionaryAmount = new List<int>()
	{0,0,0};


	//ItemClass itemObject = new ItemClass();

	private Ray mouseRay;
	private RaycastHit rayHit;

	/*
	public string firstLoot = string.Empty;
	public string secondLoot = string.Empty;
	public string thirdLoot = string.Empty;
	//public string fourthLoot = string.Empty;
	//public string fifthLoot = string.Empty;
	//public string sixthLoot = string.Empty;

	public int firstLootAmount = 0;
	public int secondLootAmount = 0;
	public int thirdLootAmount = 0;
	//public int fourthLootAmount = 0;
	//public int fifthLootAmount = 0;
	//public int sixthLootAmount = 0;
	*/
	void Start () {
		
		// set items in chest an amount

		/*
		if (fixedLoot == false)
		{
			// randomise the loot of this object
			lootDictionary[0] = lootRandomizer ();
			lootDictionaryAmount[0] = amountRandomizer();

			lootDictionary[1] = lootRandomizer();
			lootDictionaryAmount[1] = amountRandomizer();

			lootDictionary[2] = lootRandomizer();
			lootDictionaryAmount[2] = amountRandomizer();
		}
		else
		{
			// set the fixed items
			lootDictionary[0] = firstLoot;
			lootDictionaryAmount[0] = firstLootAmount;
			if (firstLootAmount == 0){firstLootAmount = 0;}

			lootDictionary[1] = secondLoot;
			lootDictionaryAmount[1] = secondLootAmount;
			if (secondLootAmount == 0){secondLootAmount = 0;}

			lootDictionary[2] = thirdLoot;
			lootDictionaryAmount[2] = thirdLootAmount;
			if (thirdLootAmount == 0){thirdLootAmount = 0;}

		}

		
		//lootDictionary[1] = itemObject.torch.itemName;
		//lootDictionaryAmount[1] = 1;

		//lootDictionary[2] = itemObject.healthPot.itemName;
		//lootDictionaryAmount[2] = 10;
		*/
	}


	void Update () {
		mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

		if(Input.GetButtonDown("Fire1")){
			Physics.Raycast (mouseRay, out rayHit);
			if (rayHit.collider.transform.tag == "LootableObject")
			{
				lootObject = rayHit.collider.gameObject.GetComponent<LootableObject>();
				lootDictionary = lootObject.lootDictionary;				// set the individual item to display
				lootDictionaryAmount = lootObject.lootDictionaryAmount; // set the individual item amount to display
				showInventory = true;
			}
		}

		// close loot window
		if (Input.GetKey(KeyCode.Mouse1))
		{	
			Debug.Log ("Close LootableObjec window");
			showInventory = false;
		}
	}


	void OnGUI()
	{
		if (showInventory)
		{
			inventoryWindowRect = GUI.Window(0, inventoryWindowRect, InventoryWindowMethod, "Chest");
		}
	}

	void InventoryWindowMethod(int windowID){
		// Display
		GUILayout.BeginArea (new Rect(0,50,400,400));
		GUILayout.BeginHorizontal ();

		// First slot
		if (GUILayout.Button (lootDictionary[0], GUILayout.Height (50))){
			if (lootDictionary[0] != ItemClass.emptySlot && lootDictionaryAmount[0] != 0){

				InventoryGUI.inventoryNameDictionary[0] = lootDictionary[0];

				if (lootDictionaryAmount[0] != 0){
					lootDictionaryAmount[0] -= 1;
					InventoryGUI.dictionaryAmounts[0] +=1;
				}

				if (lootDictionaryAmount[0] == 0){
					lootDictionary[0] = ItemClass.emptySlot;
				}
			}
		}
		if (lootDictionaryAmount[0] != 0){
			GUILayout.Box (lootDictionaryAmount[0].ToString(), GUILayout.Height (50));
		}

		// 2nd Slot
		if (GUILayout.Button (lootDictionary[1], GUILayout.Height (50))){
			if (lootDictionary[1] != ItemClass.emptySlot && lootDictionaryAmount[1] != 0){

				InventoryGUI.inventoryNameDictionary[1] = lootDictionary[1];

				if (lootDictionaryAmount[1] != 0){
					lootDictionaryAmount[1] -= 1;
					InventoryGUI.dictionaryAmounts[1] +=1;
				}
				
				if (lootDictionaryAmount[1] == 0){
					lootDictionary[1] = ItemClass.emptySlot;
				}
			}
		}

		if (lootDictionaryAmount[1] != 0){
			GUILayout.Box (lootDictionaryAmount[1].ToString(), GUILayout.Height (50));
		}


		// 3rd slot
		if (GUILayout.Button (lootDictionary[2], GUILayout.Height (50))){
			if (lootDictionary[2] != ItemClass.emptySlot && lootDictionaryAmount[2] != 0){

				InventoryGUI.inventoryNameDictionary[2] = lootDictionary[2];

				if (lootDictionaryAmount[2] != 0){
					lootDictionaryAmount[2] -= 1;
					InventoryGUI.dictionaryAmounts[2] +=1;
				}
				
				if (lootDictionaryAmount[2] == 0){
					lootDictionary[2] = ItemClass.emptySlot;
				}
			}
		}
		if (lootDictionaryAmount[2] != 0){
			GUILayout.Box (lootDictionaryAmount[2].ToString(), GUILayout.Height (50));
		}

		GUILayout.EndHorizontal();
		GUILayout.EndArea ();
	}

	/*
	public string lootRandomizer()
	{
		ItemClass items = new ItemClass();
		string returnString = string.Empty;
		int randomNumber = Random.Range (0,7);

		switch (randomNumber)
		{
		case 0:
			returnString = items.healthPot.itemName;
			Debug.Log ("health pot");
			break;
		case 2:
			returnString = items.weapon.itemName;
			Debug.Log ("grant's beard");
			break;
		case 3:
			returnString = items.torch.itemName;
			Debug.Log ("torch");
			break;
		case 4:
			returnString = items.bones.itemName;
			Debug.Log ("bones");
			break;
		case 5:
			returnString = items.axe.itemName;
			Debug.Log ("axe");
			break;
		case 6:
			returnString = items.battery.itemName;
			Debug.Log ("battery");
			break;
		case 7:
			returnString = items.memStick.itemName;
			Debug.Log ("memstick");
			break;
		default:
			returnString = string.Empty;
			break;
		}

		return returnString;
	}

	public int amountRandomizer()
	{
		int returnAmount = 0;
		returnAmount = Random.Range (0,7);
		if (returnAmount == 0){returnAmount = 1;}

		return returnAmount;
	}
	*/
}
