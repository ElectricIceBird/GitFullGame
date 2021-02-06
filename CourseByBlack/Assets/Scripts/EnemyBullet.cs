using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Playermovement playerScript;
    private Vector2 targerPosition;
    public float speed;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Playermovement>();
        targerPosition = playerScript.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position,targerPosition) > .1f)
        {
          transform.position = Vector2.MoveTowards(transform.position,targerPosition,speed * Time.deltaTime);
        }else
        {
            Destroy(gameObject);
        }
        
        }
        private void OnTriggerEnter2D(Collider2D other) {
            if(other.CompareTag("Player"))
            {
                playerScript.Takedamage(damage);
            Destroy(gameObject);
                
            }
    }
}
