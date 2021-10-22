using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private Camera camera;
    private Vector3 hitPosition;
    public Launcher launcher;

    private void Awake()
    {
        camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(ray, out hit);
            if (hit.collider)
            {
                launcher.Fire(hit.point);
            }
        }
    }
}
