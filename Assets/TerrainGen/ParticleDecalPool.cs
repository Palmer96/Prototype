using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDecalPool : MonoBehaviour
{

    public int maxDecals = 100;
    private int particleDecalDataIndex;


    private ParticleSystem decalParticleSystem;
    private ParticleDecalData[] particleData;
    private ParticleSystem.Particle[] particles;
    // Use this for initialization
    void Start()
    {
        decalParticleSystem = GetComponent<ParticleSystem>();
        particles = new ParticleSystem.Particle[maxDecals];
        particleData = new ParticleDecalData[maxDecals];
        for (int i = 0; i < maxDecals; i++)
        {
            particleData[i] = new ParticleDecalData();
        }

    }

    public void ParticleHit(ParticleCollisionEvent particleCollisionEvent)
    {

    }
    void SetParticleData(ParticleCollisionEvent particleCollisonEvent)
    {
        if (particleDecalDataIndex >= maxDecals)
        {
            particleDecalDataIndex = 0;
        }

        particleData[particleDecalDataIndex].position = particleCollisonEvent.intersection;
        particleData[particleDecalDataIndex].rotation = Quaternion.LookRotation(particleCollisonEvent.normal).eulerAngles;
        particleData[particleDecalDataIndex].size = 1;
        particleData[particleDecalDataIndex].color = Color.white;


        particleDecalDataIndex++;
    }

    void DisplayParticles()
    {
        for (int i = 0; i < particleData.Length; i++)
        {
            particles[i].position = particleData[i].position;
            particles[i].rotation3D = particleData[i].rotation;
            particles[i].startSize = particleData[i].size;
            particles[i].startColor = particleData[i].color;
        }
        decalParticleSystem.SetParticles(particles, particles.Length);
    }
}
