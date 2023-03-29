using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spawnPosZ = 20;
    private float spawnRangeX = 15;
    private float startDelay = 2;
    private float spawnInterval = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRandomAnimal()
    {
        // Choose an animal randomly
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        var selectedAnimal = animalPrefabs[animalIndex];

        // Select a random X spawn position for the animal
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);

        // Effectively spawn the animal in the scene
        Instantiate(selectedAnimal, spawnPos, selectedAnimal.transform.rotation);
    }
}
