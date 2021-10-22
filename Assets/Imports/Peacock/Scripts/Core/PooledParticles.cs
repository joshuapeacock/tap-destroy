using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Peacock.Core
{
    [RequireComponent(typeof(ParticleSystem))]
    public class PooledParticles : MonoBehaviour
    {
        private ParticleSystem particles;

        private void Awake()
        {
            particles = GetComponent<ParticleSystem>();
        }

        private void Update()
        {
            if(particles.isPlaying == false)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
