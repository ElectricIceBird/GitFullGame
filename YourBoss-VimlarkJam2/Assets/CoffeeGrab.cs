using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeGrab : MonoBehaviour
{

    public Transform grabdectec;
    public Transform boxHolder;
    public float raydist;
    // Update is called once per frame
    void Update()
    {
        RaycastHit2D grabcheck = Physics2D.Raycast(grabdectec.position, Vector2.right * transform.localScale, raydist);
        if (grabcheck.collider != null && !grabcheck.collider.CompareTag("Wall"))
        {
            if (grabcheck.collider.CompareTag("Task") || grabcheck.collider.CompareTag("Donut")) { return; }
            else
            {
                if (Input.GetKey(KeyCode.G) && grabcheck.collider.CompareTag("Coffee"))
                {

                    grabcheck.collider.gameObject.transform.parent = boxHolder;
                    grabcheck.collider.gameObject.transform.position = boxHolder.position;
                    grabcheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
                }
                else
                {
                    grabcheck.collider.gameObject.transform.parent = null;
                    grabcheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;

                }
            }
        }

    }
}
