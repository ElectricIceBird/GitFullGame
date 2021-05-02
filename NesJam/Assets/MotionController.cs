using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MotionController : MonoBehaviour
{
    public float speed;
    private move input;
    private bool facingRight = true;
    public float maxHeight;
    public float minHeight;

    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<move>();
        
    }

    // Update is called once per frame
    void Update()
    {
       var positon =  this.transform.position +=( input.vertical * Time.deltaTime * speed * Vector3.up);
        positon.y = Mathf.Clamp(positon.y,minHeight, maxHeight);
        this.transform.position = positon;
        this.transform.position += input.horizonntal * Time.deltaTime * speed * Vector3.right;
        if(facingRight == true && input.horizonntal < 0)
        {
            flip();
        }
        else if(facingRight == false && input.horizonntal > 0)
       {
            flip();
        }

    }
    void flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
    
