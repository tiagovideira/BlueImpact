using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private Transform PlayerTransform;
    private Rigidbody2D rb2d;
    private Vector2 direction;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float playerOffsetX;
    [SerializeField]
    private float playerOffsetY;
    private bool playerToTheLeft;

    private void Start()
    {
        rb2d = this.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        direction = PlayerTransform.position - transform.position;
        FlipSprite();
    }

    private void FixedUpdate()
    {
        rb2d.velocity = new Vector2(direction.x * moveSpeed, direction.y * moveSpeed);

        if (playerToTheLeft)
        {
            transform.position += new Vector3(-playerOffsetX, -playerOffsetY);
        }
        else
        {
            transform.position += new Vector3(playerOffsetX, -playerOffsetY);//
        }
    }

    private void FlipSprite()
    {
        if (PlayerTransform.position.x <= this.transform.position.x)
        {
            transform.localScale = new Vector2(-1, 1);
            playerToTheLeft = false;
        }
        else
        {
            transform.localScale = new Vector2(1, 1);
            playerToTheLeft = true;
        }
    }

}
