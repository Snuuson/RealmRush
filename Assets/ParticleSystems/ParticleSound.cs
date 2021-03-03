using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSound : MonoBehaviour
{
    // Start is called before the first frame update
    ParticleSystem particleSytem;
    AudioSource shootAudioSource;
    int currentParticleCount = 0;
    void Start()
    {
        particleSytem = GetComponent<ParticleSystem>();
        shootAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {


        if (particleSytem.particleCount > currentParticleCount) {
            if (!shootAudioSource.isPlaying) 
            {
                shootAudioSource.Play();
            }
        }
        currentParticleCount = particleSytem.particleCount;
    }
}
