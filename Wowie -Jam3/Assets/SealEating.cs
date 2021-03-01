using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SealEating : MonoBehaviour
{
    public int pengtobeeaten;
    public int pengeaten;
    public string Scene;
    public string scenename;
    public Animator transition;


    public int timer;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(pengeaten == pengtobeeaten)
        {
            StartCoroutine(LoadScene());
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            Destroy(collision.gameObject);
            SoundManager.PlayerSound("Delicous");
            pengeaten++;
        }
        if (collision.CompareTag("Sword"))
        {
            StartCoroutine(SwordEnd());
        }
    }
    IEnumerator LoadScene()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(timer);

        SceneManager.LoadScene(Scene);

    }
    IEnumerator SwordEnd()
    {
        
        yield return new WaitForSeconds(timer);

        SceneManager.LoadScene(scenename);


    }
}
