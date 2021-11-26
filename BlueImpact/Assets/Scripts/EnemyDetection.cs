using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public List<GameObject> EnemyList = new List<GameObject>();
    public List<GameObject> DoorList = new List<GameObject>();
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            EnemyList.Add(other.gameObject);
            Debug.Log("Inimigo Entrou");
        }

        if (other.tag == "Door")
        {
            DoorList.Add(other.gameObject);
            Debug.Log("Door enter");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            EnemyList.Remove(other.gameObject);
            Debug.Log("Inimigo Saiu");
        }

        if (other.tag == "Door")
        {
            DoorList.Remove(other.gameObject);
            Debug.Log("Door exit");
        }
    }
}
