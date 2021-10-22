using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTrigger : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cell"))
        {
            var cell = other.GetComponent<Cell>();
            cell.IsKinematic = false;
        }
    }
}
