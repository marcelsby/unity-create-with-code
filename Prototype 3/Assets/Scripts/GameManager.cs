using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private PlayerController playerControllerScript;
    private UIManager uiManagerScript;

    private int obstaclesPassed = 0;
    public int Score { get { return obstaclesPassed; } }
    public bool isGameOver;

    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        uiManagerScript = GameObject.Find("UI").GetComponent<UIManager>();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void IncrementObstaclesPassed()
    {
        obstaclesPassed += 1;
        uiManagerScript.RefreshScore();
    }
}
