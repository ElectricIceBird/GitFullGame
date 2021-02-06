using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy{
    public float stopDistance;
    private float attacktime;
    public int damage;
    public float attackspeed;
    private void Update() {
        
    
    if(player != null)
    {
       
        if(Vector2.Distance(transform.position,player.position)> stopDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position,player.position,speed * Time.deltaTime);
        }else
        {
            if(Time.time >= attacktime)
            {
                StartCoroutine(attack());
                attacktime = Time.time + timebetweenAttack;
            }
        
 
        }
    }
    
    }
    IEnumerator attack()
    {
        player.GetComponent<Playermovement>().Takedamage(damage);
        Vector2 originalPosistion = transform.position;
        Vector2 targetPosistion = player.position;
        float percent = 0;
        while (percent <= 1)
        {
            percent += Time.deltaTime * attackspeed;
            float formula = (-Mathf.Pow(percent,2)+percent) * 4;
            transform.position = Vector2.Lerp(originalPosistion,targetPosistion,formula);
            yield return null;
        }
    }
}
