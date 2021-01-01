using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summomer : Enemy
{
    public float maxX;
    public float minX;
    public float minY;
    public float maxY;
    public float attackspeed;
    public float stopDistance;
    private Vector2 targetPosition;
    private Animator anim;
    public float timeBetweenSummon;
    private float Summontime;
    public Enemy enemyToSummon;
   private float attacktime;
   public int damage;
    public override void Start()   
    {
        base.Start();
        float randomX = Random.Range(minX,maxX);
        float randomY = Random.Range(minY,maxY);
        targetPosition = new Vector2(randomX,randomY);
        anim = GetComponent<Animator>();

    }
    private void Update() {
      if(player != null)
    {
        if(Vector2.Distance(transform.position,targetPosition)> .5f)
        {
            transform.position = Vector2.MoveTowards(transform.position,targetPosition,speed * Time.deltaTime);
            anim.SetBool("isRunning",true);
        }else
        {
            anim.SetBool("isRunning",false);
        }

        
        if(Time.time >= Summontime)
        {
            Summontime = Time.time + timeBetweenSummon;
            anim.SetTrigger("Summon");
            Summon();
        }
         if(Vector2.Distance(transform.position,player.position)> stopDistance)
        {
           if(Time.time >= attacktime)
            {
                StartCoroutine(attack());
                attacktime = Time.time + timebetweenAttack;
            }
        }
    }
    }
    public void Summon()
    {
        if(player != null)
        {
         Instantiate(enemyToSummon,transform.position,transform.rotation);
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
