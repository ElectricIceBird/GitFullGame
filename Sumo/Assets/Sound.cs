using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
   public  string strTag;
    
    public GameObject Particle;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == strTag)
            Instantiate(Particle,transform.position,transform.rotation);
            
    }
}
