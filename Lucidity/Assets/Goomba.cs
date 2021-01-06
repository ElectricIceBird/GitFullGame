using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goomba : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    bool facingLeft; 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
      transform.Translate(Vector2.left * speed * Time.deltaTime);  
    }
    public void OnCollisionEnter2D(Collision2D other) {
        if(other != null && !other.collider.CompareTag("Player") && other.collider.CompareTag("Ground"))
        {
            facingLeft = !facingLeft;
        }
        if(facingLeft )
        {
            gameObject.transform.rotation = Quaternion.Euler(0,0,0);
            Debug.Log("B");
        }else
        {
            gameObject.transform.rotation = Quaternion.Euler(0,180,0);

        }
    }
}
