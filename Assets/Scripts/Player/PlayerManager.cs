using UnityEngine;

[DefaultExecutionOrder(0)]
public sealed class PlayerManager : ShipManager
{
    [Header("Player Components")]
    private Camera cam;
    private PlayerColision playerColision;
    private PlayerShoot playerShoot;

    protected override void OnShipDestroy(){
        foreach(CannonController cannons in playerShoot.cannons){
            cannons.DestroyCannon();
        }
        
    }

    private void Start()
    {
        cam = Camera.main; 

        playerColision = GetComponent<PlayerColision>();
        playerColision.playerManager = this;

        playerShoot = GetComponent<PlayerShoot>();

        playerShoot.InitializrCannons(cannonBallDamage, cannonBallSpeed);
    }
    void FixedUpdate()
    {
        pointToLook = cam.ScreenToWorldPoint(Input.mousePosition);

        shipRotate.pointToLook = pointToLook;
        move.pointToLook = pointToLook;
    }
}
