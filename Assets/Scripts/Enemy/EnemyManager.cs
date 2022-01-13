using UnityEngine;

public sealed class EnemyManager : ShipManager
{
    Transform player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void FixedUpdate()
    {
        pointToLook = player.position;
    }
}
