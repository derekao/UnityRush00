using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartGame()
	{
		GameObject.Find ("Menu").SetActive(false);
	}

	public void QuitGame()
	{
		Application.Quit ();
	}
}
