using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabController : MonoBehaviour
{
    public Transform grabPoint;
    public Transform holder;
    public float raydist;
    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }







    // Update is called once per frame
    void Update()
    {
        RaycastHit2D grabCheck = Physics2D.Raycast(grabPoint.position, Vector2.down * transform.localScale, raydist);
        if (grabCheck.collider != null)
        {

            if (Input.GetKey(KeyCode.E)&& grabCheck.collider.CompareTag("Box"))
            {
                grabCheck.collider.gameObject.transform.parent = holder;
                grabCheck.collider.gameObject.transform.position = holder.position;
                
             }
            else
            {
                grabCheck.collider.gameObject.transform.parent = null;
                                 
            }
        }
      
    }
}
