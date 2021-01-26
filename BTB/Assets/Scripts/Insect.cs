using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Insect : MonoBehaviour
{
    public GameObject eatedEffect;

    public float speed;
    private float waitTime;
    public float startWaitTime;

    [Range(2f,10f)]
    public float upperLimit = 5f;
    [Range(-2f,-10f)]
    public float lowerLimit = -5f;

    float randomDirX;
    float randomDirY;

    Vector2 Dir;

    public bool canBeEated = false;
    public bool needToRotate = false;

    void Start()
    {
        waitTime = startWaitTime;
        randomDirX = Random.Range(lowerLimit, upperLimit);
        randomDirY = Random.Range(lowerLimit, upperLimit);
        Dir = new Vector2(randomDirX, randomDirY);
    }

    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, Dir, speed * Time.deltaTime);

        if(needToRotate)
        {
            Vector2 Target = Dir - (Vector2)transform.position;
            float Angle = Mathf.Atan2(Target.y,Target.x) * Mathf.Rad2Deg + 90f;
            transform.rotation = Quaternion.Euler(0f,0f,Angle);
        }

        if (Vector2.Distance(transform.position, Dir) < 0.2f)
        {
            if (waitTime <= 0)
            {
                randomDirX = Random.Range(lowerLimit, upperLimit);
                randomDirY = Random.Range(lowerLimit, upperLimit);
                Dir = new Vector2(randomDirX, randomDirY);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Web"))
        {
            speed = 0;
            canBeEated = true;
        }
    }

    public void getEated()
    {
        Instantiate(eatedEffect,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }
}
