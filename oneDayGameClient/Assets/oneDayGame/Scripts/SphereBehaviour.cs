using UnityEngine;

public class SphereBehaviour : MonoBehaviour
{

    public bool Hitted { get; private set; }

    void OnCollisionEnter()
    {
        Hitted = true;
    }
}
