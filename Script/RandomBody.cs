using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBody : MonoBehaviour {


	public Sprite[] BodyTexture;


	// Use this for initialization
	void Start () 
	{
		SpriteRenderer Texture = GetComponent<SpriteRenderer>();
		Texture.sprite = BodyTexture[Random.Range (0, BodyTexture.Length)];
	}
}
