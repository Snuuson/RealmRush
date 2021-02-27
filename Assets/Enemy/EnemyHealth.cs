using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EnemyHealth : MonoBehaviour
{

    [SerializeField] int maxHitpoints = 5;
    [SerializeField] int difficultyRamp = 1;
    [SerializeField] int currentHitpoints;
    [SerializeField] ParticleSystem hitParticleSystem;
    [SerializeField] AudioClip hitSound;

    [SerializeField] TextMeshPro hitPointLabel;
    AudioSource hitAudioSource;

    Enemy enemy;

    void Awake() 
    {
        enemy = GetComponent<Enemy>();
        hitAudioSource = GetComponent<AudioSource>();
        Transform child = transform.Find("HitPointLabel");
        Debug.Log(child.name);
        hitPointLabel = child.gameObject.GetComponent<TextMeshPro>();
        
        Debug.Log(hitPointLabel);


    }
    // Start is called before the first frame update
    void OnEnable()
    {
        
        currentHitpoints = maxHitpoints;
        UpdateHitpointLabel();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    void PlayHitAudio() 
    {
        hitAudioSource.PlayOneShot(hitSound);
    }

    void UpdateHitpointLabel() {
        hitPointLabel.text = currentHitpoints.ToString();
    }
    private void ProcessHit()
    {
        currentHitpoints--;
        UpdateHitpointLabel();
        hitParticleSystem.Play();
        PlayHitAudio();
        if (currentHitpoints <= 0) {
            gameObject.SetActive(false);
            maxHitpoints += difficultyRamp;
            enemy.RewardGold();
        }
    }
}
