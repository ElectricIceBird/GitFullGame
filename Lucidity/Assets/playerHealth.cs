using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    public int hp;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(hp <= 0)
        {
            Debug.Log("O");
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.collider.CompareTag("Enemy"))
        {
            --hp;
        }
    }
}
