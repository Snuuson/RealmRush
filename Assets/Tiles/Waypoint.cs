using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    // Start is called before the first frame update


    [SerializeField] Tower towerPrefab;
    [SerializeField] int towerIterator = 0;
    [SerializeField] List<Tower> towerList;


    [SerializeField] bool isPlaceable;

    void Awake()
    {
        towerIterator = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            towerIterator = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            towerIterator = 1;
        }


    }
    public bool IsPlaceable { get { return isPlaceable; } }
    void OnMouseDown() {
        
        if (isPlaceable) {
            
            bool isPlaced = towerList[towerIterator].CreateTower(towerList[towerIterator], transform.position);
            isPlaceable = !isPlaced;
            
            
            
        }
        
    }
}
