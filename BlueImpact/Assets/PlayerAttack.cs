using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public float PunchDamage;
    public EnemyDetection EnemyDetection;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Punch(PunchDamage);
        }

    }

    private void Punch(float PunchDamage)
    {
        foreach (GameObject Enemy in EnemyDetection.EnemyList)
        {
            Enemy.GetComponent<EnemyHealth>().TakeDamage(PunchDamage);
        }
    }
}