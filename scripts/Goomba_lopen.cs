﻿using UnityEngine;
using System.Collections;

public class Goomba_lopen : MonoBehaviour 
{
	float snelheid;
	public GameObject mario; 
	bool PAUZE;
	bool PAUZEN;

	// Use this for initialization
	void Start () 
	{
		snelheid = 0;
		PAUZE = false;
		PAUZEN = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		// als pauze false is
		if (PAUZE == false) 
		{
			if (mario.transform.position.x > 45) 
			{
				snelheid = 0.06f;
			}

			transform.Translate (-snelheid, 0, 0);
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
}
