using UnityEngine;

public class ShotBall : MonoBehaviour
{
    private SphereCollider sphereCollider;

    public SphereCollider SphereCollider
    {
        get
        {
            if (sphereCollider == null)
            {
                sphereCollider = GetComponent<SphereCollider>();
            }

            return sphereCollider;
        }
    }

    private Rigidbody rigidbody;

    public Rigidbody Rigidbody
    {
        get
        {
            if (rigidbody == null)
            {
                rigidbody = GetComponent<Rigidbody>();
            }

            return rigidbody;
        }
    }

    public void AddForce(Vector3 force)
    {
        Rigidbody.AddForce(force, ForceMode.Impulse);
        Debug.Log("AddForce ! " + force);
    }
}
