using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;
    public float runSpeed = 40;
    float horizontalMove = 0f;
    bool jump = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        
        if (Input.GetButtonDown("Jump")) {
            jump = true;    
            animator.SetBool("isJump", true);
        }

        // Work on Attack

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
    }

    void FixedUpdate() 
    {
        controller.Move(horizontalMove * Time.deltaTime, false, jump);
        jump = false;
    }

    public void OnLanding() {
        animator.SetBool("isJump", false);
    }
}
