using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleController : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbody;

    public void MovePosition()
    {
        rigidbody.AddForceAtPosition(rigidbody.transform.forward.normalized * 100, rigidbody.transform.position + rigidbody.transform.forward * 0.5f);
    }
}
