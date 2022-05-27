using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;
	public Animator animator;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;


	// Update is called once per frame
	void Update () {

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
			animator.SetFloat("isJump", 1f);
		}

		if (Input.GetButtonDown("Fire1")) {
			animator.SetBool("isAttack", true);
		}

		if (horizontalMove > 0) {
			animator.SetBool("isAttack", false);
		}
	}

	public void OnLanding ()
	{
		animator.SetFloat("isJump", 0f);
	}


	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
		jump = false;
		animator.SetBool("isAttack", false);
	}
}