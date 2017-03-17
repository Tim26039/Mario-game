using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Mario : MonoBehaviour
{
	// hier maak ik alle variabelen aan
    float snelheid;
	float springen;
	float Leven;
	public int score;
	public Texture[] frames; 
	public GameObject Goomba;
	public GameObject steen;
	public GameObject munt;
	public GameObject Power_Up;
	public GameObject Buis_Heen;
	public GameObject BuisTerug;
	GameObject kloon;
	bool Buis;
	bool PAUZE;
	bool PAUZEN;
	Vector3 vraagteken;
	public GUISkin tekstSkin;
	public GUISkin tekstSkinPauze;
	public AudioClip Munt_Sound;
	public AudioClip Musthroom;
	public AudioClip Dood;
	private AudioSource soundeffect;

	// Use this for initialization
	void Start () 
	{
		snelheid = 4;
		springen = 8;
		print ("BOEM");
		Buis = false;
		score = 000000;
		Leven = 3;
		PAUZE = false;
		PAUZEN = false;
		PlayerPrefs.SetInt ("score", score);
		soundeffect = GetComponent<AudioSource>();
	}

	void vijand()
	{
			transform.position = new Vector3 (0, -0.37f, 0);
			Leven -= 1;
			GetComponent<AudioSource> ().clip = Dood;
			GetComponent<AudioSource> ().Play ();
	}

	void munt_functie()
	{
		score += 000100;
		//speel munt geluid af
		//GetComponent<AudioSource>().clip = Munt_Sound;
		//GetComponent<AudioSource>().Play();
		soundeffect.PlayOneShot (Munt_Sound, 0.8f);
	}

	void Pauzen()
	{
		GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY;
	}
	
	// Update is called once per frame
	void Update ()
	{
		// als pauze fals is
		if (PAUZE == false) 
		{
			// speler laten lopen
			transform.Translate (Input.GetAxis ("Hor") * snelheid * Time.deltaTime, 0, 0);

			if (Input.GetKeyDown (KeyCode.RightArrow))
			{
				GetComponent<Renderer> ().material.mainTexture = frames [0];
			}

			if (Input.GetKeyDown (KeyCode.LeftArrow)) 
			{
				GetComponent<Renderer> ().material.mainTexture = frames [1];
			}

			if (Input.GetKeyDown (KeyCode.DownArrow) && Buis == true)
			{
				transform.position = new Vector3 (-20.14f, -67.07f, 0);
				Buis = false;
			}
				
			GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
			GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
		}

		// als pauze true is
		if (PAUZE == true)
		{
			// freeze de positie van de speler
			Pauzen();
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

		// als levens 0 zijn naar game over scherm
		if (Leven == 0)
		{
			SceneManager.LoadScene ("GameOver");
		}

		PlayerPrefs.SetInt ("score", score);
	}



	void OnTriggerEnter(Collider other)
	{
		// als die in een trigger event heeft met tag vraag teken
		if (other.gameObject.tag == "vraagteken")
		{
			munt_functie ();

			// verplaats object steen en zet het neer op de plek van het vraagteken
			Instantiate(steen, other.gameObject.transform.position, Quaternion.identity);

			//zeg dat het gameobject kloon munt is en verplaatrs het na de plek waar het vraagteken stond
			kloon = (GameObject)Instantiate(munt, other.gameObject.transform.position, Quaternion.identity);
			Destroy (other.gameObject);

			// verander de tijd van het gamobject kloon na 0
			kloon.GetComponent<Munt> ().tijd = 0;

		}


		// als je de buis aanraakt
		if (other.gameObject == Buis_Heen) 
		{
			Buis = true;
		} 

		else
		{
			Buis = false;
		}


		// als je de buis in het bonus level aanraakt
		if (other.gameObject == BuisTerug)
		{
			transform.position = new Vector3 (38.53f, 3.22f, 0 );
		}
			

		// als je tag blokpowerup aanraakt laat dan power up spawnen
		if (other.gameObject.tag == "blokpowerup")
		{
			Instantiate(steen, other.gameObject.transform.position, Quaternion.identity);
			kloon = (GameObject)Instantiate(Power_Up, other.gameObject.transform.position, Quaternion.identity);
			Destroy (other.gameObject);
		}

		// als je munt aanraakt
		if (other.gameObject.tag == "Munten")
		{
			munt_functie ();
			Destroy (other.gameObject);
		}

		// als jij op de vijand springt
		if (other.gameObject.tag == "enemy") 
		{
			GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0.6f * springen, 0);
			Destroy (other.gameObject);
		}

		// als je de afgrond in valt
		if (other.gameObject.tag == "Muur")
		{
			vijand ();
		}
	}

	void OnCollisionEnter(Collision Botsing)
	{
		// als de vijand jou aanraakt
		if (Botsing.gameObject.tag == "enemy")
		{
			// als je scale 1 is
			if (transform.localScale.y == 1) 
			{
				vijand ();
			}

			else
			{
				transform.localScale = new Vector3 (1, 1, 1);
				Destroy (Botsing.gameObject);
			}
		}

		// als je de power up oppakt
		if (Botsing.gameObject.tag == "powerup")
		{
			Destroy (Botsing.gameObject);
			transform.localScale = new Vector3 (1.1f, 1.4f, 1);
			GetComponent<AudioSource>().clip = Musthroom;
			GetComponent<AudioSource>().Play();
		}

		// als je tegen de paal aanspringt
		if (Botsing.gameObject.name == "Paal") 
		{
			PlayerPrefs.SetInt ("score", score);
			SceneManager.LoadScene ("WinnaarsScherm");
		}
	}

	void OnGUI()
	{
		GUI.skin = tekstSkin;

		// staandaart text in game
		GUI.Label (new Rect (185, 10, 300, 100), "Mario");
		GUI.Label (new Rect (200, 30, 300, 100), "" + score);
		GUI.Label (new Rect (330, 10, 300, 100), "World");
		GUI.Label (new Rect (345, 30, 300, 100), "1-1");
		GUI.Label (new Rect (490, 10, 300, 100), "Life");
		GUI.Label (new Rect (520, 30, 300, 100), "" + Leven);

		// als je game op pauze staat
		if (PAUZE == true) 
		{
			GUI.skin = tekstSkinPauze;
			GUI.Label (new Rect (185, 50, 300, 100), "Pauze");
			GUI.Label(new Rect (5, 100, 900, 100),  "Het doel is om het einde van");
			GUI.Label(new Rect (5, 150, 750, 100),  " van het level te halen");
			GUI.Label (new Rect (-120, 200, 900, 100), "je loopt met de pijltjes");
			GUI.Label (new Rect (-180, 250, 900, 100), "en springt met spatie");
		}
	}

	void OnCollisionStay ()
	{
		// als je op spatie drukt
		if (Input.GetKeyDown (KeyCode.Space))
		{
				GetComponent<Rigidbody> ().velocity = new Vector3 (0, Input.GetAxis ("Jump") * springen, 0);
		} 
	}
}
	
