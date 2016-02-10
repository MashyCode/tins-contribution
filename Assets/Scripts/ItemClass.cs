using UnityEngine;
using System.Collections;

public class ItemClass : MonoBehaviour {

	public Texture2D _emptySlot;
	public Texture2D _healthIcon;
	public Texture2D _weaponIcon;
	public Texture2D _torchIcon;
	public Texture2D _boneIcon;
	public Texture2D _axeIcon;
	public Texture2D _batteryIcon;
	public Texture2D _memStickIcon;

	static public Texture2D emptySlot;
	static public Texture2D healthIcon;
	static public Texture2D weaponIcon;
	static public Texture2D torchIcon;
	static public Texture2D boneIcon;
	static public Texture2D axeIcon;
	static public Texture2D batteryIcon;
	static public Texture2D memStickIcon;

	public ItemCreatorClass healthPot = new ItemCreatorClass(0,"Health Potion", healthIcon, "Restore health");
	public ItemCreatorClass weapon = new ItemCreatorClass(1, "Grant's Beard", weaponIcon, "It's ginger, 'Nuff said");
	public ItemCreatorClass torch = new ItemCreatorClass (2, "Torch", torchIcon, "Illuminate your path");
	public ItemCreatorClass bones = new ItemCreatorClass(3, "Bones", boneIcon, "Pile of bones");
	public ItemCreatorClass axe = new ItemCreatorClass(4, "Axe", axeIcon, "A sharp axe");
	public ItemCreatorClass battery = new ItemCreatorClass(5, "Battery", batteryIcon, "A baterry for a torch");
	public ItemCreatorClass memStick = new ItemCreatorClass(6, "Memory Stick", memStickIcon, "I can use this on a computer...");


	// Use this for initialization
	void Start () {
	
		emptySlot = _emptySlot;
		healthIcon = _healthIcon;
		weaponIcon = _weaponIcon;
		torchIcon = _torchIcon;
		boneIcon = _boneIcon;
		axeIcon = _axeIcon;
		batteryIcon = _batteryIcon;
		memStickIcon = _memStickIcon;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public class ItemCreatorClass
	{
		public int itemID;
		public string itemName;
		public Texture2D itemIcon;
		public string itemDesc;
		
		public ItemCreatorClass (int _id, string _name, Texture2D _texture, string _desc){
			itemID = _id;
			itemName = _name;
			itemIcon = _texture;
			itemDesc = _desc;
		}
	}
}
