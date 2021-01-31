using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public Transform spiderPlayer;
    public Vector3 Offset;
    Camera cam;

    float increaseOrthographic = 4.5f;

    private void Start() {
        cam = Camera.main;
    }

    public void SetOrthographicSize(float amount)
    {
        increaseOrthographic = amount;
    }

    void Update()
    {
        if(!spiderPlayer)
        {
            return;
        }
        transform.position = spiderPlayer.position + Offset;
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, increaseOrthographic, Time.deltaTime * 5f);
    }
}
