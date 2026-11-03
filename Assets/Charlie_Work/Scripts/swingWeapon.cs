using UnityEngine;
using UnityEngine.InputSystem;

public class swingWeapon : MonoBehaviour
{
    public InputAction swing;
    public InputAction moveLeft;
    public InputAction moveRight;
    public float speed = 500f;
    public Transform pivotPoint;
    public bool swinging = false;
    public bool movingRight = true;
    public bool movingLeft = false;
    public float degreesRotated = 0f;

    void Start()
    {
        swing.Enable();
        moveLeft.Enable();
        moveRight.Enable();
    }
    void Flip()
    {
        movingRight = !movingRight;

        transform.RotateAround(pivotPoint.position, Vector3.up, 180f);
    }
    void Update()
    {
        if (swing.WasPressedThisFrame()) swinging = !swinging;

        if (swinging == true)
        {
            // Stops sword from pausing
            swing.Disable();

            // Mathf.Min used so speed doesn't overshoot 360 degrees
            float degrees = Mathf.Min(speed * Time.deltaTime, 360f - degreesRotated);
            transform.RotateAround(pivotPoint.position, Vector3.forward, -degrees);
            degreesRotated += degrees;

            // Makes sword spin while rotating
            // Rotating by degrees allows the sword to end in its original position
            if(movingRight) transform.Rotate(0f, 0f, -degrees);
            else transform.Rotate(0f, 0f, degrees);

            // Resets swing variables
            if (degreesRotated >= 360)
            {
                swing.Enable();
                degreesRotated = 0;
                swinging = false;
            }
        }
        else
        {
            if (moveRight.IsPressed() && !movingRight) Flip();
            else if (moveLeft.IsPressed() && movingRight) Flip();
        }
    }
}