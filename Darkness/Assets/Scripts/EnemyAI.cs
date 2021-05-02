using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
[SerializeField]Transform player;
    [SerializeField] float range;
    public float moveSpeed;
    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        float dist = Vector2.Distance(transform.position,player.position);
        if(dist > range)
        {
            transform.position = Vector2.MoveTowards(transform.position,player.position,moveSpeed * Time.deltaTime);
        }

    }

}
