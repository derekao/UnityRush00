using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

	public Weapon PlayerWeapon;
	public float fSpeed;

	private Rigidbody2D RbPlayer;
	private Animator 	AnimPlayer;

	private Weapon CloseWeapon = null;


	// Use this for initialization
	void Start () 
	{
		RbPlayer = GetComponent<Rigidbody2D> ();
		AnimPlayer = GetComponentInChildren<Animator>();
	}

	//Trigger
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Weapon")
		{
			CloseWeapon = other.GetComponent<Weapon> ();
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Weapon")
		{
			CloseWeapon = null;
		}
	}

	// Update is called once per frame
	void Update () 
	{
		MovementInput ();
		ActionInput ();
	}

	/*Action*/	
	void ActionInput()
	{
		if (Input.GetMouseButtonDown (0) && PlayerWeapon)
		{
			PlayerWeapon.fire ();
		}
		else if (Input.GetKeyDown (KeyCode.E) && CloseWeapon && !PlayerWeapon)
		{
			PlayerWeapon = CloseWeapon;

			PlayerWeapon.transform.SetParent (this.transform);
			SpriteRenderer Texture = PlayerWeapon.GetComponent<SpriteRenderer> ();
			Texture.sortingOrder = 4;
			Texture.sprite = PlayerWeapon.Attach;
			PlayerWeapon.transform.localPosition = new Vector3 (-0.06999993f, -0.26f, 0);
			PlayerWeapon.transform.rotation = transform.rotation;
			CloseWeapon = null;
		}
		else if (Input.GetKeyDown (KeyCode.Q) && PlayerWeapon)
		{
			PlayerWeapon.transform.parent = null;
			SpriteRenderer Texture = PlayerWeapon.GetComponent<SpriteRenderer> ();
			Texture.sortingOrder = 0;
			Texture.sprite = PlayerWeapon.Image;

			Animator 	AnimWeapon;
			AnimWeapon = PlayerWeapon.GetComponentInChildren<Animator>();
			AnimWeapon.SetBool("Throwing", true);

			PlayerWeapon.Direction = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			PlayerWeapon.Direction.z = 0;
			PlayerWeapon.step = Vector3.Distance (PlayerWeapon.Direction, transform.position);
			PlayerWeapon.bThrown = true;

			Collider2D tmp = PlayerWeapon.GetComponent<Collider2D> ();
			tmp.isTrigger = false;

			PlayerWeapon = null;

		}
	}


	/* Movement */
	void SetWalking(bool bWalk)
	{
		if (AnimPlayer.GetBool("Walk")!= bWalk)
			AnimPlayer.SetBool("Walk", bWalk);
	}

	void SetVelocity(string sz, float speed)
	{
		if (sz == "x")
		{
			if (RbPlayer.velocity.x != speed)
				RbPlayer.velocity = new Vector3 (speed, RbPlayer.velocity.y, 0);
		} 
		else if (sz == "y")
		{
			if (RbPlayer.velocity.y != speed)
				RbPlayer.velocity = new Vector3 (RbPlayer.velocity.x, speed, 0);
		}
		else
			Debug.Log ("Error in SetVelocity");
	}

	void MovementInput()
	{
		Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		diff.Normalize();

		float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f, 0f, rot_z + 90);


		if (Input.GetKey (KeyCode.W))
		{
			SetVelocity ("y", fSpeed);
			SetWalking (true);
		}
		else if (Input.GetKey (KeyCode.S))
		{
			SetVelocity ("y", -fSpeed);
			SetWalking (true);
		}
		else
		{
			SetVelocity ("y", 0);
			SetWalking (false);
		}
		if (Input.GetKey (KeyCode.A))
		{
			SetVelocity ("x", -fSpeed);
			SetWalking (true);
		} 
		else if (Input.GetKey (KeyCode.D))
		{
			SetVelocity ("x", fSpeed);
			SetWalking (true);
		} 
		else
		{
			SetVelocity ("x", 0);
			SetWalking (false);
		}
	}
}
