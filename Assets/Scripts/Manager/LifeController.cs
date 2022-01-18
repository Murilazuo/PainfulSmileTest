using UnityEngine;

public class LifeController : MonoBehaviour
{
    [Header("Variable")]
    [SerializeField] private float fillSpeed;
    private float maxLife,life;
    private float barHeight;

    [Header("Components")]
    private Transform target;
    [SerializeField]private Transform bar;

    public void InitializeLifeBar( GameObject objectToFollow, float maxLifeToSet, float setBarHeight)
    {
        gameObject.name = objectToFollow.name + " Bar";

        target = objectToFollow.transform;

        barHeight = setBarHeight;

        maxLife = maxLifeToSet;
        life = maxLife;
    }

    private void FixedUpdate()
    {
        if(target != null)
        {
            transform.position = new Vector2(target.position.x - 0.5f, target.position.y + barHeight);
        }
    }
    public void TakeDamage(float damage)
    {
        life -= damage;

        if (life <= 0)
        {
            life = 0;

           // Destroy(gameObject);
        }
        float lifeNormalize = life / maxLife;

        bar.transform.localScale = new Vector2(lifeNormalize, 1);
    }
}
