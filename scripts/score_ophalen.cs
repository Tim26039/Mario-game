using UnityEngine;
using System.Collections;

public class score_ophalen : MonoBehaviour 
{
	public int score;
	public GUISkin tekstSkin;

	// Use this for initialization
	void Start () 
	{
		score = PlayerPrefs.GetInt ("score");
	}
	
	// Update is called once per frame
	void Update () 
	{
	}

	void OnGUI()
	{
		GUI.skin = tekstSkin;
		
		GUI.Label (new Rect (260, 300, 900, 100), "Score:" + score);
	}
}
