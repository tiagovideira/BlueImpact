using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private float health;

    public void TakeDamage(float DamageAmount)
    {
        if(health - DamageAmount <= 0)
        {
            health = 0;
            Debug.Log("Enemy Dead");
        }
        else
        {
            health -= DamageAmount;
            Debug.Log("Enemy Damaged");
        }
    }


}
