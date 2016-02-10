using UnityEngine;
using System.Collections;

public class PlayerAttacking : MonoBehaviour 
{
	Transform Player;
	bool Attack = false;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Attack == true)
		{
			if(Input.GetMouseButtonDown(0))
			{
				Debug.Log("EATITFUCKO!!");
				Hit();
			}
		}
	}

	void Hit()
	{
		GolemBehaviour.EnemyHealth -= 10;
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.name == "golem")
		{
			Attack = true;
		}
	}
}