using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class scene_mangemant : MonoBehaviour 
{
	private Ray ray;
	private RaycastHit ryacastHit;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		// als je de muis button left indrukt
		if (Input.GetMouseButtonDown (0))
		{
			ray = Camera.main.ScreenPointToRay (Input.mousePosition);

			if (Physics.Raycast (ray, out ryacastHit)) 
			{
				if (ryacastHit.transform.name == "Spelen")
				{
					SceneManager.LoadScene ("Level1");
				}

				if (ryacastHit.transform.name == "Menu")
				{
					SceneManager.LoadScene ("startscherm");
				}

				if (ryacastHit.transform.name == "Spelregels")
				{
					SceneManager.LoadScene ("SpelRegels");
				}
			}
		}
	
	}
}
