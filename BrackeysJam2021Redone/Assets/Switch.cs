using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public int timer;
    public GameObject Exitpoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer++;
        
    }
   public  void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Projectile") || collision.CompareTag("Bonkers"))
        {
            Debug.Log(timer);
            Exitpoint.GetComponent<SpriteRenderer>().enabled = true;
            Exitpoint.GetComponent<CircleCollider2D>().enabled = true;


        }
    }
}
