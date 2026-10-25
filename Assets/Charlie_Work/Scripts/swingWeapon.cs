using UnityEngine;
using UnityEngine.InputSystem;

public class swingWeapon : MonoBehaviour
{
    public InputAction swing;
    public float speed = 500f;
    public Transform pivotPoint;

    void Start()
    {
        swing.Enable();
    }
    void Update()
    {
        if (swing.IsPressed())
        {
            transform.RotateAround(pivotPoint.position, Vector3.forward, -speed * Time.deltaTime);
        }
    }
}