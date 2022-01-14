using UnityEngine;

public class PlayerColision : MonoBehaviour
{
    [SerializeField] private GameObject explosionFx;

    internal PlayerManager playerManager;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Chaser":
                Instantiate(explosionFx, collision.contacts[0].point,Quaternion.identity);
                EnemyCollision(collision);
                break;

            case "Shooter":
                Instantiate(explosionFx, collision.contacts[0].point, Quaternion.identity);
                EnemyCollision(collision);
                break;
            case "CannonBall":
                Instantiate(explosionFx, collision.contacts[0].point, Quaternion.identity);
                playerManager.TakeDamage(collision.gameObject.GetComponent<CannonBall>().damage);
                Destroy(collision.gameObject);
                break;
        }
    }
    
    void EnemyCollision(Collision2D coll)
    {
        EnemyManager enemyManager = coll.gameObject.GetComponent<EnemyManager>();

        float damageCollision = enemyManager.damageOnCollision;

        playerManager.TakeDamage(damageCollision);
        enemyManager.TakeDamage(damageCollision);
    }
}
