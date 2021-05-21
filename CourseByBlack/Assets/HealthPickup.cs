using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthPickup : MonoBehaviour
{
    Playermovement platerscript;
    public GameObject effect;
    public int healamount;
    private void Start()
    {
        platerscript = GameObject.FindGameObjectWithTag("Player").GetComponent<Playermovement>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            Instantiate(effect, transform.position, transform.rotation);
            platerscript.heal(healamount);
            Destroy(gameObject);
        }
    }
}
