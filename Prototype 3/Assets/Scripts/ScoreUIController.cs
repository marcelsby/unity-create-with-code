using UnityEngine;
using TMPro;

public class ScoreUIController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    void Update()
    {
        ScoreManager.ScoreChangedEvent += UpdateScoreText;
    }

    private void UpdateScoreText(int newScore)
    {
        scoreText.text = newScore.ToString();
    }
}
