using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    public int hungerToDecrease = 30;

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
        var otherAnimalController = other.gameObject.GetComponent<AnimalController>();
        
        otherAnimalController.DecreaseHunger(hungerToDecrease);

        if (otherAnimalController.currentHunger < 1)
        {
            Destroy(gameObject);
            Destroy(other.gameObject);

            var scoreManagerObj = GameObject.Find("ScoreManager");
            var scoreManagerScript = scoreManagerObj.GetComponent<ScoreManager>();

            scoreManagerScript.IncrementAnimalFeeded();

            Debug.Log($"Score: {scoreManagerScript.Score}");
        }

    }
}
