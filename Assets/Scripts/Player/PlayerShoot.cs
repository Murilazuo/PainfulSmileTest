using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(2)]
public class PlayerShoot : MonoBehaviour
{
    internal List<CannonController> cannons;
    
    [Header("Settings")]
    internal float damage, speed;

    private void Start()
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
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            cannons[0].ShootCannons();
        }else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            cannons[1].ShootCannons();
        }else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            cannons[2].ShootCannons();
        }
    }
}
