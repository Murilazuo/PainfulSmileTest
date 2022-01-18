using UnityEngine;

public class CannonBall : MonoBehaviour
{

    [Header("Settings")]
    public float damage;
    public bool playerCannon;
    [SerializeField] private float timeToDestroy = 3f;
    [SerializeField] private GameObject explosion;

    [Header("Components")]
    Rigidbody2D rig;
    public void InitializeBall(float newDamage, float newSpeed, Quaternion newRotation,bool newPlayerCannon = false)
    {
        playerCannon = newPlayerCannon;
        rig = GetComponent<Rigidbody2D>();

        transform.rotation = newRotation;

        rig.velocity = transform.up * newSpeed;
        
        damage = newDamage;

        Destroy(gameObject, timeToDestroy);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.collider.tag)
        {
            case "Ground":
            case "CannonBall":
                Destroy(gameObject);
                break;
        }
    }
    private void OnDestroy()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
    }
}
