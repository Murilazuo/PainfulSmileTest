using UnityEngine;

public sealed class PlayerManager : ShipManager
{
    Camera cam;
    PlayerColision playerColision;
    private void Start()
    {
        cam = Camera.main; 
        playerColision = GetComponent<PlayerColision>();
        playerColision.playerManager = this;
    }
    void FixedUpdate()
    {
        pointToLook = cam.ScreenToWorldPoint(Input.mousePosition);

        shipRotate.pointToLook = pointToLook;
        move.pointToLook = pointToLook;
    }
}
