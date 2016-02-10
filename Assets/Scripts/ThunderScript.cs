using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class ThunderScript : MonoBehaviour {

	// Ok, so this script should work now..attaching it to the main light didn't seem to work with the audio...
	// don't know why
	public Light thunderLight;
	public bool isLightOn = false;
	public AudioClip thunderSound;

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
				thunderLight.enabled = true;
				audio.PlayOneShot(thunderSound, 0.7f);
				thunderLight.intensity = 2;

			}

			else if(chance > 2)
			{
				thunderLight.enabled = false;
			}
		}

	}
}
