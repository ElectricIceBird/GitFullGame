using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject Deatheffect;
    private Animator anim;
    public int health;
    public float spawnoffset;
    public Enemy[] enes;
    private float halfHealth;
    public int damage;
    public GameObject bulls;
    public float timer;
    public float mintime;
    public float maxtime;
    public GameObject Dusteffect;
    public GameObject blood;


    // Start is called before the first frame update
    void Start()
    {
        timer = Random.Range(mintime, maxtime);
        halfHealth = health / 2f;
        anim = GetComponent<Animator>();
    }
    public void Firing() 
    {
        Instantiate(bulls, transform.position , transform.rotation);
    }
    // Update is called once per frame
    void Update()
    {
      
        if(timer <= 0) 
        {
            anim.SetTrigger("Fire");
        timer = Random.Range(mintime, maxtime);

        }
        else 
        {
            timer -= Time.deltaTime;
        }


    }
   
    public void Takedamage(int damage)
    {
        health -= damage;
        anim.SetTrigger("Summon");

        if (health <= 0)
        {

            Instantiate(blood, transform.position, transform.rotation);
            Instantiate(Deatheffect, transform.position, Quaternion.identity);
            Destroy(this.gameObject);

        }
        if(health <= halfHealth) 
        {
            mintime = 1;
            maxtime = 25;
            anim.SetTrigger("Fast");
        }
        Enemy randenem = enes[Random.Range(0, enes.Length)];
        Instantiate(randenem, transform.position + new Vector3(spawnoffset,spawnoffset,0), transform.rotation);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("touching");
            collision.GetComponent<Playermovement>().Takedamage(damage);
        }
    }
    public void Dust()
    {
        Instantiate(Dusteffect, transform.position, transform.rotation);
    }

}
