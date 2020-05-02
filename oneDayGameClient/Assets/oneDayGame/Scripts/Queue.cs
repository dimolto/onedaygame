using UnityEngine;
using UnityEngine.EventSystems;

public class Queue : MonoBehaviour
{

    [SerializeField] private Tip tip;

    [SerializeField] private DragDetector dragDetector;

    /// <summary>
    /// dragに対してキューの移動速度を制御するための係数
    /// </summary>
    readonly private float speedCofficient = 1f;

    private int shotBallLayer;

    private Vector3 startPosition;

    private bool active;

    public Vector3 StartPosition
    {
        get { return startPosition; }
    }

    public SphereCollider Collider
    {
        get { return tip.TipCollider; }
    }

    public Vector3 QueueVelocity { get; private set; }

    /// <summary>
    /// tipとボールがぶつかったときに呼ばれるメソッド
    /// </summary>
    /// <param name="other"></param>
    public void OnContact(Collision other)
    {
        if (other.gameObject.layer == shotBallLayer)
        {
            tip.gameObject.SetActive(false);
        }
    }

    public void SetActive(bool isActive)
    {
        active = isActive;
    }

    void Awake()
    {
        // コンストラクタのタイミングでは使えないので、Startのタイミングで値を取る
        shotBallLayer = LayerMask.NameToLayer("ShotBall");
        tip.OnContact += OnContact;
        dragDetector.OnInitializePotentialDragCallback += OnInitializePotentialDragCallback;
        dragDetector.OnBeginDragCallback += OnBeginDrag;
        dragDetector.OnDragCallback += OnDrag;
        dragDetector.OnEndDragCallback += OnEndDrag;
        startPosition = transform.position;
    }

    void OnInitializePotentialDragCallback(PointerEventData eventData)
    {
        if (!active)
        {
            return;
        }
        startPosition = transform.position;
        QueueVelocity = Vector3.zero;
    }

    void OnBeginDrag(PointerEventData eventData)
    {
        if (!active)
        {
            return;
        }
    }

    void OnDrag(PointerEventData eventData)
    {
        if (!active)
        {
            return;
        }
        // Dragにより次のキューの位置
        var nextQueuePosition = tip.TipRigidbody.position + new Vector3(0, 0, eventData.delta.y  * Time.deltaTime * speedCofficient);
        transform.position = nextQueuePosition;
        QueueVelocity = transform.forward * eventData.delta.magnitude * Time.deltaTime;
    }

    void OnEndDrag(PointerEventData eventData)
    {
        if (!active)
        {
            return;
        }
        tip.TipRigidbody.velocity = Vector3.zero;
        tip.TipRigidbody.angularVelocity = Vector3.zero;
    }
}


