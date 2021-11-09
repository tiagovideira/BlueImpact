using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public float PunchDamage;
    public float KickDamage;

    public float PunchDelay;
    public float KickDelay;

    public EnemyDetection PunchRange;
    public EnemyDetection KickRange;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))//Punch
        {
            Invoke("Punch", PunchDelay);

        }

        if (Input.GetMouseButtonDown(1))//Pontapé básico
        {
            Invoke("Kick", KickDelay);
        }
    }

    private void Punch()
    {
        Debug.Log("Punch");

        foreach (GameObject Enemy in PunchRange.EnemyList)
        {
            Enemy.GetComponent<EnemyHealth>().TakeDamage(PunchDamage);
        }
    }

    private void Kick()
    {
        Debug.Log("Kick");
        foreach (GameObject Enemy in KickRange.EnemyList)
        {
            Enemy.GetComponent<EnemyHealth>().TakeDamage(KickDamage);
        }
    }
}