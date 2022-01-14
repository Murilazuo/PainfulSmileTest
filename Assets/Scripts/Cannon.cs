using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] private GameObject CannonBall;
    public void Shoot(float newDamage, float newSpeed, bool newPlayerCannon = false)
    {
        CannonBall cannonBall = Instantiate(CannonBall, transform.position, transform.rotation).GetComponent<CannonBall>();
        cannonBall.InitializeBall(newDamage, newSpeed,transform.rotation, newPlayerCannon);   
    }
}
