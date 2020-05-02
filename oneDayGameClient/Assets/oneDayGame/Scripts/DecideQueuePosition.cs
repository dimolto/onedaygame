using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class DecideQueuePosition : MonoBehaviour
{
    // GameState.DecideQueuePositoinのときに実行されるロジック

    [SerializeField] private Tip tip;

    [SerializeField] private ShotBall shotBall;

    [SerializeField] private DragDetector dragDetector;

    public Action OnEndDragCallback;

    /// <summary>
    /// キューとボールの距離
    /// </summary>
    private float distance;

    private bool active;

    private Vector2 shotBallScreenPos;

    public void SetActive(bool isActive)
    {
        active = isActive;
    }

    void Awake()
    {
        // コンストラクタのタイミングでは使えないので、Startのタイミングで値を取る
        dragDetector.OnInitializePotentialDragCallback += OnInitializePotentialDragCallback;
        dragDetector.OnBeginDragCallback += OnBeginDrag;
        dragDetector.OnDragCallback += OnDrag;
        dragDetector.OnEndDragCallback += OnEndDrag;
        distance = Vector3.Distance(shotBall.transform.position, tip.transform.position);
    }

    void OnInitializePotentialDragCallback(PointerEventData eventData)
    {
        if (!active)
        {
            return;
        }

        // ボールのスクリーン上での位置　
        shotBallScreenPos = Camera.main.WorldToScreenPoint(shotBall.transform.position);
        UpdateQueuePosition(eventData);
    }

    void OnBeginDrag(PointerEventData eventData)
    {
        if (!active)
        {
            return;
        }
        UpdateQueuePosition(eventData);
    }

    void OnDrag(PointerEventData eventData)
    {
        if (!active)
        {
            return;
        }
        UpdateQueuePosition(eventData);
    }

    void OnEndDrag(PointerEventData eventData)
    {
        if (!active)
        {
            return;
        }
        // OnEndDragのときまで発火させると意図した位置と微妙にずれそうなのでやめた
        //UpdateQueuePosition(eventData);
        OnEndDragCallback?.Invoke();
    }

    /// <summary>
    /// タップされている位置から
    /// </summary>
    /// <param name="eventData"></param>
    void UpdateQueuePosition(PointerEventData eventData)
    {
        // ボールの位置からタップされた位置に対するベクトルを得る
        var screenDirection = (shotBallScreenPos - eventData.position).normalized;
        // 2Dの向きを3Dの向きになおしておく
        var direction = new Vector3(-screenDirection.x, 0f, -screenDirection.y);
        tip.transform.position = shotBall.transform.position + direction * distance;
        tip.transform.LookAt(shotBall.transform.position);
    }
}
