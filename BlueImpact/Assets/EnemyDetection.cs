using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public List<GameObject> EnemyList = new List<GameObject>();
    private void OnTriggerEnter2D(Collider2D other)
    {
        EnemyList.Add(other.gameObject);
        Debug.Log("Inimigo Entrou");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        EnemyList.Remove(other.gameObject);
        Debug.Log("Inimigo Saiu");

    }
}
