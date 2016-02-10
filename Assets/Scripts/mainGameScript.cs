using UnityEngine;
using System.Collections;

public class mainGameScript : MonoBehaviour 
{
	public static bool seated = false;
	public Transform FPController;
	public Transform OVRController;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		Debug.Log (OVRDevice.IsHMDPresent());

		/*
		if(Input.GetMouseButton(1)) 
		{
			seated = !seated;
			FPController.GetComponent<CharacterController>().enabled = false;

*/

		if (seated) {
			FPController.GetComponent<CharacterController>().enabled = false;	
		}


		if (!OVRDevice.IsHMDPresent ()) 
		{
			FPController.gameObject.SetActive (true);
			OVRController.gameObject.SetActive (false);
		} 
		else 
		{

		}
	}
}
