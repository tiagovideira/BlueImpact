using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    private PlayerDetection playerDetection;

    [SerializeField]
    private float timeBeforeAttack;
    [SerializeField]
    private float attackCooldown;
    [SerializeField]
    private float damage;
    private bool CanAttack;

    private GameObject Player;

    private void Start()
    {
        Player = GameObject.Find("Player");
    }
    private void Update()
    {
        if (playerDetection.PlayerInAttackRange && !CanAttack)
        {
            StartCoroutine("EnemyAttackCoroutine");
            CanAttack = true;
        }
        else if (!playerDetection.PlayerInAttackRange)
        {
            StopCoroutine("EnemyAttackCoroutine");
            CanAttack = false;
        }
    }

    private IEnumerator EnemyAttackCoroutine()
    {
        while (true)
        {
            Debug.Log("Começou coroutine de ataque");

            yield return new WaitForSeconds(timeBeforeAttack);

            Attack();

            yield return new WaitForSeconds(attackCooldown);
        }
    }

    private void Attack()
    {
        Player.GetComponent<PlayerHealth>().TakeDamage(damage);
        Debug.Log("Attack");
    }
}
