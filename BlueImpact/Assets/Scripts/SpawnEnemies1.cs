using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies1 : MonoBehaviour
{
    public GameObject enemy1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        enemy1.SetActive(true);
    }

}
