using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies2 : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject enemy2;


    private void OnTriggerEnter2D(Collider2D other)
    {
        enemy1.SetActive(true);
        enemy2.SetActive(true);

    }

}
