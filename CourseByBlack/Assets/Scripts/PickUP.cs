using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUP : MonoBehaviour
{
    public Weapon weaponPickup;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            collision.GetComponent<Playermovement>().ChangeWeapon(weaponPickup);
            Destroy(gameObject);
        }
    }
}
