using UnityEngine;
using System.Collections;

public class healthTest : MonoBehaviour {
	public static int health = 100;
	private float attackTimer;
	public AudioClip damaged;
	private bool attackable = false;
	public GameObject ragDoll;
	private float respawnTimer;
	public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
//		Debug.Log (health);
		respawnTimer -= Time.deltaTime;
		if(health <= 0)
		{

			respawnTimer = 5.0f;
			Debug.Log (respawnTimer);
			//Debug.Log("Oh you dead");
			enableDeath();
			if (respawnTimer <= 0)
			{
				GameObject newPlayer = Instantiate(player,transform.position, transform.rotation ) as GameObject;
			}
//			GameObject restart = Instantiate() as GameObject; 
		}
	}
		
	void enableDeath()
	{
		Destroy(gameObject);
		GameObject deadBody = Instantiate(ragDoll, transform.position, transform.rotation) as GameObject;
	}

	public void OnCollisionEnter (Collision col)
	{
		if (attackTimer < 0.0f)
		{
			attackable = true;
		}
		if(col.gameObject.name == "golem" && attackable == true)
		{
			//transform.position = transform.position
			//health -= 10;
		}
	}


}