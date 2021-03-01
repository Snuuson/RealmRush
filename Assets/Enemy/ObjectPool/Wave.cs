using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave
{


   [SerializeField]
   int waveSize = 0;
   public int WaveSize{get{return waveSize;}}

   [Tooltip("SpawnInterval in Seconds")]
   [SerializeField]
   float spawnInterval = 1f;
   public float SpawnInterval{get{return spawnInterval;}}

   [SerializeField]
   GameObject objectPrefab;
   [SerializeField]
   Object objectType;
   public GameObject ObjectPrefab{get{return objectPrefab;}}
   
   public List<GameObject> objectList = new List<GameObject>();

}
