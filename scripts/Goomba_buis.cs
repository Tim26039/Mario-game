using UnityEngine;
using System.Collections;

public class Goomba_buis : MonoBehaviour
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
		// als pauze false is
		if (PAUZE == false)
		{
			if (draaien == false) 
			{
				transform.Translate (snelheid, 0, 0);
				GetComponent<Renderer> ().material.mainTexture = frames [0];
			}

			if (draaien == true) 
			{
				transform.Translate (-snelheid, 0, 0);
				GetComponent<Renderer> ().material.mainTexture = frames [1];
			}
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


	void OnCollisionEnter(Collision other)
	{
		// als die trigger event heb met tag rest
		if (other.gameObject.tag == "Rest") 
		{
			if (draaien == true) 
			{
				draaien = false;
			}

			else
			{
				draaien = true;
			}
		}
	}
}
