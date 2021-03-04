using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public string Left;
    public Rigidbody2D rb;
    public Animator animator;
    Vector2 movement;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        //input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    private void Update()
    {
        //physcis
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        if(Input.GetKey(KeyCode.A))
        {
            anim.SetBool("Left", true);
        }

        if(Input.GetKey(KeyCode.D))
        {
            anim.SetBool("Left", false);
        }
    }
}
