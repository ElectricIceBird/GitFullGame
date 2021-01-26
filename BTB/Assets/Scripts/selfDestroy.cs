using UnityEngine;

public class selfDestroy : MonoBehaviour
{
    public float timeToDestroy = 3f;

    void Start()
    {
        Destroy(gameObject, timeToDestroy);
    }

}
