using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public string sceneName;
    public GameObject paricle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {if(GameObject.FindGameObjectsWithTag("Player").Length == 0 && GameObject.FindGameObjectsWithTag("Bonkers").Length == 0)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            Destroy(GameObject.FindGameObjectWithTag("Player"));
            Instantiate(paricle, transform.position, transform.rotation);
         

        }
        if (collision.CompareTag("Bonkers"))
        {
            Instantiate(paricle, transform.position, transform.rotation);

            Destroy(GameObject.FindGameObjectWithTag("Bonkers"));


        }
    }
}
