using UnityEngine;
using System.Collections;

public class GolemBehaviour : MonoBehaviour 
{
	public Transform Player;
	public NavMeshAgent Golem;
	public healthTest healthTestReference;
	public Transform[] Waypoints;
	public int currentWaypoint;
	public static int EnemyHealth = 50;
	private int playerHealth;
	public float PlayerDistance;
	private float StopRange = 40.0f; 
	private float ChaseRange = 20.0f; 
	private float AttackRange = 3.0f;
	private float Speed = 1.0f;
	private float ForceSpeed = 10.0f;
	private float pauseDuration = 40.0f; 
	private float pauseAttack = 8.0f;
	private float attackTime = 3.0f;//Time.time;
	private int attackRepeatTime = 1;
	private bool attacking = false;
	private float impact = 20;
	// Use this for initialization
	void Start () 
	{

		playerHealth = healthTest.health;
		Player = GameObject.FindWithTag("Player").transform; 
		currentWaypoint = Random.Range(0,Waypoints.Length); 
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Debug.Log (Time.time);
		int attackTypes = Random.Range (1, 2);
		PlayerDistance = Vector3.Distance(Player.position, transform.position);

		if(PlayerDistance<=AttackRange && Time.time > attackTime) 
		{
			Hit();
			attackTime = Time.time + attackRepeatTime;
			if (attackTypes == 1)
			{
			animation.CrossFade("hpunch", 0.5f);
			}
			else if (attackTypes == 2)
			{
			animation.CrossFade("punch", 0.5f);
			}
		}
		else if(PlayerDistance<=ChaseRange && PlayerDistance>AttackRange)
		{
			Golem.speed = 4.0f;
			Golem.destination = Player.position;
			animation.CrossFade("run", 0.5f);
		}
		if(PlayerDistance>ChaseRange || healthTest.health <= 0)
		{
			animation.CrossFade("walk", 0.5f);
			Vector3 target = Waypoints[currentWaypoint].position;
			Vector3 moveDirection = target - transform.position;
			Vector3 velocity = rigidbody.velocity; 
			
			if (pauseDuration <= 0.0f)
			{
				pauseDuration = 40.0f;
				currentWaypoint=Random.Range(0,Waypoints.Length);
			}   
			
			if(moveDirection.magnitude < 3.0f)
			{
				pauseDuration -= 0.1f;
				animation.CrossFade("idle", 0.1f);
			}

			else
			{
				velocity = moveDirection.normalized*Speed;
				Golem.destination = Waypoints[currentWaypoint].position;
			}
		}	
	}
	void Hit()
	{
		//if(attacking)
		//{
		if (Time.time > attackTime)
		{
			Inventory.healthWidth -= 20;
			healthTest.health -= 10;
		}
		//	attacking = !attacking;
		//}
	}
}
