using UnityEngine;

public abstract class Move : MonoBehaviour
{
    [Header("Components")]
    internal Rigidbody2D rig;

    [Header("Settings (for debug only)")]
    [SerializeField] internal float speed;
    [SerializeField] internal float minDistanceToTarget;

    internal Vector2 pointToLook;

    protected abstract bool isMove();

    private void FixedUpdate()
    {
        int move = 0;

        if (isMove() && Vector2.Distance(rig.position, pointToLook) > minDistanceToTarget)
        {
            move = 1;
        }

        rig.velocity = transform.up.normalized * speed * Time.deltaTime * move;
    }
}
