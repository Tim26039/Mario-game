using UnityEngine;
using System.Collections;

public class Munt : MonoBehaviour 
{
	float snelheid;
	public float tijd;

	// Use this for initialization
	void Start ()
	{
		snelheid = 0.05f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		tijd += Time.deltaTime;
		transform.Translate (0, snelheid, 0);

		// als tijd groter is dan 0.5 en kleiner dan 10
		if (tijd > 0.5f && tijd < 10)
		{
			Destroy (this.gameObject);
		}
	}
}
