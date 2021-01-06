using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : Enemy
{
    public float stopDistance;
    private float attackTime;
    private Animator anim;
    public Transform shotpoint;
    public GameObject Bullet;
    // Start is called before the first frame update
   public override void Start()
    {
        base.Start();
      anim = GetComponent<Animator>();  
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            if(Vector2.Distance(transform.position,player.position)> stopDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position,player.position,speed * Time.deltaTime);
            }
            if(Time.time >= attackTime)
            {
             attackTime = Time.time  + timebetweenAttack;
             anim.SetTrigger("shoot");
            }
        }
        
    }
    public void RangeAttack()
    {
          Vector2 direction = player.position - shotpoint.position;
     float angle = Mathf.Atan2(direction.y,direction.x) * Mathf.Rad2Deg;
     Quaternion rotation = Quaternion.AngleAxis(angle ,Vector3.forward);
     shotpoint.rotation = rotation;
     Instantiate(Bullet,shotpoint.position,shotpoint.rotation);
    }
}
