using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Enemy : MonoBehaviour
{public int health;
public float speed;
   
    public int pickupChance;
    public int healthpickupChance;
    public GameObject healthPickup;

    public GameObject[] WeaponPick;

public float timebetweenAttack;
public GameObject Deatheffect;
[HideInInspector]
public Transform player;
public virtual void Start() {
    player = GameObject.FindGameObjectWithTag("Player").transform;
    

}
 public void Takedamage(int damage)
 {
  health -= damage;
  if(health <= 0)
  {
            
            int Randomnumber = Random.Range(0, 101);
            if(Randomnumber < pickupChance) 
            {
                GameObject randomPickup = WeaponPick[Random.Range(0, WeaponPick.Length)];
                Instantiate(randomPickup,transform.position,transform.rotation);
            }
            int HealthRandomNo = Random.Range(0, 101);
            if (HealthRandomNo < pickupChance)
            {
              Instantiate(healthPickup, transform.position, transform.rotation);
            }
            Destroy(gameObject);
      Instantiate(Deatheffect,transform.position,Quaternion.identity);

  }
 }
}
