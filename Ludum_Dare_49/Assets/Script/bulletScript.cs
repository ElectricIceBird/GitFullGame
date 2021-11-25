using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] int damage;
    [SerializeField] int timetodestroy = 5;
    public GameObject particle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Startshooting(bool isfacingleft)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (isfacingleft)
        {
            rb.velocity = new Vector2(-speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(speed, 0);

        }
        Destroy(gameObject, timetodestroy);
        Instantiate(particle, transform.position, Quaternion.identity);


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            Instantiate(particle,transform.position,Quaternion.identity);
            Destroy(gameObject);

        }
    }
}
