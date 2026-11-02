using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    private float speed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    Animator animator; 
    SpriteRenderer spriteRenderer; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); 
        spriteRenderer = GetComponent<SpriteRenderer>(); 
    }

    void Update()
    {
        rb.linearVelocity = movement * speed;
        UpdateAnimations(); 
    }

    void UpdateAnimations()
    {
        animator.SetFloat("X", movement.x);
        animator.SetFloat("Y", movement.y);
        if (movement.x < 0) spriteRenderer.flipX = true;
        else if (movement.x >0) spriteRenderer.flipX = false;
    }

    public void Move(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }
}
