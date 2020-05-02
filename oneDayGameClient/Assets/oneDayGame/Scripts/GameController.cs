using UnityEngine;
using UnityEngine.EventSystems;

public class GameController : MonoBehaviour
{
    [SerializeField] private Rigidbody queueRigidbody;

    [SerializeField] private SphereCollider tipCollider;

    [SerializeField] private SphereCollider targetBallCollider;

    [SerializeField] private DragDetector dragDetector;

    /// <summary>
    /// dragの1pixelの移動で適用されるキューの加速度　
    /// </summary>
    readonly private float speedCofficient = 0.1f;

    private Vector3 startQueuePosition;

    void Awake()
    {
        dragDetector.OnInitializePotentialDragCallback += OnInitializePotential;
        dragDetector.OnDragCallback += OnDrag;
    }

    void OnInitializePotential(PointerEventData eventData)
    {
        startQueuePosition = tipCollider.transform.position;
    }

    void OnDrag(PointerEventData eventData)
    {
        // Dragにより次のキューの位置
        var nextQueuePosition = queueRigidbody.position + new Vector3(0, 0, eventData.delta.y * speedCofficient);

        // tipの半径
        var tipRadius = tipCollider.radius;

        // ballの半径　
        var ballRadius = targetBallCollider.radius;

        var d = (targetBallCollider.transform.position - nextQueuePosition).sqrMagnitude;

        // スタート地点とボールの位置、次のキューの位置とボールの位置で内積を計算し、両方の符号が食い違っていた場合は通り過ぎていると判断する
        var dot1 = Vector3.Dot(startQueuePosition, targetBallCollider.transform.position);
        var dot2 = Vector3.Dot(nextQueuePosition, targetBallCollider.transform.position);

        // 接触する
        if (d < Mathf.Pow(tipRadius + ballRadius, 2f) || dot1 * dot2 <0)
        {
            queueRigidbody.velocity = new Vector3(0f, 0f, eventData.delta.y);
        }

        queueRigidbody.position = nextQueuePosition;
    }

    void OnEndDrag(PointerEventData eventData)
    {
        queueRigidbody.velocity = Vector3.zero;
        queueRigidbody.angularVelocity = Vector3.zero;
    }
}
