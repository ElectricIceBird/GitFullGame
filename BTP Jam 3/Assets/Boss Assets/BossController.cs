using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossController : MonoBehaviour
{
    /*
     * IF YOUR VERSION OF THIS GLITCHES OUT PLEASE LET ME KNOW I HAVE A BUG THAT OCCASIONALLY SHOWS
     */
    public float encounterTimer;//encounterTimer tracking how long we've been facing the enemy
    public ObjectShake os;
    public Transform[] waypoint;
    public RotateSpriteToward rst;
    private float distance;
    private int waypointCounter = 0;
    [SerializeField]
    private float afterShootCounter = 0f;
    public Transform player;
    public int waypointIndex;
    public float bossSpeed = 5f;//change in inspector
    private int lastNumber;
    private bool shoot = true;
    public GameObject web;
    public Transform shootPoint;
    Animator animator;

    private void Start()
    {
        waypointIndex = Random.Range(0, 8);
        animator = GetComponent<Animator>();

    }

    void Update()
    {
        if(!player)
        {
            animator.SetTrigger("idle");
            return;
        }

        encounterTimer += Time.deltaTime;//this is equivalent to a resetable Time.time different from when doing this in regular update

        /*
         *
         */
        /*
        if (encounterTimer >= 0f && encounterTimer <= 2f)
        {
            transform.localScale = new Vector3(2f,2f,1f);
        }
        if (encounterTimer >= 2f && transform.localScale.x >= .7f && transform.localScale.y >= .7f)
        {
            transform.localScale -= new Vector3(.01f,.01f,0f);
            os.Shake();
        }*/
        if (encounterTimer >= 5f)
        {
            //transform.Translate(Vector3.down * Time.deltaTime);
            distance = Vector3.Distance(waypoint[waypointIndex].position, transform.position);

            if (distance > 1.5f)
            {
                Vector3 vectorToTarget = waypoint[waypointIndex].position - transform.position;
                float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
                Quaternion q = Quaternion.AngleAxis(angle + 90f, Vector3.forward);//the angle + 90f is due to the downward original rotation
                transform.rotation = q;
                transform.Translate(Vector3.down * Time.deltaTime * bossSpeed);
            }
            if (distance < 1.5f && afterShootCounter < 1f)
            {
                Vector3 vectorToTarget = player.position - transform.position;
                float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
                Quaternion q = Quaternion.AngleAxis(angle + 90f, Vector3.forward);//the angle + 90f is due to the downward original rotation
                transform.rotation = q;
                afterShootCounter += Time.deltaTime;

                

                if (shoot)
                {
                    Vector3 vectorToTarget1 = player.position - transform.position;
                    float angle1 = Mathf.Atan2(vectorToTarget1.y, vectorToTarget1.x) * Mathf.Rad2Deg;
                    Quaternion q1 = Quaternion.AngleAxis(angle1 + 90f, Vector3.forward);//the angle + 90f is due to the downward original rotation
                    transform.rotation = q1;
                    Instantiate(web, shootPoint.position, q1 * Quaternion.Euler(0f,0f,180f)) ;
                    shoot = false;
                    animator.SetTrigger("shoot");
                }
                //transform.Translate(Vector3.down * Time.deltaTime * 10f);
            }
            if (distance < 1.5f && afterShootCounter >= 1f)
            {
                Vector3 vectorToTarget = waypoint[waypointIndex].position - transform.position;
                float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
                Quaternion q = Quaternion.AngleAxis(angle + 90f, Vector3.forward);//the angle + 90f is due to the downward original rotation
                transform.rotation = q;
                transform.Translate(Vector3.down * Time.deltaTime * bossSpeed);
            }
            if (afterShootCounter >= 1f)
            {
                animator.SetTrigger("idle");
                waypointCounter += 1;
                afterShootCounter = 0f;
                lastNumber = waypointIndex;
                waypointIndex = Random.Range(0, 15);
                shoot = true;
                
                /*
                 * if you use regular RNG random number generation
                 * random.range then I seen the spider boss repeat
                 * the same waypoint. This is a specialized RNG correction script
                 * it prevents the spider boss choosing the same waypoint 2 times in a row
                 */
                if (lastNumber == waypointIndex)
                {
                    waypointIndex += Random.Range(1, 3);
                    if (waypointIndex > 14)
                    {
                        waypointIndex = lastNumber - 1;
                    }
                }
            }
            if (waypointCounter == 15)
            {
                waypointCounter = 0;
            }
                //transform.Translate(Vector3.left * Time.deltaTime);
            
            
            
        }
    }
}
