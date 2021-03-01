using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public string SceneName;
    public Animator transition;
    public float transitiontime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void play()
    {
        StartCoroutine(loadLevel());
    }
    public void Exit()
    {
        Application.Quit();
        Debug.Log("Working");
    }
    IEnumerator loadLevel()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitiontime);
        SceneManager.LoadScene(SceneName);


    }
}
