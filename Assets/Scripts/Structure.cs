using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structure : MonoBehaviour
{
    public float destructionPoint = 0.8f;

    private Cell[] allCells;
    private bool isCollapsed;

    private void Awake()
    {
        allCells = GetComponentsInChildren<Cell>();
    }

    private void Update()
    {
        if (isCollapsed)
            return;

        float activeCount = 0f;
        float inactiveCount = 0f;
        foreach(Cell c in allCells)
        {
            if (c.IsKinematic)
            {
                inactiveCount += 1;
            }
            else
            {
                activeCount += 1;
            }
        }
        float destruction = activeCount / allCells.Length;
        if(destruction >= destructionPoint)
        {
            Collapse();
        }
    }

    public void Collapse()
    {
        if (isCollapsed)
            return;

        isCollapsed = true;
        foreach(Cell cell in allCells)
        {
            cell.IsKinematic = false;
        }
    }
}
