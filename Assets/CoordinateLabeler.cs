using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[ExecuteAlways]
[RequireComponent(typeof(TextMesh))]
public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.gray;
    [SerializeField] Color exploredColor = Color.yellow;
    [SerializeField] Color pathColor = new Color(1f,0.5f,0f);


    GridManager gridManager;
    

    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    
    void Awake() {
        gridManager = FindObjectOfType<GridManager>();
        label = GetComponent<TextMeshPro>();
        label.enabled = true;
        DisplayCoordinates();
        
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        DisplayCoordinates();
        UpdateObjectName();
        SetLabelColor();
        ToggleLabels();
    }

    private void SetLabelColor()
    {
        if(gridManager == null)
        {
            
            return;
        }

        Node node = gridManager.GetNode(coordinates);
        if(node == null)
        {
           
            return;
         }
        
        label.color = blockedColor;
        if(node.isWalkable)
        {
            label.color = Color.green;
            
        }
        if(node.isExplored)
        {
            label.color = Color.blue;
        }
        if(node.isPath)
        {
            label.color = Color.red;
        }
        
        
    }

    void ToggleLabels() {
        if (Input.GetKeyDown(KeyCode.C)) {
            label.enabled = !label.enabled;
        }
    }
    private void DisplayCoordinates()
    {
        if(gridManager == null)
        {
            return;
        }
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / gridManager.UnityGridSize);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / gridManager.UnityGridSize);
        //Debug.Log(coordinates);
        label.text = coordinates.ToString();
    }

    private void UpdateObjectName() {
        transform.parent.name = coordinates.ToString();
    }
}
