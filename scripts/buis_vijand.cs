using UnityEngine;
using System.Collections;

public class buis_vijand : MonoBehaviour
{
	public float snelheid;
	bool draaien;
	bool PAUZE;
	bool PAUZEN;

	// Use this for initialization
	void Start () 
	{
		draaien = false;
		PAUZE = false;
		PAUZEN = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		// als pauze fals is
		if (PAUZE == false)
		{
			if (draaien == false) 
			{
				transform.Translate (0, snelheid, 0);
				if (transform.position.y > 1.8f) 
				{
					draaien = true;
				}
			}

			// als pauze true is
			if (draaien == true) 
			{
				transform.Translate (0, -snelheid, 0);

				if (transform.position.y < -1.2f) 
				{
					draaien = false;
				}
			}
		}

		// als je op p drukt
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
}
