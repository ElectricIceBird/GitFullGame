using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class Timer : MonoBehaviour
{
    [SerializeField] float timervalue;
    [SerializeField] TextMeshProUGUI Tmpo;
    // Start is called before the first frame update
    void Start()
    {
        Tmpo.text = "Timer:" + timervalue;

    }

    // Update is called once per frame
    void Update()
    {
        if (timervalue <= 0)
        {
            SceneManager.LoadScene("YouWin");
        }
        else
        {
            timervalue -= Time.deltaTime * 1 ;
            Tmpo.text = "Timer:" + timervalue;

        }
    }
}
