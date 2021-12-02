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

    [SerializeField]
    private float dashCooldown;
    [SerializeField]
    private float dashTime;
    public Rigidbody2D rb2d;

    private bool facingRight;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Movement.Enable();
        playerInputActions.Player.Dash.performed += Dash;
        playerInputActions.Player.Dash.Enable();
    }

    private void Dash(InputAction.CallbackContext context)
    {
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
        canMove = false;
        canDash = false;

        rb2d.AddForce(new Vector2(inputVector.x * dashDistance, inputVector.y * dashDistance), ForceMode2D.Impulse); 
        yield return new WaitForSeconds(dashTime);
        
        canMove = true;

        yield return new WaitForSeconds(dashCooldown - dashTime);

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
