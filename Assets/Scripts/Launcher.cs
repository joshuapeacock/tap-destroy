using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    public Projectile projectilePrefab;

    public void Fire(Vector3 destination)
    {
        Projectile proj = Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        proj.Fire(destination);
    }
}
