using System.Collections;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [Header("Components")]
    internal ShipMove move;
    internal EnemyManager enemyManager;
    private Cannon cannon;

    [Header("Settings")]
    internal float shootColldown;
    internal float damage, speed;
    private bool canShoot = true;
    private void Start()
    {
        cannon = GetComponentInChildren<Cannon>();

        StartCoroutine(Shoot());
    }

    internal void DestroyCannon()
    {
        StopCoroutine(Shoot());
        canShoot = false;
        cannon.DestroyCannon();
    }
    IEnumerator Shoot()
    {
        while (canShoot)
        {
            yield return new WaitForSeconds(shootColldown);
            
            if (move.move == 0)
            {
                cannon.Shoot(damage,speed);
            }
        }
    }
}
