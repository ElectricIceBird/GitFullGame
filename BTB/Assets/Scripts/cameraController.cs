using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public Transform spiderPlayer;
    public Vector3 Offset;

    // Update is called once per frame
    void Update()
    {
        transform.position = spiderPlayer.position + Offset;
    }
}
