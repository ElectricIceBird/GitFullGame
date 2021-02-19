using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2D : MonoBehaviour
{
    public float moveSpeed;
    public float Jumpfocre;
    public bool isGrounded;
    private float jumpCount;
    public SpriteRenderer sr;
    private float moveInput;
    public int jumpExtravalue;
    private bool isFacingRight = true;
    public GameObject player;
    public GameObject player2;
    public Animator anim;

    


    // Start is called before the first frame update
    void Start()
    {
        jumpCount = jumpExtravalue; 
    }

    // Update is called once per frame
    void Update()
    {
        
    
    Jump();
        moveInput = Input.GetAxisRaw("Horizontal");
        Vector3 movement = new Vector3(moveInput,0f,0f);
        transform.position += movement * Time.deltaTime * moveSpeed;
        if(moveInput >0 && isFacingRight == false){
            Flip();
        }
        else if (moveInput <0 && isFacingRight == true)
        {
            Flip();
        }
    }
    void Jump()
    {
        if (isGrounded == true)
        {
            jumpCount = jumpExtravalue;
        }
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount > 0)
    {
            anim.SetTrigger("Jump");
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, Jumpfocre), ForceMode2D.Impulse);
            jumpCount--;
    }
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount == 0 && isGrounded == true)
        {
            anim.SetTrigger("Jump");

            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, Jumpfocre), ForceMode2D.Impulse);
            
        }
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            

            player.GetComponent<Move2D>().enabled = false;
            player2.GetComponent<Move2D>().enabled = true;
        }
    }
    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
  
}
