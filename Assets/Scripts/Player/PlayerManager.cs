using UnityEngine;

public sealed class PlayerManager : ShipManager
{
    Camera cam;
    private void Start()
    {
        cam = Camera.main; 
    }
    void FixedUpdate()
    {
        pointToLook = cam.ScreenToWorldPoint(Input.mousePosition);

        shipRotate.pointToLook = pointToLook;
        move.pointToLook = pointToLook;
    }
}
