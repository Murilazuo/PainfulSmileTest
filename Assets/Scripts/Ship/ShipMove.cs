using UnityEngine;

public abstract class ShipMove : MonoBehaviour
{
    [Header("Components")]
    internal Rigidbody2D rig;

    [Header("Settings (for debug only)")]
    [SerializeField] internal float speed;
    [SerializeField] internal float minDistanceToTarget;

    internal Vector2 pointToLook;
    internal int move;


    protected abstract bool IsMove();

    private void FixedUpdate()
    {
        move = 0;

        if (IsMove() && Vector2.Distance(rig.position, pointToLook) > minDistanceToTarget)
        {
            move = 1;
        }

        rig.velocity = transform.up.normalized * speed * Time.deltaTime * move;
    }
}
