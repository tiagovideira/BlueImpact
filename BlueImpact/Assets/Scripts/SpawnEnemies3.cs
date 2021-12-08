using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies3 : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;



    private void OnTriggerEnter2D(Collider2D other)
    {
        enemy1.SetActive(true);
        enemy2.SetActive(true);
        enemy3.SetActive(true);


    }

}
