using UnityEngine;

public class CannonBall : MonoBehaviour
{
    [Header("Settings")]
    public float damage;
    public bool playerCannon;

    [Header("Components")]
    Rigidbody2D rig;
    public void InitializeBall(float newDamage, float newSpeed, Quaternion newRotation,bool newPlayerCannon = false)
    {
        playerCannon = newPlayerCannon;
        rig = GetComponent<Rigidbody2D>();

        transform.rotation = newRotation;

        rig.velocity = transform.up * newSpeed;
    }
    
}
