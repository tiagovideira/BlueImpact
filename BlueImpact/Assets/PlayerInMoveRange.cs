using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInMoveRange : MonoBehaviour
{
    [SerializeField]
    private EnemyMovement EnemyMovement;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("jogador dentro");
        EnemyMovement.enabled = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("jogador fora");
        EnemyMovement.enabled = false;
    }


}
