using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSpeed : MonoBehaviour
{
    [Range(0.1f, 5)]
    public float animationspeed;
    // Use this for initialization
    void Start()
    {
        GetComponent<Animator>().speed = animationspeed;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
