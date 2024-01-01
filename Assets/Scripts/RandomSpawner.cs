using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    // Start is called before the first frame update
    void Start()
    {
        int randEnemy = Random.Range(0, enemyPrefabs.Length);

        Instantiate(enemyPrefabs[randEnemy], transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {

    }
}