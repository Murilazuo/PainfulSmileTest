using UnityEngine;

public sealed class PlayerManager : ShipManager
{
    Camera cam;
    PlayerColision playerColision;
    PlayerShoot playerShootController;
    private void Start()
    {
        cam = Camera.main; 

        playerColision = GetComponent<PlayerColision>();
        playerColision.playerManager = this;

        playerShootController = GetComponent<PlayerShoot>();
        playerShootController.damage = cannonBallDamage;
        playerShootController.speed = cannonBallSpeed; 
    }
    void FixedUpdate()
    {
        pointToLook = cam.ScreenToWorldPoint(Input.mousePosition);

        shipRotate.pointToLook = pointToLook;
        move.pointToLook = pointToLook;
    }
}
