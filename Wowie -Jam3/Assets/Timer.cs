using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI textdisplay;

    public int secondsleft;
    public bool takingaway;
    public string SceneName;
    public float timer;
    public Animator transition;
    
    // Start is called before the first frame update
    void Start()
    {
        textdisplay.GetComponent<TextMeshProUGUI>().text = "Timer:" + secondsleft;
    }

    // Update is called once per frame
    void Update()
    {
     if(takingaway == false && secondsleft > 0)
        {
            StartCoroutine(TimerTake());
        }
     if(secondsleft == 0)
        {
            StartCoroutine(LoadScene());
        }
        
    }
    IEnumerator TimerTake()
    {
        takingaway = true;
        yield return new WaitForSeconds(1);
        secondsleft-=1;
        textdisplay.GetComponent<TextMeshProUGUI>().text = "Timer:" + secondsleft;
        takingaway = false;
    }
    IEnumerator LoadScene()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(timer);

        SceneManager.LoadScene(SceneName);

    }
}
