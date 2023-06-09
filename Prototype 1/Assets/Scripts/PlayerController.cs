using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 15.0f;
    private float turnSpeed = 35.0f;
    private float horizontalInput;
    private float forwardInput;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Get the player input
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        // We move the vehicle forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

        // Turn the vehicle only if its moving forward or backward
        if (forwardInput != 0)
        {
            // Make the rear movement feels like in real life driving 
            float calculatedTurnSpeed = forwardInput < 0 ? turnSpeed * -1 : turnSpeed;

            // Turn the vehicle
            transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput, Space.Self);
        }
    }
}
