using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Playermovement : MonoBehaviour
{
    public Image[] heart;
    public Sprite emptygear;
    public Sprite fullgear;

    public GameObject hitEffect;
    public float speed;
    private Rigidbody2D rb;
    private Vector2 moveAmount;
    private Animator anim;
    public Animator Panelanim;

    public int health;
    public GameObject Deatheffect;
    private void Start() {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update() {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
         moveAmount= moveInput.normalized * speed;
         if(moveInput != Vector2.zero)
         {
             anim.SetBool("isRunning",true);
         }else
         {
             anim.SetBool("isRunning", false);
         }
    }
    private void FixedUpdate() {
        rb.MovePosition(rb.position + moveAmount * Time.fixedDeltaTime);
    }
    public void Takedamage(int damage)
 {
        Instantiate(hitEffect, transform.position, transform.rotation);
  health -= damage;
        Panelanim.SetTrigger("hurt");
  UpdateHealthUI(health);
        if (health <= 0)
  {
           
            Destroy(this.gameObject);
      Instantiate(Deatheffect,transform.position,Quaternion.identity);

  }
 }
    public void ChangeWeapon(Weapon weaponPickup)
    {
        Destroy(GameObject.FindGameObjectWithTag("Weapon"));
        Instantiate(weaponPickup, transform.position, transform.rotation, transform);
    }

    void UpdateHealthUI(int currentHealth)
    {
        for (int i = 0; i < heart.Length; i++)
        {
            if (i < currentHealth)
            {
                heart[i].sprite = fullgear;
            }
            else
            {
                heart[i].sprite = emptygear;
            }
        }
    }
    public void heal(int healamount)
    {
        if (health + healamount > 5) 
        {
            health = 5;
        }
        else
        {
            health += healamount;
            UpdateHealthUI(health);

        }
    }
}
