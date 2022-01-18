using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] private GameObject CannonBall;
    private bool active = true;
    public void Shoot(float newDamage, float newSpeed, bool newPlayerCannon = false)
    {
        if (active)
        {
            CannonBall cannonBall = Instantiate(CannonBall, transform.position, transform.rotation).GetComponent<CannonBall>();
            cannonBall.InitializeBall(newDamage, newSpeed,transform.rotation, newPlayerCannon);   
        }
    }
    public void DestroyCannon()
    {
        active = false;
        GetComponent<Animator>().SetTrigger("Death");
    }
}
