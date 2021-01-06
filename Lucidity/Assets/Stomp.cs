using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stomp : MonoBehaviour
{
    
    public float force;
    public bool stomped= false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Rigidbody2D playerRb = other.GetComponent<Rigidbody2D>();
            playerRb.AddForce(Vector2.up * force);
            stomped = true;
            BoxCollider2D BoxCollider = transform.parent.gameObject.GetComponent<BoxCollider2D>();
            BoxCollider.enabled = false;        }
    }
    void OnbecomeInvisible()
    {
        Destroy(transform.parent.gameObject);
    }
}
