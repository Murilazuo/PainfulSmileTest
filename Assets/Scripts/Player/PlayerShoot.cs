using System.Collections.Generic;
using System.Collections;
using UnityEngine;

[DefaultExecutionOrder(2)]
public class PlayerShoot : MonoBehaviour
{
    internal List<CannonController> cannons;
    float shootCooldown = 1f;
    bool canShoot = true;
    internal void InitializrCannons(float damage, float speed)
    {
        cannons = new List<CannonController>();

        foreach(Transform cannon in transform)
        {
            if(cannon.GetComponent<CannonController>() != null)
            {
                CannonController cannonController = cannon.GetComponent<CannonController>();

                cannons.Add(cannonController);

                cannonController.Initialize(damage, speed, true);
            }
        }
    }

    private void Update()
    {
        if (canShoot)
        {
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Shoot(0);
            }else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                Shoot(1);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Shoot(2);
            }
        }
    }
    private void Shoot(int cannonId)
    {
        cannons[cannonId].ShootCannons();
        StartCoroutine(ShootCooldown());
    }
    IEnumerator ShootCooldown()
    {
        canShoot = false;
        yield return new WaitForSeconds(shootCooldown);
        canShoot = true;
    }
}
