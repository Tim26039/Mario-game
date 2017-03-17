using UnityEngine;
using System.Collections;

public class Vijand : MonoBehaviour 
{
	public float snelheid;
	bool draaien;
	public Texture[] frames; 
	bool PAUZE;
	bool PAUZEN;

	// Use this for initialization
	void Start ()
	{
		draaien = false;
		PAUZE = false;
		PAUZEN = false;
		snelheid = 0.06f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		// als pauze fals is
		if (PAUZE == false) 
		{
			// als draaien false is
			if (draaien == false) 
			{
				transform.Translate (snelheid, 0, 0);

				// als draaien true is
				if (transform.position.x > 25)
				{
					draaien = true;
					GetComponent<Renderer> ().material.mainTexture = frames [1];
				}
			}

			if (draaien == true)
			{
				transform.Translate (-snelheid, 0, 0);

				if (transform.position.x < 13) 
				{
					draaien = false;
					GetComponent<Renderer> ().material.mainTexture = frames [0];
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
