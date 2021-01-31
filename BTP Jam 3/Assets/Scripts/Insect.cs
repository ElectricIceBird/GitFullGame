using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class Insect : MonoBehaviour
{
    public string insectName;

    GameManager gameManager;

    Animator animator;
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

    public ObjectShake os;//John *****

    void Start()
    {
        gameManager = GameManager.instance;
        animator = GetComponent<Animator>();
        waitTime = startWaitTime;
        randomDirX = Random.Range(lowerLimit, upperLimit);
        randomDirY = Random.Range(lowerLimit, upperLimit);
        Dir = new Vector2(randomDirX, randomDirY);
        os = GetComponent<ObjectShake>();
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
            transform.Rotate(new Vector3(0f,0f,Random.Range(0f,-180f)));
            animator.SetTrigger("caught");
            os.Shake();//John *****
            canBeEated = true;
            StartCoroutine(DisappearEnemy());
        }
    }

    public void getEated()
    {
        Instantiate(eatedEffect,transform.position,Quaternion.identity);
        if(insectName == "ladyBug")
        {
            gameManager.ladyBugs -= 1;
        }
        else if(insectName == "mosquito")
        {
            gameManager.mosquitos -= 1;
        }
        else if(insectName == "beetle")
        {
            gameManager.beetles -= 1;
        }
        else if(insectName == "butterfly")
        {
            gameManager.butterfly -= 1;
        }
        else if(insectName == "fly")
        {
            gameManager.fly -= 1;      
        }
        CameraShaker.Instance.ShakeOnce(6f,6f,.1f,1f);
        gameManager.checkTaskDoneOrNot();
        Destroy(gameObject);
    }

    IEnumerator DisappearEnemy()
    {
        yield return new WaitForSeconds(10f);
        animator.SetTrigger("disappear");
        yield return new WaitForSeconds(.5f);
        Instantiate(eatedEffect,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }
}
