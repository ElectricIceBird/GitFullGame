using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
   public float speed;
   public Vector2 target;
   public float lifetime;
   public GameObject effect;
   public int damage;
   private void Start() {
     target =  Camera.main.ScreenToWorldPoint(Input.mousePosition);
   }
   private void Update() {
       transform.position = Vector2.MoveTowards(transform.position,target,speed* Time.deltaTime);
       if(Vector2.Distance(transform.position,target)< 0.2f){
            Instantiate(effect,transform.position,Quaternion.identity);

       Destroy(gameObject);
           
       }

   }
   private void OnTriggerEnter2D(Collider2D other) {
     if(other.CompareTag("Enemy"))
     {
       other.GetComponent<Enemy>().Takedamage(damage);
            Instantiate(effect,transform.position,Quaternion.identity);

       Destroy(gameObject);

     }
   }
}
