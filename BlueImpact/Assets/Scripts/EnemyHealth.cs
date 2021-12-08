using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private float health;

    public SpriteRenderer sprite;

    public void TakeDamage(float DamageAmount)
    {
        if (health - DamageAmount <= 0)
        {
            health = 0;
            Debug.Log("Enemy Dead");
            Destroy(this.gameObject);
        }
        else
        {
            health -= DamageAmount;
            StartCoroutine("ChangeColor");
            Debug.Log("Enemy Damaged");
        }
    }
    private IEnumerator ChangeColor()
    {
        yield return new WaitForSeconds(0.2f);
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprite.color = new Color(255, 255, 255, 255);
    }

}
