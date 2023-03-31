using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        Destroy(other.gameObject);

        var scoreManagerObj = GameObject.Find("ScoreManager");
        var scoreManagerScript = scoreManagerObj.GetComponent<ScoreManager>();

        scoreManagerScript.IncrementAnimalFeeded();

        Debug.Log($"Score: {scoreManagerScript.Score}");
    }
}
