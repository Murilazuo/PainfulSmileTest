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

    private void Start()
    {
        cannon = GetComponentInChildren<Cannon>();

        StartCoroutine(Shoot());
    }

    internal void DestroyCannon()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        cannon.GetComponent<SpriteRenderer>().color = Color.clear;
        StopCoroutine(Shoot());
    }
    IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(shootColldown);
            
            if (move.move == 0)
            {
                cannon.Shoot(damage,speed);
            }
        }
    }
}
