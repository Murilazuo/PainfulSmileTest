using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] List<Cannon> cannoMidle, CannonLeft, CannonRight;
    [SerializeField] List<Cannon> cannonActive;

    internal float damage, speed;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetCannonActive(cannoMidle);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetCannonActive(CannonLeft);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetCannonActive(CannonRight);
        }

        if (Input.GetMouseButtonDown(0))
        {
            ShootCannon();
        }
    }
    void SetCannonActive(List<Cannon> cannons)
    {

        cannonActive.Clear();

        cannonActive = cannons;
    }
    void ShootCannon()
    {
        foreach(Cannon cannon in cannonActive)
        {
            cannon.Shoot(damage, speed, true);
        }
    }
}
