using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LootableObject : MonoBehaviour {

	ItemClass itemObject = new ItemClass();
	public bool fixedLoot = false;

	public List<Texture2D> lootDictionary = new List<Texture2D>()
	{
		{ItemClass.emptySlot},
		{ItemClass.emptySlot},
		{ItemClass.emptySlot}
	};
	
	
	public List<int> lootDictionaryAmount = new List<int>()
	{0,0,0};

	public Texture2D firstLoot = ItemClass.emptySlot;
	public Texture2D secondLoot = ItemClass.emptySlot;
	public Texture2D thirdLoot = ItemClass.emptySlot;

	public int firstLootAmount = 0;
	public int secondLootAmount = 0;
	public int thirdLootAmount = 0;

	// Use this for initialization
	void Start () {
		if (fixedLoot == false)
		{
			// randomise the loot of this object
			lootDictionary[0] = lootRandomizer();

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
	}

	// Update is called once per frame
	void Update () {
	
	}

	public Texture2D lootRandomizer()
	{
		ItemClass items = new ItemClass();
		//string returnString = string.Empty;
		Texture2D returnString = ItemClass.emptySlot;
		int randomNumber = Random.Range (0,6);
		//Debug.Log ("Loot Randomizer number: " + randomNumber);

		switch (randomNumber)
		{
		case 0:
			returnString = items.healthPot.itemIcon;
			Debug.Log ("health pot");
			break;
		case 1:
			returnString = items.weapon.itemIcon;
			Debug.Log ("grant's beard");
			break;
		case 2:
			returnString = items.torch.itemIcon;
			Debug.Log ("torch");
			break;
		case 3:
			returnString = items.bones.itemIcon;
			Debug.Log ("bones");
			break;
		case 4:
			returnString = items.axe.itemIcon;
			Debug.Log ("axe");
			break;
		case 5:
			returnString = items.battery.itemIcon;
			Debug.Log ("battery");
			break;
		case 6:
			returnString = items.memStick.itemIcon;
			Debug.Log ("memstick");
			break;
		default:
			returnString = ItemClass.emptySlot;
			break;
		}
		
		return returnString;
	}
	
	public int amountRandomizer()
	{
		int returnAmount = 0;
		returnAmount = Random.Range (1,7);
		//if (returnAmount == 0){returnAmount = 1;}
		
		return returnAmount;
	}
}

