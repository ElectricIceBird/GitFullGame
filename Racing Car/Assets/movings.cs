using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movings : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("up"))
        {
            rb.velocity = new Vector3(Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime,0,0);
        }
        if(Input.GetKeyDown("left"))
        {
            rb.AddForce(100,0,0);
        }
        if(Input.GetKeyDown("right"))
        {
            rb.AddForce(-100,0,0);
        }
        
    }
}
