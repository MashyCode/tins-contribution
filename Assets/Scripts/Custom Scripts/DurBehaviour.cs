using UnityEngine;
using System.Collections;

public class DurBehaviour : MonoBehaviour 
{
	public Transform Player;
	public NavMeshAgent DurEnemy;
	public Transform[] Waypoints;
	public int currentWaypoint;     
	public float PlayerDistance;
	private float StopRange = 40.0f; 
	private float ChaseRange = 20.0f; 
	private float AttackRange = 3.0f;
	private float Speed = 1.0f;
	private float ForceSpeed = 10.0f;
	private float pauseDuration = 40.0f; 
	private float pauseAttack = 8.0f;
	private float attackTime = Time.time;
	private int attackRepeatTime = 5;
	
	// Use this for initialization
	void Start () 
	{
		Player = GameObject.FindWithTag("Player").transform; 
		currentWaypoint = Random.Range(0,Waypoints.Length); 
	}
	
	// Update is called once per frame
	void Update () 
	{
		PlayerDistance = Vector3.Distance(Player.position, transform.position);
		
		if(PlayerDistance<=AttackRange && Time.time > attackTime) 
		{ 

		}
		else if(PlayerDistance<=ChaseRange && PlayerDistance>AttackRange)
		{
			DurEnemy.speed = 2.0f;
			DurEnemy.destination = Player.position;
		}
		else if(PlayerDistance>ChaseRange)
		{
			animation.CrossFade("Alert", 0.5f);
			Vector3 target = Waypoints[currentWaypoint].position;
			Vector3 moveDirection = target - transform.position;
			Vector3 velocity = rigidbody.velocity; 
			
			if (pauseDuration <= 0.0f)
			{
				pauseDuration = 40.0f;
				currentWaypoint=Random.Range(0,Waypoints.Length);
			}   
			
			if(moveDirection.magnitude < 2.0f)
			{
				pauseDuration -= 0.1f;
				animation.CrossFade("Take 001", 0.1f);
			}
			else
			{
				velocity = moveDirection.normalized*Speed;
				DurEnemy.destination = Waypoints[currentWaypoint].position;
			}
		}
	}
}
