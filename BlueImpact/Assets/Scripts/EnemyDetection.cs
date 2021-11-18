using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public List<GameObject> EnemyList = new List<GameObject>();
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Door")
        {
            Debug.Log("Porta");
            other.gameObject.GetComponent<FirstDoor>().CanDestroyDoor = true;
        }
        else
        {
            EnemyList.Add(other.gameObject);
            Debug.Log("Inimigo Entrou");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Door")
        {
            Debug.Log(" Xau Porta");
            other.gameObject.GetComponent<FirstDoor>().CanDestroyDoor = false;
        }
        else
        {
            EnemyList.Remove(other.gameObject);
            Debug.Log("Inimigo Saiu");
        }


    }
}
