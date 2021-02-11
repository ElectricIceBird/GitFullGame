using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : MonoBehaviour
{
    public Animator anim;
    public float speed;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump")) 
        {
            
            anim.SetTrigger("Walking");
        }
    }
    public void Move() 
    {
        rb.velocity = new Vector3(0, 0, 10);
        
    }
}
