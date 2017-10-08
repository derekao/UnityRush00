using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngameUI : MonoBehaviour {

	public PlayerManager player;

	private Text Ammo;
	private Text Weapon;

	// Use this for initialization
	void Start () 
	{
		Weapon = transform.Find("WeaponName").GetComponent<Text> ();
		Ammo = transform.Find("AmmoLeft").GetComponent<Text> ();
	}

	// Update is called once per frame
	void Update () 
	{
		if (player.PlayerWeapon)
		{
			Weapon.text = player.PlayerWeapon.Image.name;
			Ammo.text = player.PlayerWeapon.CurrentAmmo.ToString();
		} 
		else
		{
			Weapon.text = "No Weapon";
			Ammo.text = "-";
		}
	}
}
