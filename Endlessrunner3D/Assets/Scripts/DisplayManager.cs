using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayManager : MonoBehaviour
{
    public static bool gameover;
    public GameObject goPanel;
    public static bool isStarted;
    public GameObject startText;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        gameover = false;
        isStarted = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (gameover)
        {
            Time.timeScale = 0;
            goPanel.SetActive(true);
        }
        if (SwipeManager.tap)
        {
            isStarted = true;
            Destroy(startText);

        }
    }
}
