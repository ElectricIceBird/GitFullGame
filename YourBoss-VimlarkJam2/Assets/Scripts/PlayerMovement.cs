using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator anim;
    public float speed;
    private Rigidbody2D rb;
    Vector2 movement;
    Vector2 positionstart;
    // Start is called before the first frame update
    void Start()
    {
        positionstart = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

       movement.x =  Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        anim.SetFloat("New Float",movement.x);
        anim.SetFloat("floaty",movement.y);



    }
    private void FixedUpdate()
    {
       
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            transform.position = positionstart;   
        }
    }
}
