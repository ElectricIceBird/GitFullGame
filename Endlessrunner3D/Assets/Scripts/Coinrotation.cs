using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coinrotation : MonoBehaviour
{
    public GameObject parti;
    Vector3 transformXYZ;

    //public static int pemCoins;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
      transformXYZ = this.transform.position;

        if (Input.GetKey(KeyCode.Space)) 
        {
            print("HellowORLD");
            Instantiate(parti,transformXYZ,Quaternion.identity);

        
        }
        transform.Rotate(50 * Time.deltaTime, 0,0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController.numbersofCoin += 1;

            PlayerPrefs.SetInt("NumberOfCoins",PlayerController.numbersofCoin);
            
                      Instantiate(parti,transformXYZ,Quaternion.identity);

            

            FindObjectOfType<AudioManager>().Playsound("PickUp");
           
                Destroy(gameObject);
        }
    }
}
