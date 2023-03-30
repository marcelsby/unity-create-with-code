using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private float lastDogSpawnCall;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Time.time - lastDogSpawnCall >= 0.5) {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
                lastDogSpawnCall = Time.time;
            }
        }
    }
}
