using UnityEngine;

public class Queue : MonoBehaviour
{

    [SerializeField] private Tip tip;

    /// <summary>
    /// tipとボールがぶつかったときに呼ばれるメソッド
    /// </summary>
    /// <param name="other"></param>
    public void OnContact(Collision other)
    {
        Debug.Log("OnContact");
    }


    void Awake()
    {
        tip.OnContact += OnContact;
    }
}
