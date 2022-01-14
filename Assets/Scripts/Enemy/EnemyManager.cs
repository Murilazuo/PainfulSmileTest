using UnityEngine;

public sealed class EnemyManager : ShipManager
{
    [Header("Enemy Settings")]
    [SerializeField] private Transform player;
    public float damageOnCollision;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void FixedUpdate()
    {
        pointToLook = player.position;

        move.pointToLook = pointToLook;
        shipRotate.pointToLook = pointToLook;
    }
}
