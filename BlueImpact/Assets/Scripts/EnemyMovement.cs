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

    private float playerOffsetX;
    private float playerOffsetY;

    private bool playerToTheLeft;

    public bool MustFollowPlayer;
    [SerializeField]
    private float TimeFollowing;
    [SerializeField]
    private float TimeBetweenFollows;

    private float playerX;
    private float playerY;

    [SerializeField]
    private PlayerDetection playerDetection;

    void Awake()
    {
        StartCoroutine("FollowPlayer");
    }

    private void Start()
    {
        rb2d = this.GetComponent<Rigidbody2D>();
        MustFollowPlayer = true;
    }

    private void Update()
    {
        FlipEnemy();
        if (PlayerTransform.position.y < this.transform.position.y)
        {
            this.GetComponent<SpriteRenderer>().sortingOrder = 74;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().sortingOrder = 76;
        }

    }

    private void FixedUpdate()
    {
        if (MustFollowPlayer && playerDetection.PlayerInAttackRange == false)
        {
            rb2d.velocity = new Vector2(direction.x * moveSpeed, direction.y * moveSpeed);
        }
        else
        {
            rb2d.velocity = new Vector2(0, 0);
        }

    }

    private void FlipEnemy()
    {
        if (PlayerTransform.position.x <= this.transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            playerToTheLeft = false;
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            playerToTheLeft = true;
        }
    }

    private void GetPlayerPosition()
    {
        direction = (PlayerTransform.position - new Vector3(playerOffsetX, playerOffsetY, 0)) - transform.position;
        playerX = PlayerTransform.position.x;
        playerY = PlayerTransform.position.y;
        direction.Normalize();
    }

    public IEnumerator FollowPlayer()
    {
        while (true)
        {
            GetPlayerPosition();
            MustFollowPlayer = true;
            TimeFollowing = Random.Range(1, 3);

            yield return new WaitForSeconds(TimeFollowing);

            MustFollowPlayer = false;
            TimeFollowing = Random.Range(1, 4);

            yield return new WaitForSeconds(TimeBetweenFollows);
        }
    }

    public void DisableMovement()
    {
        rb2d.velocity = new Vector2(0, 0);
        this.enabled = false;
    }

}
