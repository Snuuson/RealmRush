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
    [SerializeField] TextMeshProUGUI numberOfKillsLabel;

    static int numberOfKills = 0;
    AudioSource hitAudioSource;

    Enemy enemy;

    void Awake() 
    {
        
        
        enemy = GetComponent<Enemy>();
        hitAudioSource = GetComponent<AudioSource>();
        Transform child = transform.Find("HitPointLabel");
        
        hitPointLabel = child.gameObject.GetComponent<TextMeshPro>();

        numberOfKills = 0;
        GameObject canvas = FindObjectOfType<MainCanvas>().transform.gameObject;
        numberOfKillsLabel = canvas.transform.Find("NumberOfKills").GetComponent<TextMeshProUGUI>();
        Debug.Log(numberOfKillsLabel);
        
        UpdateKillCountLabel();
       
        
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
        Debug.Log(other.tag);
        String dmgTag = other.tag;
        ProcessHit(dmgTag);
    }

    void PlayHitAudio() 
    {
        hitAudioSource.PlayOneShot(hitSound);
    }

    void UpdateHitpointLabel() {
        hitPointLabel.text = currentHitpoints.ToString();
    }

    void UpdateKillCountLabel(){
        
        numberOfKillsLabel.text = "Kills: " + numberOfKills;
    }
    private void ProcessHit(String dmgTag)
    {
        if(dmgTag == "Frost")
        {
            transform.GetComponent<EnemyMover>().Speed *= 0.9f;
        }
        if(dmgTag == "Fire")
        {
            currentHitpoints--;
        }
        if(dmgTag == "Chaos")
        {
            Debug.Log("Chaos Damage");
            currentHitpoints -= 9;
        }
        currentHitpoints--;
        UpdateHitpointLabel();
        hitParticleSystem.Play();
        PlayHitAudio();
        if (currentHitpoints <= 0) {
            gameObject.SetActive(false);
            numberOfKills++;
            UpdateKillCountLabel();
            maxHitpoints += difficultyRamp;
            transform.GetComponent<EnemyMover>().MaxSpeed += 0.05f;
            enemy.RewardGold();
        }
    }
}
