using UnityEngine;

public sealed class EnemyManager : ShipManager
{
    [Header("Enemy Settings")]
    [SerializeField] private Transform player;
    [SerializeField] private float shootCooldown = 3f;
    public float damageOnCollision;

    [Header("Enemy Components")]
    EnemyShoot enemyShoot;
    EnemyCollision enemyCollision;

    protected override void OnShipDestroy()
    {
        enemyShoot.DestroyShip();
    }
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        enemyShoot = GetComponent<EnemyShoot>();

        enemyShoot.damage = cannonBallDamage;
        enemyShoot.speed = cannonBallSpeed;
        enemyShoot.move = move;
        enemyShoot.shootColldown = shootCooldown;
        enemyShoot.enemyManager = this;

        enemyCollision = GetComponent<EnemyCollision>();
        enemyCollision.enemyManager = this;
    }
    private void FixedUpdate()
    {
        pointToLook = player.position;

        move.pointToLook = pointToLook;
        shipRotate.pointToLook = pointToLook;
    }
}
