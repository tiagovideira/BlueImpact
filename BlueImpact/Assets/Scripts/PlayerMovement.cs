using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

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
    private PlayerAttack playerAttack;

    [SerializeField]
    private float dashDistance;

    [SerializeField]
    private float dashCooldown;
    [SerializeField]
    private float dashTime;
    public Rigidbody2D rb2d;

    private bool facingRight;

    private Animator animator;

    [SerializeField]
    private SoundManager soundManager;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Movement.Enable();
        playerInputActions.Player.Menu.Enable();
        playerInputActions.Player.Menu.performed += Menu;
        playerInputActions.Player.Dash.performed += Dash;
        playerInputActions.Player.Dash.Enable();
        animator = this.GetComponent<Animator>();

        playerAttack = this.GetComponent<PlayerAttack>();
    }

    private void Dash(InputAction.CallbackContext context)
    {
        if (canDash)
        {
            StartCoroutine("ExecuteDash");
        }
    }

    private void Menu(InputAction.CallbackContext context)
    {
        SceneManager.LoadScene(0);
    }

    void FixedUpdate()
    {
        inputVector = playerInputActions.Player.Movement.ReadValue<Vector2>();
        if (canMove && playerAttack.canAttack)
        {
            rb2d.velocity = new Vector2(inputVector.x * moveSpeed, inputVector.y * moveSpeed);
        }
    }

    void Update()
    {
        Flip();
        if (inputVector.magnitude > 0 && canMove)
        {
            animator.SetBool("IsMoving", true);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }
    }
    private IEnumerator ExecuteDash()
    {
        canMove = false;
        canDash = false;



        rb2d.AddForce(new Vector2(inputVector.x * dashDistance, 0), ForceMode2D.Impulse);
        if (inputVector.x != 0)
        {
            soundManager.PlaySound("Dash");
            animator.SetTrigger("Dash");
        }
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

    public void ActivatePowerup3()//MoveSpeed up 15%
    {
        moveSpeed = moveSpeed * 1.15f;
    }
}
