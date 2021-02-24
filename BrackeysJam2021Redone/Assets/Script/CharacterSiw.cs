using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSiw : MonoBehaviour
{
    public GameObject player;
    public GameObject player2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player2 == null)
        {
            
            player.GetComponent<Move2D>().enabled = true;

        }
    }
}
