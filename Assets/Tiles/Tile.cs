using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    // Start is called before the first frame update


    [SerializeField] Tower towerPrefab;
    [SerializeField] int towerIterator = 0;
    [SerializeField] List<Tower> towerTypeList;

    TowerList towerList;
    GridManager gridManager;
    Vector2Int coordinates = new Vector2Int();
    [SerializeField] bool isPlaceable;
    Pathfinder pathfinder;

    void Awake()
    {
        pathfinder = FindObjectOfType<Pathfinder>();
        gridManager = FindObjectOfType<GridManager>();
        towerList = FindObjectOfType<TowerList>();
        towerIterator = 0;
    }

    void Start()
    {
        if(gridManager != null)
        {
            coordinates = gridManager.GetCoordinatesFromPosition(transform.position);
            
            if(!isPlaceable)
            {
                gridManager.BlockNode(coordinates);
            }
        }
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

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            towerIterator = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            towerIterator = 3;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            towerIterator = 4;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            towerIterator = 5;
        }
        
        

    }
    public bool IsPlaceable { get { return isPlaceable; } }
    void OnMouseDown() {
        
        if (gridManager.GetNode(coordinates).isWalkable && !pathfinder.willBlockPath(coordinates)) {
            
            GameObject resultTower = towerTypeList[towerIterator].CreateTower(towerTypeList[towerIterator], transform.position);
            if(resultTower != null)
            {
                towerList.AddTower(resultTower,coordinates);
                gridManager.BlockNode(coordinates);
                pathfinder.NotifyRecievers();
            }
            
        }
        
    }
}
