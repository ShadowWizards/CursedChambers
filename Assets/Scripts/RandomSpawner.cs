using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    // Start is called before the first frame update
    void Awake()
    {
        // Selects a random number between how many enemy prefabs there are
        int randEnemy = Random.Range(0, enemyPrefabs.Length);

        // Spawns the enemy on the transform location
        Instantiate(enemyPrefabs[randEnemy], transform.position, transform.rotation);
    }
}