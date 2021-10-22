using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    public float force = 10f;
    public float lifeTime = 1f;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        rb.useGravity = false;
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    public void Fire(Vector3 destination)
    {
        var direction = destination - transform.position;
        direction = direction.normalized;
        rb.isKinematic = false;
        rb.AddForce(direction * force * rb.mass, ForceMode.Impulse);
        rb.AddTorque(Random.insideUnitSphere * force * rb.mass, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cell"))
        {
            rb.useGravity = true;
            var cell = collision.gameObject.GetComponent<Cell>();
            cell.AddForce(rb.velocity.normalized * (force * 0.25f));
            StartCoroutine(DisableRoutine(lifeTime));
        }
    }

    private IEnumerator DisableRoutine(float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }
}
