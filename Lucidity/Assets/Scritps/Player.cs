using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   public ParticleSystem dusting;  // Start is called before the first frame update

    public float fallMultiplier = 2.5f; 
public float lowJumpMultiplier = 2f;
    public float speed;
    private Rigidbody2D rb;
    public float jumpForce;
    public bool isGrounded = false; 
public Transform isGroundedChecker; 
public float checkGroundRadius; 
public LayerMask groundLayer;
    public float rememberGroundedFor; 
float lastTimeGrounded;
public int defaultAdditionalJumps = 1; 
int additionalJumps;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       
        
    }

    // Update is called once per frame
    void Update()
    {
        
      CheckIfGrounded();
      Move();  
      Jump();
    BetterJump();
    }
    public void Move()
    {
         float x = Input.GetAxisRaw("Horizontal");
         CreateDust();
         float moveBy = x * speed; 
        rb.velocity = new Vector2(moveBy, rb.velocity.y); 
    }
     public void Jump()
    {
          if (Input.GetKeyDown(KeyCode.Space) && (isGrounded || Time.time - lastTimeGrounded <= rememberGroundedFor || additionalJumps > 0)) 
          {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        additionalJumps--;
    }

    }
   public void CheckIfGrounded() { 
       Collider2D colliders = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, groundLayer);
    if (colliders != null) {
        isGrounded = true;
        additionalJumps = defaultAdditionalJumps;
    } else {
        if (isGrounded) {
            lastTimeGrounded = Time.time;
        }
        isGrounded = false;
    } 
    }
   public  void BetterJump() {
    if (rb.velocity.y < 0) {
        rb.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
    } else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space)) {
        rb.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
    }
    
    
}
 void CreateDust()
    {
        dusting.Play();
    }
}