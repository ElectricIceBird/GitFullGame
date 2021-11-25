using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAI : MonoBehaviour
{
    public float speed;
    public Transform[] moveSpots;
    private int randomspot;
    private float waitTime;
    public float startwaitTime;

    private void Start()
    {
        waitTime = startwaitTime;
        randomspot = Random.Range(0,moveSpots.Length);
    }
    private void Update()
    {

        

        transform.position = Vector2.MoveTowards(transform.position,moveSpots[randomspot].position,speed * Time.deltaTime);
        if(Vector2.Distance(transform.position,moveSpots[randomspot].position) < 0.2f)
        {
            if(waitTime <= 0)
            {
                randomspot = Random.Range(0, moveSpots.Length);
                waitTime = startwaitTime;


            }
            else
            {

                waitTime -= Time.deltaTime;
            }
        }
        
    }
}
