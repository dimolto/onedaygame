using UnityEngine;

public class Queue : MonoBehaviour
{

    [SerializeField] private Tip tip;

    private int shotBallLayer;

    void Start()
    {
        // コンストラクタのタイミングでは使えないので、Startのタイミングで値を取る
        shotBallLayer = LayerMask.NameToLayer("ShotBall");
    }

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


    void Awake()
    {
        tip.OnContact += OnContact;
    }
}
