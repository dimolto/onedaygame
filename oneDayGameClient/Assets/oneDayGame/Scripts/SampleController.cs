using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleController : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbody;

    public void MovePosition()
    {
        rigidbody.velocity = rigidbody.transform.forward * 50f;
    }
}
