using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    [SerializeField][TextArea]private string wonText, loseText, scoreText, timeText;
    
    [Header("Components")]
    private Animator animator;
    [SerializeField] private Text endGameText;
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        GameManager.OnGameEnd += SetEndGamePanel;
    }
    private void OnDisable()
    {
        GameManager.OnGameEnd -= SetEndGamePanel;
    }
    void SetEndGamePanel(GameStats gameStats)
    {
        string firtText = "";
        if (gameStats.won)
        {
            firtText = wonText;
        }
        else
        {
            firtText = loseText;
        }

        endGameText.text = firtText + "\n" + scoreText + string.Format(" {0}.\n", gameStats.score) + 
        timeText + string.Format(" {0}.",GameStatsController.TimeConverter(gameStats.gameSession/60));

        animator.SetTrigger("EndGame");
    }

    void StopGame()
    {
        Time.timeScale = 0;
    }
}
