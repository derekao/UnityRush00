using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponParam : MonoBehaviour {

	public int nbWeapon;

	public Sprite[] Image;
	public Sprite[] Attach;
	public Sprite[] Bullet;
	public int[] MaxAmmo;
	public bool[] bMelee;
	public float[] FireRate;
	public float[] FireSpeed;

	public static WeaponParam instance { get; private set; }

	// Use this for initialization
	void Awake () 
	{
		instance = this;
	}
}
