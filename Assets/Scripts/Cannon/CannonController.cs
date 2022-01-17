using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(2)]
public class CannonController : MonoBehaviour
{
    private List<Cannon> cannons;
    
    [Header("Settings")]
    [SerializeField]private float damage = 2 , speed = 3;
    [SerializeField]private bool isPlayer = false;
    public void Initialize(float newDamage, float newSpeed, bool newIsPlayer = false)
    {
        damage = newDamage;
        speed = newSpeed;
        isPlayer = newIsPlayer;
    }
    private void Start()
    {
        cannons = new List<Cannon>();

        foreach(Transform child in transform)
        {
            if(child.GetComponent<Cannon>() != null)
            {
                cannons.Add(child.GetComponent<Cannon>());
            }
        }
    }

    public void ShootCannons()
    {
        foreach(Cannon cannon in cannons)
        {
            cannon.Shoot(damage,speed,isPlayer);
        }
    }
}
