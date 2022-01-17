using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static float timeToSpanwEnemy = 2f;
    public static float gameSession = 180f;

    [SerializeField] private GameObject[] enemyPrefab;
    [SerializeField] private Transform[] spawnSpot;

    public float CurrentGameSession = 0;

    bool endGame = false;

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private void Update()
    {
        if (CurrentGameSession >= gameSession && endGame)
        {
            endGame = true;
        }else if (endGame == false)
        {
            CurrentGameSession += Time.deltaTime;
        }
    }
    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            int percentage = Random.Range(0,100);
            int spawnSpotId = Random.Range(0,spawnSpot.Length);
            int enemyId = 0;

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

}
