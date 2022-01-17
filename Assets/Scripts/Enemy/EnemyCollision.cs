using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    internal EnemyManager enemyManager;
  
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("CannonBall"))
        {
            CannonBall cannonBall = collision.collider.GetComponent<CannonBall>();
            
            enemyManager.TakeDamage(cannonBall.damage);

            Destroy(cannonBall.gameObject);
        }
    }
}
