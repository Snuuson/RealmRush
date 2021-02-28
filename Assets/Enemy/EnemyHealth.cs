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

    [SerializeField] EnemyMover enemyMover;
    
    static int numberOfKills = 0;
    AudioSource hitAudioSource;

    Enemy enemy;

    void Awake() 
    {
        
        
        enemy = GetComponent<Enemy>();
        hitAudioSource = GetComponent<AudioSource>();
        Transform label = transform.Find("HitPointLabel");
        hitPointLabel = label.gameObject.GetComponent<TextMeshPro>();
        
        Transform particleSystem = transform.Find("HitParticleSystem");
        hitParticleSystem = particleSystem.GetComponent<ParticleSystem>();
        
        numberOfKills = 0;
        GameObject canvas = FindObjectOfType<MainCanvas>().transform.gameObject;
        numberOfKillsLabel = canvas.transform.Find("NumberOfKills").GetComponent<TextMeshProUGUI>();
        enemyMover = GetComponent<EnemyMover>();
        
        UpdateKillCountLabel();
       
        
       


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
        Tower tower = other.transform.GetComponentInParent<Tower>();
        ProcessHit(tower);
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

    private void ApplyModifier(Tower tower)
    {
        switch(tower.DamageType)
        {
            case DamageType.frost:
                enemyMover.Speed = enemyMover.MaxSpeed * 0.7f;
                break;
            case DamageType.chaos:
                int roll = UnityEngine.Random.Range(0,10);
                if(roll == 0){
                    currentHitpoints-= 50;
                } 
                enemyMover.Speed = enemyMover.MaxSpeed * 0.7f;
                break;
        }
    }

    private void ApplyDamageTower(Tower tower)
    {
        currentHitpoints-= tower.Damage;
    }
    private void ProcessHit(Tower tower)
    {
        
        ApplyModifier(tower);

        ApplyDamageTower(tower);
        
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
