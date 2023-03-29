using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 10.0f;
    public float xRange = 15.0f;

    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPos = transform.position;

        // Verify if the player is trespassing the left side of the map boundary
        if (currentPos.x < -xRange)
            transform.position = new Vector3(-xRange, currentPos.y, currentPos.z);

        // Verify if the player is trespassing the right side of the map boundary
        if (currentPos.x > xRange)
            transform.position = new Vector3(xRange, currentPos.y, currentPos.z);

        // Get user horizontal input
        horizontalInput = Input.GetAxisRaw("Horizontal");

        // Moves the player
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * speed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position + new Vector3(0, 1.2f, 0), transform.rotation);
        }

    }
}
