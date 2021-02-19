using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public int speed;
    public Vector2 target;


    void Start()
    {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    }

    // Update is called once per frame
    void Update()
    {
       transform.position = Vector2.MoveTowards(transform.position,target,speed* Time.deltaTime);
        if(Vector2.Distance(transform.position,target) < 0.2f)
        {
            Destroy(this.gameObject);
        }

    }
    
}
