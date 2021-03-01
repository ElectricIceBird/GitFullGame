using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinAi : MonoBehaviour
{
    public float speed;
    public Transform[] movePoints;
    private int randSpot;
    public float startWaitTime;
    private float waitTime;
    
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        randSpot = Random.Range(0,movePoints.Length);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,movePoints[randSpot].position,speed * Time.deltaTime);
        if(Vector2.Distance(transform.position,movePoints[randSpot].position)< 0.2f)
        {
            if(waitTime == 0)
            {
                randSpot = Random.Range(0, movePoints.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }

        }
      
    }
}
