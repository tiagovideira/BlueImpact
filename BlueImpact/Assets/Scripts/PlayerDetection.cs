using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    [SerializeField]
    private EnemyMovement enemyMovement;
    public bool PlayerInAttackRange;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PlayerHitBox")
        {
            PlayerInAttackRange = true;
            Debug.Log("Pode atacar player");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "PlayerHitBox")
        {
            PlayerInAttackRange = false;
            enemyMovement.StopCoroutine("FollowPlayer");
            enemyMovement.StartCoroutine("FollowPlayer");
            Debug.Log("Deixa de poder atacar player");
        }
    }
}