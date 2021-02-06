using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthPickup : MonoBehaviour
{
    Playermovement platerscript;
    public int healamount;
    private void Start()
    {
        platerscript = GameObject.FindGameObjectWithTag("Player").GetComponent<Playermovement>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            platerscript.heal(healamount);
            Destroy(gameObject);
        }
    }
}
