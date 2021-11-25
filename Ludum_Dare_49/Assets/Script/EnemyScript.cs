using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]float speed;
    Rigidbody2D rb;
    public GameObject chip;
    Vector2 movement;
    private SpriteRenderer sr;
    Vector3 currentposition;
    public GameObject particle;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        movement.x = transform.position.x;
        movement.y = 0;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        currentposition = movement;


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("LeftWall"))
        {
            speed = -speed;
            sr.flipX = false;

        }
        if (collision.CompareTag("RightWall"))
        {
            speed = -speed;
            sr.flipX = true;
        }
        if (collision.CompareTag("Bullet"))
        {
            AudioManager.ad.Playsound("Exp");

            Instantiate(chip, this.transform.position, Quaternion.identity);
            Instantiate(particle,transform.position,Quaternion.identity);

            Destroy(gameObject);
        }
    }
}
