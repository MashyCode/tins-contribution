using UnityEngine;
using System.Collections;

public class ThunderScript : MonoBehaviour {

	public GameObject thunderLight;
	public bool isLightOn = false;
	public GameObject thunderSound;

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {

		if (isLightOn == false) 
		{
			float chance = Random.Range(0, 2000);

			if(chance < 2)
			{
				thunderLight.SetActive(true);
				thunderSound.audio.Play();
			}

			else 
			{
				thunderLight.SetActive(false);
			}
		}

	}
}
