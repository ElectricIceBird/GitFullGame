using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthSystem : MonoBehaviour
{
    public Slider healthSlider;

    public float maxHealth = 100f;
    float health;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    void Update() 
    {
        healthSlider.value = Mathf.Lerp(healthSlider.value, health, Time.deltaTime * 12f);
    }

    public void DamagePlayer(float DamageAmount)
    {
        health -= DamageAmount; // damage the player
    }
    public void HealPlayer(float HealAmount)
    {
        health += HealAmount; // heal the player
    }

    private void OnCollisionEnter2D(Collision2D other) {

        if(other.gameObject.CompareTag("Insect") && !other.gameObject.GetComponent<Insect>().canBeEated)
        {
            DamagePlayer(Random.Range(3f,8f));
        }
    }
}
