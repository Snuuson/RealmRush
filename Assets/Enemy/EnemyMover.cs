using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] [Range(0f, 100f)] float maxSpeed = 1f;
    [SerializeField] [Range(0f, 100f)] float speed = 1f;
    Enemy enemy;

    public float Speed{get{return speed;} set{speed = value;}}
    public float MaxSpeed{get{return maxSpeed;} set{maxSpeed = value;}}
    void Awake() 
    {
        enemy = GetComponent<Enemy>();
        
    }
    void OnEnable()
    {
        speed = maxSpeed;
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FinishPath()
    {
        enemy.StealGold();
        gameObject.SetActive(false);
    }
    IEnumerator FollowPath()
    {
        foreach (Waypoint waypoint in path)
        {

            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position;
            float travelPercent = 0f;

            transform.LookAt(endPosition);
            while (travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }

        }
        FinishPath();
    }

    void ReturnToStart() 
    {
        transform.position = path[0].transform.position;
    }

    void FindPath() 
    {
        path.Clear();
        GameObject parent = GameObject.FindGameObjectWithTag("Path");

        foreach (Transform child in parent.transform) {
            Waypoint waypoint = child.GetComponent<Waypoint>();
            if (waypoint != null) {
                path.Add(waypoint);
            }
            
        }
    }
}
