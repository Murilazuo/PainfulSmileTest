using UnityEngine;

public class EnemyManager : ShipManager
{
    [Header("Enemy Settings")]
    [SerializeField] private Transform player;
    [SerializeField] private float shootCooldown = 3f;
    [SerializeField] private int scoreDrop = 1;
    public float damageOnCollision;

    [Header("Enemy Components")]
    private EnemyShoot enemyShoot;
    private EnemyCollision enemyCollision;
    private GameManager gameManager;

    protected override void OnShipDestroy()
    {
        if(enemyShoot != null)
        {
            enemyShoot.DestroyCannon();
        }

        gameManager.AddScore(scoreDrop);
    }
    private void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player")?.transform;

        if(GetComponent<EnemyShoot>() != null)
        {
            enemyShoot = GetComponent<EnemyShoot>();

            enemyShoot.damage = cannonBallDamage;
            enemyShoot.speed = cannonBallSpeed;
            enemyShoot.move = move;
            enemyShoot.shootColldown = shootCooldown;
            enemyShoot.enemyManager = this;
        }

        enemyCollision = GetComponent<EnemyCollision>();
        enemyCollision.enemyManager = this;

        gameManager = GameManager.instance;
    }
    private void FixedUpdate()
    {
        pointToLook = player.position;

        move.pointToLook = pointToLook;
        shipRotate.pointToLook = pointToLook;
    }
}
