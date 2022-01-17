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

    internal void DestroyShip()
    {
        cannon.GetComponent<SpriteRenderer>().color = Color.clear;
    }
    IEnumerator Shoot()
    {
        while (canShoot)
        {
            yield return new WaitForSeconds(shootColldown);
            
            if (move.move == 0 && canShoot == true)
            {
                cannon.Shoot(damage,speed);
            }
        }

        GetComponent<SpriteRenderer>().enabled = false;
    }
}
