using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    EnemyManager enemyManager;
    private void Start()
    {
        enemyManager = GetComponent<EnemyManager>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("CannonBall"))
        {
            CannonBall cannonBall = collision.collider.GetComponent<CannonBall>();
            
            if (cannonBall.playerCannon)
            {
                enemyManager.TakeDamage(cannonBall.damage);
            }
        }
    }
}
