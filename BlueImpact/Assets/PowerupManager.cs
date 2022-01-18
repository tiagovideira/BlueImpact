using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    private float enemyCount;
    [SerializeField]
    private GameObject enemies;

    [SerializeField]
    private Transform spawnPoint1;
    [SerializeField]
    private Transform spawnPoint2;


    //Prefabs dos powerups
    public GameObject PowerupPrefab1;
    public GameObject PowerupPrefab2;
    public GameObject PowerupPrefab3;
    public GameObject PowerupPrefab4;
    public GameObject PowerupPrefab5;
    public GameObject PowerupPrefab6;
    public GameObject PowerupPrefab7;
    public GameObject PowerupPrefab8;
    public GameObject PowerupPrefab9;
    public GameObject PowerupPrefab10;

    private GameObject powerupOne;
    private GameObject powerupTwo;



    public void EnemyCountCheck()
    {
        enemyCount = enemies.transform.childCount;

        if (enemyCount <= 1)
        {
            SpawnPowerup();
        }

    }

    private void SpawnPowerup()
    {
        int powerup1;
        int powerup2;
        do//Aleatorização do powerup (Falta tirar das possibilidades os powerups já apanhados)
        {
            powerup1 = Random.Range(1, 10);
            powerup2 = Random.Range(1, 10);
        }
        while (powerup1 == powerup2);

        switch (powerup1)
        {

            case 1:
                powerupOne = Instantiate(PowerupPrefab1, spawnPoint1.position, Quaternion.identity);
                break;

            case 2:
                powerupOne = Instantiate(PowerupPrefab2, spawnPoint1.position, Quaternion.identity);
                break;

            case 3:
                powerupOne = Instantiate(PowerupPrefab3, spawnPoint1.position, Quaternion.identity);
                break;

            case 4:
                powerupOne = Instantiate(PowerupPrefab4, spawnPoint1.position, Quaternion.identity);
                break;

            case 5:
                powerupOne = Instantiate(PowerupPrefab5, spawnPoint1.position, Quaternion.identity);
                break;

            case 6:
                powerupOne = Instantiate(PowerupPrefab6, spawnPoint1.position, Quaternion.identity);
                break;

            case 7:
                powerupOne = Instantiate(PowerupPrefab7, spawnPoint1.position, Quaternion.identity);
                break;

            case 8:
                powerupOne = Instantiate(PowerupPrefab8, spawnPoint1.position, Quaternion.identity);
                break;

            case 9:
                powerupOne = Instantiate(PowerupPrefab9, spawnPoint1.position, Quaternion.identity);
                break;

            case 10:
                powerupOne = Instantiate(PowerupPrefab10, spawnPoint1.position, Quaternion.identity);
                break;

        }

        switch (powerup2)
        {

            case 1:
                powerupTwo = Instantiate(PowerupPrefab1, spawnPoint2.position, Quaternion.identity);
                break;

            case 2:
                powerupTwo = Instantiate(PowerupPrefab2, spawnPoint2.position, Quaternion.identity);
                break;

            case 3:
                powerupTwo = Instantiate(PowerupPrefab3, spawnPoint2.position, Quaternion.identity);
                break;

            case 4:
                powerupTwo = Instantiate(PowerupPrefab4, spawnPoint2.position, Quaternion.identity);
                break;

            case 5:
                powerupTwo = Instantiate(PowerupPrefab5, spawnPoint2.position, Quaternion.identity);
                break;

            case 6:
                powerupTwo = Instantiate(PowerupPrefab6, spawnPoint2.position, Quaternion.identity);
                break;

            case 7:
                powerupTwo = Instantiate(PowerupPrefab7, spawnPoint2.position, Quaternion.identity);
                break;

            case 8:
                powerupTwo = Instantiate(PowerupPrefab8, spawnPoint2.position, Quaternion.identity);
                break;

            case 9:
                powerupTwo = Instantiate(PowerupPrefab9, spawnPoint2.position, Quaternion.identity);
                break;

            case 10:
                powerupTwo = Instantiate(PowerupPrefab10, spawnPoint2.position, Quaternion.identity);
                break;
        }
        powerupOne.transform.SetParent(this.transform);
        powerupTwo.transform.SetParent(this.transform);

    }
}
