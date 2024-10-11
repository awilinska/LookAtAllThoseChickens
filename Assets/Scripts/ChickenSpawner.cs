using UnityEngine;
using System;

public class ChickenSpawner : MonoBehaviour
{
    public GameObject chickenPrefab;
    public GameObject chickPrefab;
    public Transform spawnPoint;
    public int chickens;
    public int chicks;

    void Start() {
        chickens = Math.Abs(PlayerPrefs.GetInt("playerChickens", 0));
        chicks = Math.Abs(PlayerPrefs.GetInt("playerChicks", 0));

        for (int i = 1; i <= chickens; i++) {
            Instantiate(chickenPrefab, spawnPoint.position, spawnPoint.rotation);
        }

        for (int i = 1; i <= chicks; i++) {
            Instantiate(chickPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }

    public void SpawnChicken()
    {
        Instantiate(chickenPrefab, spawnPoint.position, spawnPoint.rotation);
    }
    
    public void SpawnChick()
    {
        Instantiate(chickPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}