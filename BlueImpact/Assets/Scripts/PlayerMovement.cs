using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    private bool canMove = true;
    private bool canDash = true;

    private string dashDirection;

    [SerializeField]
    private Vector2 inputVector;
    private PlayerInputActions playerInputActions;
    [SerializeField]
    private float dashDistance;
    private float lastTapTime = 0;

    [SerializeField]
    private float dashCooldown;
    public Rigidbody2D rb2d;

    private bool facingRight;

    void Start()
    {
        lastTapTime = 0;
    }

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Movement.Enable();
        playerInputActions.Player.Dash.performed += Dash;
        playerInputActions.Player.Dash.Enable();
    }

    private void Dash(InputAction.CallbackContext context)
    {
        if (inputVector.x == 1)
        {
            dashDirection = "Right";
        }
        if (inputVector.x == -1)
        {
            dashDirection = "Left";
        }
        if (canDash)
        {
            StartCoroutine("ExecuteDash");
        }
    }

    void FixedUpdate()
    {
        inputVector = playerInputActions.Player.Movement.ReadValue<Vector2>();
        if (canMove)
        {
            rb2d.velocity = new Vector2(inputVector.x * moveSpeed, inputVector.y * moveSpeed);
        }
    }

    void Update()
    {
        Flip();
    }
    private IEnumerator ExecuteDash()
    {
        Debug.Log("1");
        canMove = false;
        canDash = false;
        if (dashDirection == "Right")
        {
            rb2d.MovePosition(transform.position + new Vector3(1, 0) * dashDistance);
        }
        if (dashDirection == "Left")
        {
            rb2d.MovePosition(transform.position + new Vector3(-1, 0) * dashDistance);
        }
        canMove = true;

        yield return new WaitForSeconds(dashCooldown);

        Debug.Log("2");
        canDash = true;
    }

    private void Flip()
    {
        if (inputVector.x < 0 && !facingRight || inputVector.x > 0 && facingRight)
        {
            facingRight = !facingRight;

            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
}
