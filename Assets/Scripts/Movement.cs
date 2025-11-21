using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;

    [Header("State")]
    public bool isWalking = false;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Read input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Walking state
        isWalking = movement.sqrMagnitude > 0.01f;

        // Send values to Animator
        anim.SetBool("IsWalking", isWalking);
        anim.SetFloat("MoveX", movement.x);
        anim.SetFloat("MoveY", movement.y);

        // Flip sprite based on horizontal movement
        if (movement.x < 0)
            sr.flipX = true;      
        else if (movement.x > 0)
            sr.flipX = false;     
    }

    void FixedUpdate()
    {
        // Move character
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }
}