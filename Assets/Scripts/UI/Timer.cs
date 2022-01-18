using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    private Text text;
    private GameManager gameManager;
    void Start()
    {
        gameManager = GameManager.instance;
        text = GetComponent<Text>();
    }

    void FixedUpdate()
    {
        string sessionTime = GameStatsController.TimeConverter(gameManager.currentGameSessionTime / 60);
        string maxSessionTime = GameStatsController.TimeConverter(GameManager.gameSession / 60);

        text.text = string.Format("{0} / {1}", sessionTime, maxSessionTime);
    }
}
