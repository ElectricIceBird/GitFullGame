using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject projectile;
    public Transform shotPosition;
    public float shotbtwTime;
    private float shotTime;
    private Animator anim;
   
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }
 private void Update() {
     Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
     float angle = Mathf.Atan2(direction.y,direction.x) * Mathf.Rad2Deg;
     Quaternion rotation = Quaternion.AngleAxis(angle ,Vector3.forward);
     transform.rotation = rotation;
     if(Input.GetMouseButton(0)){
        

     if(Time.time >= shotTime)
     {
         anim.SetTrigger("Firing");

         Instantiate(projectile,shotPosition.position,transform.rotation);
         shotTime = Time.time + shotbtwTime;
     }
     }
 }
}
