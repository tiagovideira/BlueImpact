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
    private Animator animator;

    private void Start()
    {
        Player = GameObject.Find("Player");
        animator = this.GetComponent<Animator>();
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
            timeBeforeAttack = Random.Range(0.2f, 1);

            yield return new WaitForSeconds(timeBeforeAttack);

            Attack();

            attackCooldown = Random.Range(0.2f, 2);
            yield return new WaitForSeconds(attackCooldown);
        }
    }

    private void Attack()
    {
        animator.SetTrigger("Attack");
        Player.GetComponent<PlayerHealth>().TakeDamage(damage);
        Debug.Log("Attack");
    }
}
