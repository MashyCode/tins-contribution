using UnityEngine;
using System.Collections;

public class PlayerHit : MonoBehaviour 
{
	public static int PlayerHealth = 100;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(PlayerHealth == 0)
		{
			//Instantiate(masterObject, transform.position, transform.rotation);
			//Destroy(gameObject);
		}
	}
}
