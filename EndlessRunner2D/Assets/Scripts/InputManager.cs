
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : _Singelton<InputManager>
{
    #region Events
    public delegate void StartTouch(Vector2 position, float time);
    public event StartTouch OnstartTouch;
    public delegate void EndTouch(Vector2 position, float time);
    public event StartTouch OnendTouch;


    #endregion
    private TouchControl touchcontrols;
    private Camera mainCamera;
    private void Awake()
    {
        mainCamera = Camera.main;
        touchcontrols = new TouchControl();
    }
    private void OnEnable()
    {
        touchcontrols.Enable();
    }
    private void OnDisable()
    {
        touchcontrols.Disable();
    }
    private void Start()
    {
        touchcontrols.Touch.PrimaryContact.started += ctx => StartTouchPrimary(ctx);
        touchcontrols.Touch.PrimaryContact.canceled += ctx => EndTouchPrimary(ctx);

    }
    private void StartTouchPrimary(InputAction.CallbackContext context)
    {
        if (OnstartTouch != null) OnstartTouch(Utilits.ScreenToWorld(mainCamera,touchcontrols.Touch.PrimaryPosition.ReadValue<Vector2>()),(float)context.startTime);
    }
    private void EndTouchPrimary(InputAction.CallbackContext context)
    {
        if (OnendTouch != null) OnendTouch(Utilits.ScreenToWorld(mainCamera, touchcontrols.Touch.PrimaryPosition.ReadValue<Vector2>()), (float)context.time);
    }
    public Vector2 PrimaryPosition()
    {
        return Utilits.ScreenToWorld(mainCamera, touchcontrols.Touch.PrimaryPosition.ReadValue<Vector2>());
    }
}
