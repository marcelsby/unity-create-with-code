using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    private GameObject ui;
    private GameManager gameManagerScript;

    void Start()
    {
        ui = GameObject.Find("UI");
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void RefreshScore()
    {
        var scoreboard = ui.transform.Find("Scoreboard");
        var score = scoreboard.Find("Score");
        var scoreTextMesh = score.GetComponent<TextMeshProUGUI>();
        
        scoreTextMesh.SetText(gameManagerScript.Score.ToString());
    }
}
