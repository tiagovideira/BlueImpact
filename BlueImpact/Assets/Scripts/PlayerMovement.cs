using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    public Rigidbody2D rb2d;
    private Vector2 moveDirection;
    public float moveX;
    public float moveY;
    private bool facingRight;

    void FixedUpdate()
    {
        Movement();
    }

    void Update()
    {
        GetInput();
        Flip();
    }

    private void GetInput()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY);
    }

    private void Movement()
    {
        rb2d.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    private void Flip()
    {
        if(moveX < 0 && !facingRight || moveX > 0 && facingRight)
        {
            facingRight = !facingRight;
            
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }

}
