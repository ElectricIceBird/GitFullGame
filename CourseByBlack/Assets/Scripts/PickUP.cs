using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUP : MonoBehaviour
{
    public Weapon weaponPickup;
    public GameObject pickupEffect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            Instantiate(pickupEffect, transform.position, transform.rotation);
            collision.GetComponent<Playermovement>().ChangeWeapon(weaponPickup);
            Destroy(gameObject);
        }
    }
}
