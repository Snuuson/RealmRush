using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] [Range(0.2f,30f)] float spawnTimer = 1;
    [SerializeField] [Range(0, 50)] int poolSize = 5;

    GameObject[] pool;

    void Awake() {
        PopulatePool();
    }

    void Start()
    {
        new WaitForSeconds(2f);
        StartCoroutine(SpawnEnemy());
    }

    private void PopulatePool()
    {
        pool = new GameObject[poolSize];
        for (int i = 0; i < poolSize; i++) 
        { 
            GameObject obj = Instantiate(enemyPrefab, gameObject.transform);
            obj.SetActive(false);
            pool[i] = obj;
            
        }
    }

    void EnableObjectInPool() 
    {
        foreach (GameObject enemy in pool) {
            
            if (!enemy.activeInHierarchy) {
                enemy.SetActive(true);
                return;
            }
        }
    }

    IEnumerator SpawnEnemy() 
    {
        while(true)
        {
            EnableObjectInPool();
            yield return new WaitForSeconds(spawnTimer);
        }
        
        
    }
}
