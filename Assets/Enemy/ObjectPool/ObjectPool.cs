using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    // Start is called before the first frame update
    
    
    [SerializeField] Wave[] waves = new Wave[10];
    [SerializeField] int waveSpawnInterval = 20;
    
    
    void Awake() {
        InitializeWaves();
        
    }

    void Start()
    {
        StartCoroutine(SpawnAllWaves());
    }

    void InitializeWaves()
    {
        foreach(Wave wave in waves)
        {
            for(int i = 0; i < wave.WaveSize;i++)
            {
                GameObject obj = Instantiate(wave.ObjectPrefab, gameObject.transform);
                obj.SetActive(false);
                wave.objectList.Add(obj);
            }
            
        }
    }

    IEnumerator SpawnAllWaves()
    {
        foreach(Wave wave in waves){
            SpawnWave(wave);
            yield return new WaitForSeconds(waveSpawnInterval);
        }
    }
    

    void SpawnWave(Wave wave)
    {
        
        Debug.Log("Spawing Wave");
        StartCoroutine(SpawnEnemies(wave));
        
    }

    IEnumerator SpawnEnemies(Wave wave) 
    {
            foreach(GameObject obj in wave.objectList)
            {
                obj.SetActive(true);
                yield return new WaitForSeconds(wave.SpawnInterval);

            }
    }
}
