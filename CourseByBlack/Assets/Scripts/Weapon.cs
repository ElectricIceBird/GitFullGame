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
    private Animator Camanim;

    public float angletobeadded;
    public float rotationangle;
    void Start()
    {
        anim = GetComponent<Animator>();
        Camanim = Camera.main.GetComponent<Animator>();
    }
 private void Update() {
     Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
     float angle = Mathf.Atan2(direction.y,direction.x) * Mathf.Rad2Deg;
     Quaternion rotation = Quaternion.AngleAxis(angle + rotationangle,Vector3.forward);
     Quaternion Fire = Quaternion.AngleAxis(angle + angletobeadded,Vector3.forward);
     transform.rotation = rotation;
     shotPosition.rotation = Fire;
     
     if(Input.GetMouseButton(0)){
        

     if(Time.time >= shotTime)
     {
         anim.SetTrigger("Firing");

         Instantiate(projectile,shotPosition.position,shotPosition.rotation);
         shotTime = Time.time + shotbtwTime;
                Camanim.SetTrigger("shake");
     }
     }
 }
}
