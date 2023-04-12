using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public delegate void ScoreChangedDelegate(int newScore);
    public static event ScoreChangedDelegate ScoreChangedEvent;

    private int obstaclesPassed = 0;
    private int Score { get { return obstaclesPassed; } }

    public void IncrementObstaclesPassed()
    {
        obstaclesPassed += 1;
        ScoreChangedEvent.Invoke(Score);
    }
}
