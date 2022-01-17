using System.Collections;
using UnityEngine;

[DefaultExecutionOrder(-1)]
public abstract class ShipManager : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject lifeBar;

    [Header("Move Settings")]
    [SerializeField] private float speed;
    [SerializeField] private float distanceToStop;
    protected ShipMove move;
    protected ShipRotate shipRotate;
    private Rigidbody2D rig;

    [Header("Cannon Settings")]
    [SerializeField] protected float cannonBallSpeed;
    [SerializeField] protected float cannonBallDamage;


    [Header("Life Settings")]
    [SerializeField] private float maxLife;
    [SerializeField] internal float life; 
    [SerializeField] private float lifeBarHeight;
    [SerializeField] private Sprite[] destroyStateSprites;
    [SerializeField] private float timeToDeath;
    private LifeController lifeController;

    [Header("Components")]
    private SpriteRenderer spr;
    private Animator animator;

    internal Vector2 pointToLook;

    protected abstract void OnShipDestroy();
    void Awake()
    {
        life = maxLife;

        shipRotate = GetComponent<ShipRotate>();
        move = GetComponent<ShipMove>();
        spr = GetComponent<SpriteRenderer>();
        lifeController = Instantiate(lifeBar,transform.position,Quaternion.identity).GetComponent<LifeController>();
        lifeController.InitializeLifeBar(gameObject, maxLife, lifeBarHeight);

        animator = GetComponent<Animator>();

        rig = GetComponent<Rigidbody2D>();

        shipRotate.rig = rig;

        move.speed = speed;
        move.rig = rig;
        move.minDistanceToTarget = distanceToStop;

        SetSprite(0);
    }
    
    public void TakeDamage(float damage)
    {
        life -= damage;

        float lifeNormalize = life / maxLife;
        
        if (lifeNormalize <= 0)
        {
            life = 0;
            
            SetSprite(3);
            StartCoroutine(DestroyShip());

        }else if (lifeNormalize < 0.33f)
        {
            SetSprite(2);
        }else if (lifeNormalize < 0.66f)
        {
            SetSprite(1);
        }

        lifeController.TakeDamage(damage);
    }
    void SetSprite(int spriteId)
    {
        spr.sprite = destroyStateSprites[spriteId];
    }
    IEnumerator DestroyShip()
    {
        OnShipDestroy();

        shipRotate.enabled = false;
        move.enabled = false;
        gameObject.tag = "Untagged";
        rig.constraints = RigidbodyConstraints2D.FreezeAll;

        animator.SetTrigger("Death");
        yield return new WaitForSeconds(timeToDeath);


        Destroy(lifeController.gameObject);
        Destroy(gameObject);
    }

}
