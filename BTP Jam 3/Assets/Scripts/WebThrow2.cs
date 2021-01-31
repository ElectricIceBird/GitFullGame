using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class WebThrow2 : MonoBehaviour
{
    public Rigidbody2D rb;
    public float webThrowSpeed = 10f;
    public float destroyTime = 2f;


    public GameObject ExplodeEffect;

    void Start()
    {
        Destroy(gameObject, destroyTime);
    }

    void Update()
    {
        rb.velocity = transform.up * webThrowSpeed * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(!other.gameObject.CompareTag("Boss"))
        {
            CameraShaker.Instance.ShakeOnce(12f,8f,.1f,1f);
            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        Instantiate(ExplodeEffect, transform.position, transform.rotation);
    }
}
