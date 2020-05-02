using UnityEngine;
using UnityEngine.EventSystems;

public class SampleController : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbody;

    [SerializeField] private SphereCollider tipCollider;

    [SerializeField] private SphereCollider targetBallCollider;

    [SerializeField] private DragDetector dragDetector;

    /// <summary>
    /// dragの1pixelの移動で適用されるキューの加速度　
    /// </summary>
    private float speedCofficient = 0.1f;

    void Awake()
    {
        dragDetector.OnDragCallback += OnDrag;
    }

    void OnDrag(PointerEventData eventData)
    {
        // Dragにより次のキューの位置
        var nextQueuePosition = rigidbody.position + new Vector3(0, 0, eventData.delta.y * speedCofficient);

        // tipの半径
        var tipRadius = tipCollider.radius;

        // ballの半径　
        var ballRadius = targetBallCollider.radius;

        var d = (targetBallCollider.transform.position - nextQueuePosition).sqrMagnitude;

        // 接触する
        if (d < Mathf.Pow(tipRadius + ballRadius, 2f))
        {
            rigidbody.velocity = new Vector3(0f, 0f, eventData.delta.y);
        }

        rigidbody.position = nextQueuePosition;
    }
}
