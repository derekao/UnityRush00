using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour 
{
	public Shot shot;

	[HideInInspector] public Sprite Image;
	[HideInInspector] public Sprite Attach;
	[HideInInspector] public Sprite Bullet;
	[HideInInspector] public int MaxAmmo;
	[HideInInspector] public int CurrentAmmo;
	[HideInInspector] public bool bMelee;
	[HideInInspector] public float FireRate;
	[HideInInspector] public float FireSpeed;

	[HideInInspector] public bool bThrown;
	[HideInInspector] public Vector3 Direction;
	[HideInInspector] public float step;

	private bool bFirstUpdate = false;
	private SpriteRenderer Texture;


	// Use this for initialization
	void Start () 
	{
		Texture = GetComponent<SpriteRenderer>();
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "wall")
		{
			Animator AnimWeapon;
			AnimWeapon = GetComponentInChildren<Animator> ();
			AnimWeapon.SetBool ("Throwing", false);

			Collider2D tmp = GetComponent<Collider2D> ();
			tmp.isTrigger = true;
			bThrown = false;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!bFirstUpdate)
		{
			bFirstUpdate = true;
			Texture.sprite = Image;
		}

		if (bThrown)
		{
			transform.position = Vector3.MoveTowards(transform.position, Direction, step * Time.deltaTime * 1f);
			if (transform.position == Direction)
			{
				Animator 	AnimWeapon;
				AnimWeapon = GetComponentInChildren<Animator>();
				AnimWeapon.SetBool("Throwing", false);

				Collider2D tmp = GetComponent<Collider2D> ();
				tmp.isTrigger = true;
				bThrown = false;
			}
		}
	}


	public void fire()
	{
		Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		diff.Normalize();

		SpriteRenderer TextureShot = shot.GetComponent<SpriteRenderer>();
		TextureShot.sprite = Bullet;

		float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
		Quaternion tmp = Quaternion.Euler(0f, 0f, rot_z);

		Shot go =  GameObject.Instantiate (shot,  new Vector3(transform.position.x +  2 * diff.x, transform.position.y+ 2 * diff.y, 0), tmp);

		Rigidbody2D rb = go.GetComponent<Rigidbody2D>();
		Debug.Log (FireSpeed);
		rb.velocity = new Vector3 (diff.x,diff.y,0) * FireSpeed;
	}

}