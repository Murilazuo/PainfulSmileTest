using UnityEngine;

[DefaultExecutionOrder(-1)]
public class PlayerManager : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject lifeBar;

    [Header("Move Settings")]
    [SerializeField] private float speed;
    [SerializeField] private float minDistanceToMouse;

    [Header("Life Settings")]
    [SerializeField] private float maxLife;
    [SerializeField] private float lifeBarHeight;

    [Header("Components")]
    private ShipRotate shipRotate;
    private PlayerMove playerMove;
    private Rigidbody2D rig;
    private Camera cam;
    private LifeController lifeController;

    internal Vector2 pointToLook;

    void Start()
    {
        shipRotate = GetComponent<ShipRotate>();
        playerMove = GetComponent<PlayerMove>();

        lifeController = Instantiate(lifeBar,transform.position,Quaternion.identity).GetComponent<LifeController>();
        lifeController.InitializeLifeBar(gameObject, maxLife, lifeBarHeight);

        rig = GetComponent<Rigidbody2D>();
        cam = Camera.main;

        playerMove.speed = speed;
        playerMove.rig = rig;
        playerMove.cam = cam;
        playerMove.minDistanceToTarget = minDistanceToMouse;
    }

    void FixedUpdate()
    {
        pointToLook = cam.ScreenToWorldPoint(Input.mousePosition);

        shipRotate.pointToLook = pointToLook;
        playerMove.pointToLook = pointToLook;
    }
}
