using UnityEngine;
using System.Collections;

public class VelocityMovement : MonoBehaviour 
{
	float maxVel = 10.0f;
	float speed = 10.0f;
	float walkBackSpeed = 5.0f;
	bool isJumping = false;
	bool doubleJump = false;

	public bool grounded = true;
	public bool switched;
	public int switchControls = 1;
	public static VelocityMovement main;

	int jumpHeight = 250;
	float moveSpeed = 1.0f;
	float runSpeed = 2.0f;
	
	// Use this for initialization
	void Start () 
	{
		main = this;
	}

	void Awake()
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		if(mainGameScript.seated)
		{
			float fowardVel=0.0f;

			animation.CrossFade("Idle", 0.5f);

			if (Input.GetKey ("w"))
			{
				fowardVel = moveSpeed;
				animation.CrossFade("Walk", 0.5f);
			}
				
			if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey ("w"))
			{
				fowardVel = runSpeed;
				animation.CrossFade("Run", 0.5f);
			}

			if (Input.GetKey ("s"))
			{
				fowardVel = -moveSpeed;
				animation.CrossFade("Walk", 0.5f);
			}

			if (Input.GetKey ("a"))
			{
				transform.Rotate(0,-2,0);
			}

			if (Input.GetKey ("d"))
			{
				transform.Rotate (0,2,0);	
			}

			if (Input.GetKey ("q"))
			{
				transform.Translate(-0.1f,0,0);
				animation.CrossFade("MoveLeft", 0.5f);
			}

			if (Input.GetKey ("e"))
			{
				transform.Translate(0.1f,0,0);
				animation.CrossFade("MoveRight", 0.5f);
			}
			// Calculate how fast we should be moving
			Vector3 targetVelocity = new Vector3(0, 0, fowardVel);
			targetVelocity = transform.TransformDirection(targetVelocity);
			targetVelocity *= speed;
		 
			// Apply a force that attempts to reach our target velocity
			Vector3 velocity = rigidbody.velocity;
			Vector3 velocityChange = (targetVelocity - velocity);
			velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVel, maxVel);
			velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVel, maxVel);
			velocityChange.y = 0;
			rigidbody.AddForce(velocityChange, ForceMode.VelocityChange);
			
			if (isJumping == false && Input.GetKeyDown("f"))
			{
				rigidbody.AddForce(new Vector3(0,jumpHeight,0));
				isJumping = true;
				doubleJump = true;
				grounded = false;
			}
		}
	}
	
	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.name == "Terrain")
		{
			isJumping = false;
			doubleJump = false;
			grounded = true;
			Debug.Log("jumping is now: " + isJumping);
		}
	}
}
