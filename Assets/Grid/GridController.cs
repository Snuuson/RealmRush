using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    
    Dictionary<Vector2Int,GridTile> grid = new Dictionary<Vector2Int, GridTile>();
    int gridSize;
    float tileSize;

    private void createGrid()
    {

    }


    public Vector2Int GetCoordinatesFromPosition(Vector3 position)
    {
        Vector2Int coordinates = new Vector2Int();
        coordinates.x = Mathf.RoundToInt(position.x / tileSize);
        coordinates.y = Mathf.RoundToInt(position.z / tileSize);
        return coordinates;
    }

    public Vector3 GetPositionFromCoordinates(Vector2Int coordinates)
    {
        Vector3 position = new Vector3();
        position.x = coordinates.x * tileSize;
        position.z = coordinates.y * tileSize;
        return position;
    }
    
}
