using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerList : MonoBehaviour
{
    // Start is called before the first frame update

    Dictionary<Vector2Int,GameObject> towerDict = new Dictionary<Vector2Int, GameObject>();
    Bank bank;
    GridManager gridManager;

    

    void Awake()
    {
        bank = FindObjectOfType<Bank>();
        gridManager = FindObjectOfType<GridManager>();
    }
    
    
    void Update()
    {
        if (Input.GetMouseButtonUp(1))
        {
            
            Vector2Int position = gridManager.GetMousePosition();
            Debug.Log("RightMouseClick on " + position );

            if(towerDict.ContainsKey(position))
            {
                Debug.Log("Tower Contains key " + position );
                RemoveTower(position);
                gridManager.UnblockNode(position);
            }
        }
    }

    public void AddTower(GameObject tower,Vector2Int position)
    {
        towerDict.Add(position,tower);
    }

    public void RemoveTower(Vector2Int position)
    {
        Debug.Log("Starting Remove " + position );
        GameObject towerObject = towerDict[position];
        Tower tower = towerObject.GetComponent<Tower>();
        Debug.Log("Tower Refund:  " + tower.Cost*tower.RefundPercent );
        bank.Deposit(Mathf.FloorToInt(tower.Cost*tower.RefundPercent));
        towerDict.Remove(position);
        Debug.Log("Tower Removed from Dict");
        Destroy(towerObject);
        Debug.Log("Tower Destroyed");
    }

    


}
