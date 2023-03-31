using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float verticalInput;
    public float speed = 10.0f;
    public float xRange = 17.0f;
    public float zMaxPos = 15.0f;
    public float zMinPos = 0.0f;
    private int lives = 3;

    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var currentPos = transform.position;

        HandleHorizontalMovement(currentPos);
        HandleVerticalMovement(currentPos);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position + new Vector3(0, 1.2f, 1.0f), transform.rotation);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (lives == 0)
        {
            Debug.Log("Game over!");
        }
        else
        {
            lives--;
            Debug.Log($"Remaining lives: {lives}");
        }
    }

    void HandleHorizontalMovement(Vector3 currentPos)
    {
        // Verify if the player is trespassing the left side of the map boundary
        if (currentPos.x < -xRange)
            transform.position = new Vector3(-xRange, currentPos.y, currentPos.z);

        // Verify if the player is trespassing the right side of the map boundary
        if (currentPos.x > xRange)
            transform.position = new Vector3(xRange, currentPos.y, currentPos.z);

        // Get user horizontal input
        verticalInput = Input.GetAxisRaw("Horizontal");

        // Moves the player
        transform.Translate(Vector3.right * Time.deltaTime * verticalInput * speed);
    }

    void HandleVerticalMovement(Vector3 currentPos)
    {
        // Verify if the player is trespassing the bottom map boundary
        if (currentPos.z < zMinPos)
            transform.position = new Vector3(currentPos.x, currentPos.y, zMinPos);

        // Verify if the player is trespassing the top map boundary
        if (currentPos.z > zMaxPos)
            transform.position = new Vector3(currentPos.x, currentPos.y, zMaxPos);

        // Get user horizontal input
        verticalInput = Input.GetAxisRaw("Vertical");

        // Moves the player
        transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * speed);
    }
}
