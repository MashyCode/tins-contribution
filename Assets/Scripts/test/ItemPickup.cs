using UnityEngine;
using System.Collections;

public class ItemPickup : MonoBehaviour {
	public ItemDefine Item;
	public float collideDistance;
	private GameObject Target;

	public void Update()
	{
		Target = GameObject.FindGameObjectWithTag("Player");

		if (Vector3.Distance(transform.position, Target.transform.position) < collideDistance)
		{

			Inventory.Instance.AddItem(Item);
			Destroy (gameObject);
		}

		transform.Rotate (Vector3.forward * Time.deltaTime * 100);

	}


}
