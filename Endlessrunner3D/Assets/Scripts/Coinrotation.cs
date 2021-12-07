using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coinrotation : MonoBehaviour
{

    //public static int pemCoins;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(50 * Time.deltaTime, 0,0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController.numbersofCoin += 1;

            PlayerPrefs.GetInt("NumberOfCoins",PlayerController.numbersofCoin);
            

            FindObjectOfType<AudioManager>().Playsound("PickUp");

          
            Destroy(gameObject);
        }
    }
}
