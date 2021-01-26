using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorArrow : MonoBehaviour
{
    public float pushfoce;
    Vector2 push;
    Vector2 pushamount;

    public Rigidbody2D playerRb;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0.0f, -2.0f, 0.0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Working");


            playerRb.AddForce(transform.right * pushfoce);
        }
    }
}
