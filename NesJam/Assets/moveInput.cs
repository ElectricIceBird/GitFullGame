using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    [RequireComponent(typeof(move))]
public class moveInput : MonoBehaviour
{
    private move input; 
    // Start is called before the first frame update
  public  void Start()
    {
        input = GetComponent<move>();
    }

    // Update is called once per frame
    public void Update()
    {
        input.vertical = Input.GetAxis("Vertical");
        input.horizonntal = Input.GetAxis("Horizontal");
    }
}
