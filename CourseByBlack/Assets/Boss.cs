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
    public AudioClip firing;
    public AudioClip angry;

    public AudioClip[] hurt;
    public AudioClip summon;

    public AudioSource source;
    public AudioSource source2;
    public AudioSource source3;


    private float halfHealth;
    public int damage;
    public GameObject bulls;
    public float timer;
    public float mintime;
    public float maxtime;
    public GameObject Dusteffect;
    public GameObject blood;
    public float angletobeadded;
    public float rotationangle;
    Vector2 direction;
    public Transform shotpoint;
    public Transform player;



    // Start is called before the first frame update
    void Start()
    {
        timer = Random.Range(mintime, maxtime);
        halfHealth = health / 2f;
        anim = GetComponent<Animator>();
        int randomNumbers = Random.Range(0, hurt.Length);
        source.clip = hurt[randomNumbers];
        player = GameObject.FindGameObjectWithTag("Player").transform;


    }
    public void Firing() 
    {
        Instantiate(bulls, shotpoint.position, shotpoint.rotation);
        source2.clip = firing;
        source2.Play();

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
        if (player != null)
        {
            Vector2 direction = player.position - shotpoint.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
            shotpoint.rotation = rotation;
        }
    }
   
    public void Takedamage(int damage)
    {
        health -= damage;
        anim.SetTrigger("Summon");
        source.Play();

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
            source3.clip = angry;
            source3.Play();
            
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
