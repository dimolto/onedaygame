using System;
using UnityEngine;

public class QueueDetectBallController : MonoBehaviour
{
    [SerializeField] private Queue queue;
    [SerializeField] private ShotBall shotBall;

    // ballの半径　
    private float shotBallRadius;

    private float tipRadius;

    private float velocityCofficient = 100f;

    public Action OnShot;

    private bool active = false;

    public void SetActive(bool isActive)
    {
        active = isActive;
        queue.SetActive(isActive);
    }

    void Awake()
    {
        shotBallRadius = shotBall.SphereCollider.radius;
        tipRadius = queue.Collider.radius;
    }

    void LateUpdate()
    {
        if (!queue.isActiveAndEnabled || !active)
        {
            return;
        }

        // キューの位置がボールを通り過ぎていないかチェックする
        // 通り過ぎている場合、もしくは接触している場合はBall側に衝突処理を起こす

        // キューの初期位置からボールまでのベクトルを正規化して保持
        var vec1normal = (shotBall.transform.position - queue.StartPosition).normalized;
        // 現時点のキューの位置とボールの関係を表す位置のベクトル
        var vec2normal = (shotBall.transform.position - queue.transform.position).normalized;

        var d = (shotBall.transform.position - queue.transform.position).sqrMagnitude;

        // 内積がマイナスの場合はベクトルの向きが真逆のため、ボールを通りすぎている
        // もしくは、キューの先端とボールの円が触れ合っている場合は触れ合っている
        if (Vector3.Dot(vec1normal, vec2normal) < 0 ||
            d < Mathf.Pow(tipRadius + shotBallRadius, 2f)
            )
        {
            // 衝突処理を行う
            shotBall.AddForce(queue.QueueVelocity * velocityCofficient);
            queue.gameObject.SetActive(false);
            OnShot?.Invoke();
        }
    }
}
