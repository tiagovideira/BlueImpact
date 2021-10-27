using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public float PunchDamage;
    public float KickDamage;

    public EnemyDetection PunchRange;
    public EnemyDetection KickRange;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Punch(PunchDamage);
        }
        if (Input.GetMouseButtonDown(1))
        {
            Kick(KickDamage);
        }
    }

    private void Punch(float PunchDamage)
    {
        foreach (GameObject Enemy in PunchRange.EnemyList)
        {
            Enemy.GetComponent<EnemyHealth>().TakeDamage(PunchDamage);
        }
    }

    private void Kick(float KickDamage)
    {
        foreach (GameObject Enemy in KickRange.EnemyList)
        {
            Enemy.GetComponent<EnemyHealth>().TakeDamage(KickDamage);
        }
    }
}