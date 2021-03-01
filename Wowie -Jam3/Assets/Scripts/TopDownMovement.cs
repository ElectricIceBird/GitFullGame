using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    public float Movespeed;
    public Rigidbody2D rb;
    private Vector2 moveDirection;
    public Animator anim;
    private Vector2 moveVeco;
    




    // Update is called once per frame
    void Update()
    {
        //Input
        Vector2 moveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVeco = moveDirection.normalized * Movespeed;

        if (moveVeco != Vector2.zero)
        {
            
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }


    }
    private void FixedUpdate()
    {
        //Physics Cal
        rb.MovePosition(rb.position + moveVeco * Time.fixedDeltaTime);
      



    }
   
}
