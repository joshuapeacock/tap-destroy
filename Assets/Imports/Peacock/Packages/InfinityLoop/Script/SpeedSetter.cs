using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedSetter : MonoBehaviour
{
    public Animator LoopAnimator;
    [Range(0.1f, 1f)]
    public float speed = 0.1f;

    // Use this for initialization
    void Start()
    {
        LoopAnimator.speed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        LoopAnimator.speed = speed;
    }
}
