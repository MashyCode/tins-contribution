using UnityEngine;
using System.Collections;

public class RotateSkybox : MonoBehaviour 
{
	private float rotation = 0.1f;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Rotate(0, 0, rotation);
	}
}
