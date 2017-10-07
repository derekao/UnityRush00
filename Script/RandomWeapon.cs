using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWeapon : MonoBehaviour {

	public Weapon weapon;
	public int nbWeapon;

	public Sprite[] Image;
	public Sprite[] Attach;
	public Sprite[] Bullet;
	public int[] MaxAmmo;
	public bool[] bMelee;
	public float[] FireRate;
	public float[] FireSpeed;

	// Use this for initialization
	void Start () 
	{
		int rd = Random.Range(0, nbWeapon);
		Instantiate (weapon, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
		weapon.Image = Image[rd];
		weapon.Attach = Attach[rd];
		weapon.Bullet = Bullet[rd];
		weapon.MaxAmmo = MaxAmmo[rd];
		weapon.CurrentAmmo = MaxAmmo[rd];
		weapon.bMelee = bMelee[rd];
		weapon.FireRate = FireRate[rd];
		weapon.FireSpeed = FireSpeed[rd];
		GameObject.Destroy (this.gameObject);
	}
}
