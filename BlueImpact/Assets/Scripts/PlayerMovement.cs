using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private Vector2 inputVector;
    private PlayerInputActions playerInputActions;
    [SerializeField]
    private float dashDistance;
    private float lastTapTime = 0;
    [SerializeField]
    private float dashTime = 0.2f;//Intervalo ao pressionar tecla
    private float dashDelta;
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
        playerInputActions.Player.Dash.Enable();
        playerInputActions.Player.Dash.performed += Dash;
    }

    private void Dash(InputAction.CallbackContext context)
    {
        Debug.Log("Dash");
        if (inputVector.x == 1)
        {
            Dash("Right");
        }
        else if (inputVector.x == -1)
        {
            Dash("Left");
        }
    }

    void FixedUpdate()
    {
        inputVector = playerInputActions.Player.Movement.ReadValue<Vector2>();
        rb2d.velocity = new Vector2(inputVector.x * moveSpeed, inputVector.y * moveSpeed);
    }

    void Update()
    {
        Flip();
    }
    private void Dash(string Direction)
    {
        if (Direction == "Right")
        {
            rb2d.MovePosition(transform.position + new Vector3(1, 0) * dashDistance);
        }
        if (Direction == "Left")
        {
            rb2d.MovePosition(transform.position + new Vector3(-1, 0) * dashDistance);
        }
        // dashDelta = 0;
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
