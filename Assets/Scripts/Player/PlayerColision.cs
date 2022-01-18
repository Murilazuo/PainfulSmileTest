using UnityEngine;

public class PlayerColision : MonoBehaviour
{
    [SerializeField] private GameObject explosionFx;

    internal PlayerManager playerManager;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Enemy":
                Instantiate(explosionFx, collision.contacts[0].point,Quaternion.identity);
                
                EnemyManager enemyManager = collision.gameObject.GetComponent<EnemyManager>();

                float damageCollision = enemyManager.damageOnCollision;

                playerManager.TakeDamage(damageCollision);
                enemyManager.TakeDamage(damageCollision);

                break;
            case "CannonBall":
                playerManager.TakeDamage(collision.gameObject.GetComponent<CannonBall>().damage);
                
                Destroy(collision.gameObject);
                break;
        }
    }
}
