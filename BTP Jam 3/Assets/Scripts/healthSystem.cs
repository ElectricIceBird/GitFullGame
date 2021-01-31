using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EZCameraShake;

public class healthSystem : MonoBehaviour
{
    public Slider healthSlider;
    public Animator animator;
    AudioManager audioManager;

    public float maxHealth = 100f;
    float health;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        animator = GetComponent<Animator>();
        audioManager = AudioManager.instance;
    }

    void Update() 
    {
        healthSlider.value = Mathf.Lerp(healthSlider.value, health, Time.deltaTime * 12f);
        if(health > 100f)
        {
            health = 100f;
        }
        else if(health < 0f)
        {
            health = 0f;
        }
    }

    public void DamagePlayer(float DamageAmount)
    {
        health -= DamageAmount; // damage the player
        if(health < 0f)
        {
            //Play player Death Animation
            health = 0f;
            Destroy(gameObject);
        }
    }
    public void HealPlayer(float HealAmount)
    {
        health += HealAmount; // heal the player
    }

    private void OnCollisionEnter2D(Collision2D other) {

        if(other.gameObject.CompareTag("Insect") && !other.gameObject.GetComponent<Insect>().canBeEated)
        {
            DamagePlayer(10f);
            CameraShaker.Instance.ShakeOnce(4f,4f,.1f,1f);
            audioManager.Play("BugHit");
            animator.SetTrigger("damage");
        }
        else if (other.gameObject.CompareTag("Boss"))
        {
            DamagePlayer(40f);
            CameraShaker.Instance.ShakeOnce(4f,4f,.1f,1f);
            audioManager.Play("BugHit");
            animator.SetTrigger("damage");
        }
        else if (other.gameObject.CompareTag("BossWeb"))
        {
            audioManager.Play("BugHit");
            CameraShaker.Instance.ShakeOnce(10f,4f,.1f,1f);
            DamagePlayer(25f);
            animator.SetTrigger("damage");
        }
    }
}
