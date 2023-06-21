using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinityParticlesController : MonoBehaviour
{
    public ParticleSystem[] infinityParticle;

    // Start is called before the first frame update
    void PlaybackSpeed(float speed)
    {
        for(int i = 0; i < infinityParticle.Length; i++)
        {
            var main = infinityParticle[i].main;
            main.simulationSpeed = speed;
        }
    }

    // Update is called once per frame
    void Start()
    {
        PlaybackSpeed(100);
    }
}
