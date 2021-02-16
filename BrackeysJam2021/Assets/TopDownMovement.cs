using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    private Vector2 moveVelocity;
    public GameObject secondPlayer;
     public GameObject player;
    public GameObject Combineform;
    

    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;
        if (Input.GetKeyDown(KeyCode.Space))        
        {
            secondPlayer.GetComponent<TopDownMovement>().enabled = true;
            player.GetComponent<TopDownMovement>().enabled = false;
        }


    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pad"))
        {
            player.GetComponent<SpriteRenderer>().enabled = false;

            secondPlayer.GetComponent<TopDownMovement>().enabled = true;

            player.GetComponent<TopDownMovement>().enabled = false;
            



        }
    }
}
