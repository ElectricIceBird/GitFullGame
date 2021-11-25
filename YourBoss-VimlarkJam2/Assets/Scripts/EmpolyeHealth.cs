using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EmpolyeHealth : MonoBehaviour
{

    public float timer;
    public TextMeshProUGUI gae;
    public TextMeshProUGUI gae2;

    public GameObject panel;
    public ParticleSystem pa;
    public ParticleSystem co;



    public float Currentsanity;
     float sanity;
    public HealthBar hb;
   
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;        
        sanity = 100;
        Currentsanity = sanity;
        hb.SetMan(sanity);
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Currentsanity <= 0)
        {
            Die();
        }
        else
        {
            timer+=.01f;

        gae.text = "Time:" + timer;
            Currentsanity -= .01f;
            hb.Set(Currentsanity);

            //Debug.Log(sanity);
        }
      
    }
   public void Die()
    {

        panel.SetActive(true);
        gae2.text = "Time:" +  timer;

        Time.timeScale = 0;
       
    }
   public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Donut"))
        {
            //Debug.Log("Colling");
            Currentsanity += 10f;
            hb.Set(Currentsanity);
            Instantiate(pa,transform);
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Coffee"))
        {
            hb.Set(Currentsanity);
            Instantiate(co,transform);
            
            Currentsanity += 25f;
            Destroy(other.gameObject);


        }
        if (other.CompareTag("Task"))
        {
            Destroy(other.gameObject);
                            
            Currentsanity -= 10f;
            hb.Set(Currentsanity);
            TaskSystem.currenttaksHealth += 25f;
            



        }

    }
}
