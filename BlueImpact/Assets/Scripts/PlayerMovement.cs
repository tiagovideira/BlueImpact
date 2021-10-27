using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float dashDistance;
    private float lastTapTime = 0;
    [SerializeField]
    private float dashTime = 0.2f;//Intervalo ao pressionar tecla
    private float dashDelta;
    [SerializeField]
    private float dashCooldown;
    public Rigidbody2D rb2d;
    private Vector3 moveDirection;
    public float moveX;
    public float moveY;
    private bool facingRight;

    void Start()
    {
        lastTapTime = 0;
    }

    void FixedUpdate()
    {
        Movement();
    }

    void Update()
    {
        GetInput();
        Flip();


        // Programação Dash
        dashDelta += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.D) && dashDelta >= dashCooldown)
        {

            if (Input.GetKeyDown(KeyCode.D) && (Time.time - lastTapTime) < dashTime)
            {
                Dash("Right");
            }

            lastTapTime = Time.time;

        }
        if (Input.GetKeyDown(KeyCode.A) && dashDelta >= dashCooldown)
        {

            if (Input.GetKeyDown(KeyCode.A) && (Time.time - lastTapTime) < dashTime)
            {
                Dash("Left");
            }

            lastTapTime = Time.time;

        }
    }

    private void GetInput()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");


        moveDirection = new Vector3(moveX, moveY).normalized;

    }

    private void Movement()
    {
        rb2d.velocity = new Vector3(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
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
        dashDelta = 0;
    }

    private void Flip()
    {
        if (moveX < 0 && !facingRight || moveX > 0 && facingRight)
        {
            facingRight = !facingRight;

            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }

}
