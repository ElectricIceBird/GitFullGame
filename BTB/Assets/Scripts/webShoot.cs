using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class webShoot : MonoBehaviour
{   
    webFluid webfluid;
    healthSystem spiderHealthSystem;

    public float StartTimeBtwShots = .5f;//FireRate
    public float decreaseFluidWhileShooting = 5f;//FireRate
    private float TimeBtwShots;

    public float radius = 0.5f;

    public LayerMask whatIsInsect;

    public GameObject web;

    public Transform shootPosition;//the position from where spider should throw web

    // Start is called before the first frame update
    void Start()
    {
        spiderHealthSystem = FindObjectOfType<healthSystem>();
        TimeBtwShots = StartTimeBtwShots;
        webfluid = FindObjectOfType<webFluid>();
    }

    // Update is called once per frame
    void Update()
    {
        if(TimeBtwShots <= 0f)
        {
            if(Input.GetButtonDown("Fire1"))//space key is Pressed
            {
                decreaseFluidWhileShooting = Random.Range(1f,4f);
                if(webfluid.webFluidAmount < decreaseFluidWhileShooting)
                {
                    Debug.Log("Not have enought Web Fluid to shoot");
                }
                else
                {
                    Instantiate(web,shootPosition.position,transform.rotation);
                    webfluid.DecreaseWebFluid(decreaseFluidWhileShooting);
                }
            }
        }
        else
        {
            TimeBtwShots -= Time.deltaTime;
        }
        if(Input.GetButton("Jump"))
        {
            Collider2D getInsectNearMe = Physics2D.OverlapCircle(shootPosition.position,radius,whatIsInsect);
            if(getInsectNearMe != null)
            {
                Insect insect = getInsectNearMe.GetComponent<Insect>();
                if(insect.canBeEated)
                {
                    insect.getEated();
                    spiderHealthSystem.HealPlayer(Random.Range(4f,10f));
                }
            }
        }
    }

}
