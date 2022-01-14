using UnityEngine;

public class ShipRotate : MonoBehaviour
{
    internal Vector2 pointToLook;

    internal Rigidbody2D rig;

    private void FixedUpdate()
    {
        Vector2 lookDir = pointToLook - (Vector2)transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg -90;

        rig.rotation = angle;
    }
}
