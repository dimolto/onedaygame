using System;
using UnityEngine;

public class Tip : MonoBehaviour
{
    [SerializeField] private Collider tipCollider;

    public Collider TipCollider
    {
        get
        {
            if (tipCollider == null)
            {
                tipCollider = GetComponent<Collider>();
            }

            return tipCollider;
        }
    }

    [SerializeField] private Rigidbody tipRigidbody;

    public Rigidbody TipRigidbody
    {
        get
        {
            if (tipRigidbody == null)
            {
                tipRigidbody = GetComponent<Rigidbody>();
            }

            return tipRigidbody;
        }
    }

    public Action<Collision> OnContact;

    private void OnCollisionEnter(Collision other)
    {
        OnContact?.Invoke(other);
    }
}
