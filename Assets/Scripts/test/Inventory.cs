using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : VRGUI 
{
	public ItemDefine Clipboard;
	public Vector3 mousePos;

	// create lsit
	public List<SlotDefine> Items = new List<SlotDefine> ();
	
	public static Inventory Instance;
	public Transform map;
	bool showInventory = false;
	bool showMap = false;

	public Texture backgroundTexture;
	public Texture foregroundTexture;
	public Texture frameTexture;

	public static int healthWidth = 200;
	public int healthHeight = 25;

	public int healthMarginLeft = 10;
	public int healthMarginTop = 10;
	
	public int frameWidth = 200;
	public int frameHeight = 25;
	
	public int frameMarginLeft = 10;
	public int frameMarginTop = 10;

	public void Start()
	{
		Instance = this;
	}

	public void Update()
	{
		mousePos = new Vector3(Input.mousePosition.x, Screen.height - Input.mousePosition.y, 0);

		if (Input.GetKeyDown("i"))
		{
			if(!showMap)
			{
				showInventory = !showInventory;
				Debug.Log ("OPEN INVENTORY");
			}
		}

		if(Input.GetKeyDown("m"))
		{
			int Index = 0;
			for (int x=0; x < 4; x++)
			{
				for (int y=0; y< 4; y++)
				{
					if (Items[Index].Item.itemName == "Map")
					{
						Debug.Log ("OPEN MAP");
						showMap = !showMap;
					}
					Index++;
				}
			}
		}

		if(showMap && !showInventory)
		{
			map.gameObject.SetActive(true);
		}
		else
		{
			map.gameObject.SetActive(false);
		}
	}

	public void AddItem(ItemDefine Item)
	{
		bool finished = false;

		for (int x = 0; x < 16; x++)
		{
			if (Items[x].Item.Icon == null)
			{
				if (!finished)
				{
					Items[x].Item = Item;
					finished = true;
				}
			}
		}
	}

	public override void OnVRGUI()
	{
		int Index = 0;
		//Debug.Log ("Index: " + Index);

		//#region #
		GUI.DrawTexture(new Rect(frameMarginLeft,frameMarginTop, frameMarginLeft + frameWidth,frameMarginTop + frameHeight), frameTexture, ScaleMode.ScaleToFit, true, 0);
		GUI.DrawTexture(new Rect(frameMarginLeft,frameMarginTop, frameMarginLeft + frameWidth,frameMarginTop + frameHeight), backgroundTexture, ScaleMode.ScaleToFit, true, 0);
		GUI.DrawTexture(new Rect(healthMarginLeft,healthMarginTop,healthWidth + healthMarginLeft, healthHeight), foregroundTexture, ScaleMode.ScaleAndCrop, true, 0);

		if (showInventory)
		{
			// 4 across, 4 down (inventory)
			for (int y = 0; y < 4; y++)
			{

				for (int x = 0; x < 4; x++)
				{

					// Spacing
					Items[Index].Slot.x = (x * 175) + (Screen.width/2) - 300;
					Items[Index].Slot.y = (y * 175) + (Screen.height/2) - 200;
					Items[Index].Slot.width = 150;
					Items[Index].Slot.height = 150;

					//Debug.Log("Trying to determine out of range index...." + Items[Index].Slot.x);



					GUI.Box(Items[Index].Slot,new GUIContent( Items[Index].Item.Icon, Items[Index].Item.itemDesc));

					if (Items[Index].Slot.Contains(mousePos))
					{
						if (Event.current.type == EventType.MouseDrag)
						{
							if (Clipboard.Icon == null)
							{
								if (Items[Index].Item.Icon != null)
								{
									Clipboard = Items[Index].Item;
									Items[Index].Item = new ItemDefine();
								}
							}
						}
						else if (Event.current.type == EventType.MouseUp)
						{
							if (Clipboard.Icon != null)
							{
								if (Items[Index].Item.Icon == null)
								{
									Items[Index].Item= Clipboard;
									Clipboard = new ItemDefine();
									Debug.Log ("INVENTORY BUTTON PRESSED");
								}
							}
						}
					}

					Index++;

					//Debug.LogError("Invalid inex" + Items[Index]);
				}
			}
		}
		//#endregion

		if (Clipboard.Icon != null)
		{
			GUI.Box(new Rect(mousePos.x - 25, mousePos.y - 25, 50, 50), Clipboard.Icon);
		}

		if (GUI.tooltip != "")
		{
			if (Clipboard.Icon == null)
			{
				GUI.Box (new Rect(mousePos.x - 75, mousePos.y - 25, 150, 25), GUI.tooltip);
			}
		}
	}
}

[System.Serializable]
public class SlotDefine{
	public ItemDefine Item;
	public Rect Slot;
}