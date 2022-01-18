using System.Collections;
using System;
using UnityEngine;

public struct GameStats
{
    public int score;
    public float gameSession;
    public bool won;
}
[DefaultExecutionOrder(-3)]
public class GameManager : MonoBehaviour
{
    [Header("Game Settings")]
    public static float timeToSpanwEnemy = 10f;
    public static float gameSession = 180f;

    [Header("Enemys")]
    [SerializeField] private GameObject[] enemyPrefab;
    [SerializeField] private Transform[] spawnSpot;

    [Header("Game Score")]
    public float currentGameSessionTime = 0;
    public int score = 0;
    public static 
    bool endGame = false;
    private ScoreUi scoreUi;

    public static event Action<GameStats> OnGameEnd;


    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        scoreUi = FindObjectOfType<ScoreUi>();

        StartCoroutine(SpawnEnemy());
    }
    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreUi.UpdateScore(score);
    }
    private void Update()
    {
        if (endGame) return;

        if (currentGameSessionTime >= gameSession)
        {
            WonGame();
        }else
        {
            currentGameSessionTime += Time.deltaTime;
        }
    }
    private IEnumerator SpawnEnemy()
    {
        while (!endGame)
        {
            int percentage = UnityEngine.Random.Range(0,100);
            int spawnSpotId = UnityEngine.Random.Range(0,spawnSpot.Length);
            int enemyId;

            if(percentage > 50)
            {
                enemyId = 0;
            }else
            {
                enemyId = 1;
            }

            Instantiate(enemyPrefab[enemyId],spawnSpot[spawnSpotId].position,Quaternion.identity);
            
            yield return new WaitForSeconds(timeToSpanwEnemy);
        }
    }
    void WonGame()
    {
        GameStats gameStats = new GameStats();

        currentGameSessionTime = gameSession;

        gameStats.won = true;

        EndGame(gameStats);
    }
    public void LoseGame()
    {
        GameStats gameStats = new GameStats();

        gameStats.won = false;

        EndGame(gameStats);
    }

    private void EndGame(GameStats gameStats)
    {
        gameStats.gameSession = currentGameSessionTime;
        gameStats.score = score;
        
        OnGameEnd(gameStats);
        endGame = true;
        
        StopCoroutine(SpawnEnemy());
    }
}
