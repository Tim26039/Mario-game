using UnityEngine;
using System.Collections;

public class Power_Up : MonoBehaviour 
{
	public float snelheid;
	float hoogte;
	bool PAUZE;
	bool PAUZEN;


	// Use this for initialization
	void Start ()
	{
		snelheid = 0.02f;
		hoogte = 0.08f;
		PAUZE = false;
		PAUZEN = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//  als pauze false is
		if (PAUZE == false) 
		{
			transform.Translate (snelheid, hoogte, 0);
		}

		// als je p indrukt
		if (Input.GetKeyDown (KeyCode.P)) 
		{
			if (PAUZE == false)
			{
				PAUZEN = true;
			}

			if (PAUZE == true)
			{
				PAUZE = false;
			}

			if (PAUZEN == true)
			{
				PAUZE = true;
				PAUZEN = false;
			}
		}
	}

	void OnCollisionEnter(Collision Botsing)
	{
		//  als die ontrigger event heeft met tag rest
		if (Botsing.gameObject.tag == "Rest") 
			{
				print ("BOEMBS");
				snelheid = -1 * snelheid;
			}

			hoogte = 0;
	}
}
