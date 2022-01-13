using UnityEngine;

public abstract class Move : MonoBehaviour
{
    [Header("Components")]
    internal Rigidbody2D rig;
    internal Camera cam;

    [Header("Settings (For Debug Only)")]
    [SerializeField] internal float speed;
    [SerializeField] internal float minDistanceToTarget;

    internal Vector2 pointToLook;

    protected abstract bool IsMove();
    
    private void FixedUpdate()
    {
        int move = 0;

        if (IsMove() && Vector2.Distance(rig.position, pointToLook) > minDistanceToTarget)
        {
            move = 1;
        }

        rig.velocity = transform.up.normalized * speed * Time.deltaTime * move;
    }
}
