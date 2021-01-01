using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{public int health;
public float speed;

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
      Destroy(gameObject);
      Instantiate(Deatheffect,transform.position,Quaternion.identity);

  }
 }
}
