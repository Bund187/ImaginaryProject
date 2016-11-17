﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	private bool facingRight;
	public bool canMove;

	private bool isMovingL=true, isMovingR = true, isMovingU = true, isMovingD = true;
	private Animator anim;
	private SpriteRenderer spriteRend;

	void Start() {
		//facingRight = true;
		anim = GetComponent<Animator>();
		canMove = true;
		spriteRend = GetComponent<SpriteRenderer> ();
	}

	void FixedUpdate(){
		//float xMove = Input.GetAxisRaw("Horizontal");

		if (!canMove)   
		{
			moveSpeed = 0;
			return;
		}
		Move();
		//Flip(xMove);


	}

	void Move() {
		this.moveSpeed = 1;
		float xMove = Input.GetAxisRaw("Horizontal");
		float yMove = Input.GetAxisRaw("Vertical");

		if ((xMove > 0f || xMove < 0f) || (yMove > 0f || yMove < 0f)) { 
			if (isMovingR)
			{
				if (xMove > 0f)
				{
					spriteRend.flipX = false;
					anim.SetBool("RunRight", true);
					anim.SetBool("RunDown", false);
					anim.SetBool("RunUp", false);
					moveSpeed = 1;
					transform.Translate(new Vector3(xMove * moveSpeed * Time.deltaTime, 0f, 0f));

				}
			}
			if (isMovingL)
			{
				if (xMove < 0f)
				{
					spriteRend.flipX = true;
					anim.SetBool("RunLeft", true);
					anim.SetBool("RunDown", false);
					anim.SetBool("RunRight", false);
					anim.SetBool("RunUp", false);
					moveSpeed = 1;
					transform.Translate(new Vector3(xMove * moveSpeed * Time.deltaTime, 0f, 0f));
				}
			}
			if (isMovingU)
			{
				if (yMove > 0f)
				{
					anim.SetBool("RunUp", true);
					anim.SetBool("RunDown", false);
					anim.SetBool("RunLeft", false);
					anim.SetBool("RunRight", false);
					moveSpeed = 1;
					transform.Translate(new Vector3(0f, yMove * moveSpeed * Time.deltaTime, 0f));

				}
			}
			if (isMovingD)
			{
				if (yMove < 0f)
				{
					anim.SetBool("RunDown", true);
					anim.SetBool("RunUp", false);
					anim.SetBool("RunLeft", false);
					anim.SetBool("RunRight", false);
					moveSpeed = 1;
					transform.Translate(new Vector3(0f, yMove * moveSpeed * Time.deltaTime, 0f));
				}

			}

		}else{
			moveSpeed = 0;
			anim.SetBool("RunLeft", false);
			anim.SetBool("RunDown", false);
			anim.SetBool("RunRight", false);
			anim.SetBool("RunUp", false);
		}



	}

	/*public void Flip(float xMove)
	{
		if (isMovingL || isMovingR) {
			if (xMove > 0 && !facingRight || xMove < 0 && facingRight) {
				facingRight = !facingRight;
				Vector3 theScale = transform.localScale;
				theScale.x *= -1;
				transform.localScale = theScale;
			}
		}
	}*/


	public bool IsMovingR
	{
		get
		{
			return isMovingR;
		}

		set
		{
			isMovingR = value;
		}
	}

	public bool IsMovingL
	{
		get
		{
			return isMovingL;
		}

		set
		{
			isMovingL = value;
		}
	}

	public bool IsMovingU
	{
		get
		{
			return isMovingU;
		}

		set
		{
			isMovingU = value;
		}
	}

	public bool IsMovingD
	{
		get
		{
			return isMovingD;
		}

		set
		{
			isMovingD = value;
		}
	}

}