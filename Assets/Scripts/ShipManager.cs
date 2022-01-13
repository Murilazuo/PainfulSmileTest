using UnityEngine;

[DefaultExecutionOrder(-1)]
public abstract class ShipManager : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject lifeBar;

    [Header("Move Settings")]
    [SerializeField] private float speed;
    [SerializeField] private float distanceToStop;

    [Header("Life Settings")]
    [SerializeField] private float maxLife;
    [SerializeField] private float lifeBarHeight;

    [Header("Components")]
    protected ShipRotate shipRotate;
    protected Move move;
    private Rigidbody2D rig;
    private LifeController lifeController;

    internal Vector2 pointToLook;

    void Awake()
    {
        shipRotate = GetComponent<ShipRotate>();
        move = GetComponent<Move>();

        lifeController = Instantiate(lifeBar,transform.position,Quaternion.identity).GetComponent<LifeController>();
        lifeController.InitializeLifeBar(gameObject, maxLife, lifeBarHeight);

        rig = GetComponent<Rigidbody2D>();

        move.speed = speed;
        move.rig = rig;
        move.minDistanceToTarget = distanceToStop;
    }

   
}
