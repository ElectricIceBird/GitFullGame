using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform target;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position; 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 newPositio = new Vector3(transform.position.x, transform.position.y, offset.z + target.position.z);
        transform.position = Vector3.Lerp(transform.position,newPositio , 10 *Time.fixedDeltaTime);
    }
}
