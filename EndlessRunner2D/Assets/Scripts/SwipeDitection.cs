
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwipeDitection : MonoBehaviour
{
    private InputManager inputmanager;

    private Vector2 startPosition;
    private float starttime;
    private Vector2 endPosition;
    private float endtime;
    [SerializeField]
    private float minimumdistance =.2f;
    [SerializeField] private float maximumtime =1f;
    [SerializeField, Range(0f, 1f)] private float directointhershold = .9f;
    [SerializeField] private GameObject trail;
    private Coroutine corutine;


    private void Awake()
    {
        inputmanager = InputManager.Instance;
    }
    private void OnEnable()
    {
        inputmanager.OnstartTouch += SwipeStart;
        inputmanager.OnendTouch += SwipeEnd;

    }
    private void OnDisable()
    {
        inputmanager.OnstartTouch += SwipeStart;
        inputmanager.OnendTouch += SwipeEnd;

    }
    private void SwipeStart(Vector2 position, float time)
    {
        trail.SetActive(true);
        trail.transform.position = position;
        startPosition = position;
        starttime = time;
        corutine = StartCoroutine(Trail());
    }

    private IEnumerator Trail()
    {
        while (true)
        {
            trail.transform.position = inputmanager.PrimaryPosition();
            yield return null;

        }

    }
    private void SwipeEnd(Vector2 position, float time)
    {
        StopCoroutine(corutine);

        trail.SetActive(false);
        trail.transform.position = position;
        DetectSwipe();
        endPosition = position;
        endtime = time;
    }
    private void DetectSwipe()
    {
        if (Vector3.Distance(startPosition, endPosition) >= minimumdistance && (endtime - starttime) <= maximumtime)
        {
            Debug.Log("Swipe dected");
            Debug.DrawLine(startPosition, endPosition, Color.red, 5f);
            Vector3 directoin = endPosition - startPosition;
            Vector2 direction2d = new Vector2(directoin.x, directoin.y);
            SwipeDirection(direction2d);
        }
    }
    public void SwipeDirection(Vector2 directoin)
    {
        if(Vector2.Dot(Vector2.up,directoin)> directointhershold)
        {
            Debug.Log("Up");
        }
        if (Vector2.Dot(Vector2.down, directoin) > directointhershold)
        {
            Debug.Log("down");
        }
        if (Vector2.Dot(Vector2.left, directoin) > directointhershold)
        {
            Debug.Log("left");
        }
        if (Vector2.Dot(Vector2.right, directoin) > directointhershold)
        {
            Debug.Log("right");
        }
    }
   
}
