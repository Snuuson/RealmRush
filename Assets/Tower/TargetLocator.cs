using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    // Start is called before the first frame update
    Transform target;
    [SerializeField] Transform weapon;
    [SerializeField] float attackSpeed = 60f;
    [SerializeField] float attackRange = 15f;
    ParticleSystem attackParticleSystem;
    ParticleSystem.EmissionModule emission;

    // Update is called once per frame
    void Start() 
    {
        attackParticleSystem = weapon.GetComponentInChildren<ParticleSystem>();
        emission = attackParticleSystem.emission;
        
        
    }
    void Update()
    {
        emission.rateOverTime = attackSpeed;
        FindClosestTarget();
        AimWeapon();
    }

    private void AimWeapon()
    {
        if (target != null) 
        {
            weapon.LookAt(target.Find("Target").transform);
            
            if (Vector3.Distance(target.position, gameObject.transform.position) > attackRange)
            {
                Attack(false);
            }
            else
            {
                Attack(true);
            }
        }
        
    }

    private void FindClosestTarget() {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float minDistance = Mathf.Infinity;

        foreach (Enemy enemy in enemies) {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);
            if (targetDistance < minDistance) {
                minDistance = targetDistance;
                closestTarget = enemy.transform;
            }
        }
        target = closestTarget;
    }

    void Attack(bool isActive) {

        if (isActive && !attackParticleSystem.isPlaying)
        {
            attackParticleSystem.Play();
        }
        else if(!isActive && attackParticleSystem.isPlaying)
        {
            attackParticleSystem.Stop();
        }
    }
}
