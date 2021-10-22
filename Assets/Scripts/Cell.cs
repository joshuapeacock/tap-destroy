using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Cell : MonoBehaviour
{
    private Rigidbody rb;

    public bool IsKinematic
    {
        set
        {
            if (rb == null)
                rb = GetComponent<Rigidbody>();
            rb.isKinematic = value;
        }

        get
        {
            if (rb == null)
                rb = GetComponent<Rigidbody>();
            return rb.isKinematic;
        }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void AddForce(Vector3 force)
    {
        rb.isKinematic = false;
        rb.AddForce(force,ForceMode.Impulse);
    }
}
