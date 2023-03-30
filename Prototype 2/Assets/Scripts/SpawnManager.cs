using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float topSpawnPosZ = 20;
    private float topSpawnRangeX = 15;
    private float horizontalSpawnPosX = 30;
    private float horizontalSpawnMinZ = -2;
    private float horizontalSpawnMaxZ = 13;
    private float startDelay = 2;
    private float spawnInterval = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimals", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRandomAnimals()
    {
        SpawnRandomAnimal(ScreenCorner.Top);
        SpawnRandomAnimal(ScreenCorner.Left);
        SpawnRandomAnimal(ScreenCorner.Right);
    }

    void SpawnRandomAnimal(ScreenCorner corner)
    {
        // Get random animal prefab
        var selectedAnimal = GetRandomAnimal();

        // Get a random position based in the passed corner
        var spawnPos = GetRandomSpawnPosition(corner);

        // Set the correct rotation based in the passed corner
        var rotation = GetRotationByCorner(corner);

        // Effectively spawn the animal in the scene
        Instantiate(selectedAnimal, spawnPos, rotation);
    }

    private Quaternion GetRotationByCorner(ScreenCorner corner)
    {
        float y;

        switch (corner)
        {
            case ScreenCorner.Top:
                y = 180.0f;
                break;

            case ScreenCorner.Left:
                y = 90.0f;
                break;

            case ScreenCorner.Right:
                y = -90.0f;
                break;

            default:
                y = 0.0f;
                break;
        }
     
     
        // selectedAnimal.transform.Rotate(new Vector3(0, y, 0), Space.Self);
        
        return Quaternion.Euler(0, y, 0);
    }

    private Vector3 GetRandomSpawnPosition(ScreenCorner corner)
    {
        switch (corner)
        {
            case ScreenCorner.Top:
                return new Vector3(Random.Range(-topSpawnRangeX, topSpawnRangeX), 0, topSpawnPosZ);

            case ScreenCorner.Left:
                return new Vector3(-horizontalSpawnPosX, 0, Random.Range(horizontalSpawnMinZ, horizontalSpawnMaxZ));

            default: // ScreenCorner.Right case
                return new Vector3(horizontalSpawnPosX, 0, Random.Range(horizontalSpawnMinZ, horizontalSpawnMaxZ));
        }
    }

    private GameObject GetRandomAnimal()
    {
        // Choose an animal randomly
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        return animalPrefabs[animalIndex];
    }

    private enum ScreenCorner
    {
        Top,
        Left,
        Right,
    }
}
