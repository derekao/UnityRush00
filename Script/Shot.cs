using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour {


	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "wall")
		{
			//TODO
		}
		else if (collision.gameObject.tag == "enemy")
		{
			//TODO
		}
		else if (collision.gameObject.tag == "Player")
		{
			//TODO
		}
		else if (collision.gameObject.tag == "door")
		{
			//TODO
		}
		else
		{
			return;
		}
		GameObject.Destroy (this.gameObject);
	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
