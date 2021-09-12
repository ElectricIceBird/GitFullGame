using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmpolyeHealth : MonoBehaviour
{
    
    public static float sanity;
   
    // Start is called before the first frame update
    void Start()
    {
        sanity = 100;
    }

    // Update is called once per frame
    void Update()
    {
       if(sanity <= 0)
        {
            Die();
        }
        else
        {
            //sanity -= .01f;
            Debug.Log(sanity);
        } 
    }
   public void Die()
    {
        Destroy(gameObject);
    }
   public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Donut"))
        {
            Debug.Log("Colling");
           sanity++;
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Coffee"))
        {
            sanity++;
        }

    }
}
