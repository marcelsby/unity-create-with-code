using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlanePropellerX : MonoBehaviour
{
    public GameObject parentScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get the plane Transform to use it speed
        float parentSpeed = transform.parent.GetComponent<PlayerControllerX>().speed;
        

        // Rotate the propeller
        transform.Rotate(Vector3.forward * Time.deltaTime * parentSpeed * 100, Space.Self);
    }
}
