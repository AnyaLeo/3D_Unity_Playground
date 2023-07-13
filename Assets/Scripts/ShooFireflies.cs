using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooFireflies : MonoBehaviour
{
    ParticleSystem fireflies;
    bool canPlayEffectsForTheFirstTime;

    private void OnEnable()
    {
        fireflies = GetComponentInChildren<ParticleSystem>();
        canPlayEffectsForTheFirstTime = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!canPlayEffectsForTheFirstTime)
        {
            return;
        }
        canPlayEffectsForTheFirstTime = false;

        // add trails to our particles
        var trails = fireflies.trails;
        trails.enabled = true;

        // assign trail material through code
        ParticleSystemRenderer psr = fireflies.GetComponent<ParticleSystemRenderer>();
        psr.trailMaterial = psr.material;

        // turn off the velocity over lifetime so the fireflies dont orbit
        var vel = fireflies.velocityOverLifetime;
        vel.enabled = false;

        ParticleSystem.Particle[] particles = new ParticleSystem.Particle[fireflies.main.maxParticles];
        int numParticlesAlive = fireflies.GetParticles(particles);
        for (int i = 0; i < numParticlesAlive; i++)
        {
            particles[i].velocity = Vector3.up * 5;
            particles[i].startLifetime = 5;
            particles[i].remainingLifetime = 5;
        }

        fireflies.SetParticles(particles);

        // Gradually fade out the light because the fireflies are gone
        ExpandLight el = GetComponentInChildren<ExpandLight>();
        StartCoroutine(el.GraduallyFadeLight(el.endLightRange, 0, el.expandLightDuration));

        // Tell the firefly manager that it needs to send in more fireflies
        StartCoroutine(FireflyManager.Instance.StartNextFirefly());
    }
}
