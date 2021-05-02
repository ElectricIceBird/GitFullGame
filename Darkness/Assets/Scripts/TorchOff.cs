using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchOff : MonoBehaviour
{
    private Sprite TorchON;
    public Sprite Torchoff;
    public GameObject torchlight;
    public SpriteRenderer sr;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            TorchON = Torchoff;
            Destroy(torchlight);
            sr.sprite = TorchON;
        }
    }
}
