using UnityEngine;

[DefaultExecutionOrder(0)]
public sealed class PlayerManager : ShipManager
{
    [Header("Player Components")]
    Camera cam;
    PlayerColision playerColision;
    PlayerShoot playerShoot;

    protected override void OnShipDestroy(){
    }

    private void Start()
    {
        cam = Camera.main; 

        playerColision = GetComponent<PlayerColision>();
        playerColision.playerManager = this;

        playerShoot = GetComponent<PlayerShoot>();
        playerShoot.damage = cannonBallDamage;
        playerShoot.speed = cannonBallSpeed; 
    }
    void FixedUpdate()
    {
        pointToLook = cam.ScreenToWorldPoint(Input.mousePosition);

        shipRotate.pointToLook = pointToLook;
        move.pointToLook = pointToLook;
    }
}
