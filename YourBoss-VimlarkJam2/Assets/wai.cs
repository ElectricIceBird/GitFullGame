using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class wai : MonoBehaviour
{
    public float waittime;

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Wait());
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(waittime);
        SceneManager.LoadScene("MainMenu");
    }
}
