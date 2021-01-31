using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public GameObject ExplodeEffect;

    void OnCollisionEnter2D(Collision2D other)
    {
        if(!other.gameObject.CompareTag("Boss"))
            Destroy(gameObject);
    }

    void OnDestroy()
    {
        Instantiate(ExplodeEffect, transform.position, transform.rotation);
    }
}
