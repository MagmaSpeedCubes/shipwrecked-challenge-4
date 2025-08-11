using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    private float groundCheckRadius = 1f;

    private Rigidbody2D rb;
    private bool isGrounded;
    private float moveInput;
    private float moveInput2;
    private bool jumpInput;
    private bool jumpInput2;
    private bool jumpInput3;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveInput = Keyboard.current.aKey.isPressed ? -1 :
                    Keyboard.current.dKey.isPressed ? 1 : 0;

        moveInput2 = Keyboard.current.leftArrowKey.isPressed ? -1 :
                     Keyboard.current.rightArrowKey.isPressed ? 1 : 0;

        

        jumpInput = Keyboard.current.spaceKey.wasPressedThisFrame;
        jumpInput2 = Keyboard.current.wKey.wasPressedThisFrame;
        jumpInput3 = Keyboard.current.upArrowKey.wasPressedThisFrame;

        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
        if (moveInput2 != 0)
        {
            rb.linearVelocity = new Vector2(moveInput2 * moveSpeed, rb.linearVelocity.y);
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if ((jumpInput || jumpInput2 || jumpInput3) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }
}