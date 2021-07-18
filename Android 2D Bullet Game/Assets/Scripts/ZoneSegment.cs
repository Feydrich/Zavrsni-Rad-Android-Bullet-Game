using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneSegment : MonoBehaviour
{
    public SpriteRenderer Background;
    public int Width, Height;
    public bool doOnce = true;
    float time = 2f;
    private bool updatedDoors = false;
    public int X, Y;  

    public ObstacleInformation leftDoor, rightDoor, topDoor, bottomDoor;

    public ObstacleInformation bottom1, bottom2, right1, right2;

    public List<ObstacleInformation> Obstacles = new List<ObstacleInformation>();



    public ZoneSegment GetRight()
    {
        if (ZoneManager.instance.DoesRoomExist(X + 1, Y))
        {
            return ZoneManager.instance.FindRoom(X + 1, Y);
        }
        return null;
    }
    public ZoneSegment GetLeft()
    {
        if (ZoneManager.instance.DoesRoomExist(X - 1, Y))
        {
            return ZoneManager.instance.FindRoom(X - 1, Y);
        }
        return null;
    }
    public ZoneSegment GetTop()
    {
        if (ZoneManager.instance.DoesRoomExist(X, Y + 1))
        {
            return ZoneManager.instance.FindRoom(X, Y + 1);
        }
        return null;
    }
    public ZoneSegment GetBottom()
    {
        if (ZoneManager.instance.DoesRoomExist(X, Y - 1))
        {
            return ZoneManager.instance.FindRoom(X, Y - 1);
        }
        return null;
    }

    void Start()
    {

        ObstacleInformation[] ds = GetComponentsInChildren<ObstacleInformation>();
        foreach (ObstacleInformation d in ds) {
            Obstacles.Add(d);
            switch (d.doorType) {
                case ObstacleInformation.TypeGenerated.right:
                    rightDoor = d;
                    break;
                case ObstacleInformation.TypeGenerated.left:
                    leftDoor = d;
                    break;
                case ObstacleInformation.TypeGenerated.top:
                    topDoor = d;
                    break;
                case ObstacleInformation.TypeGenerated.bottom:
                    bottomDoor = d;
                    break;
            }
        }

        ZoneManager.instance.RegisterRoom(this);

    }

    public Vector3 GetRoomCenter()
    {
        return new Vector3(X * Width, Y * Height);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(Width, Height, 0));
    }

    public ZoneSegment(int x, int y)
    {
        X = x;
        Y = y;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (name.Contains("End") && !updatedDoors && time > -2)
        {
            RemoveConnectedObstacles();
        }

        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") {
            updatedDoors = true;
        }
    }

    public void RemoveConnectedObstacles()
    {
        foreach (ObstacleInformation obstacle in Obstacles)
        {
            switch (obstacle.doorType)
            {
                case ObstacleInformation.TypeGenerated.right:
                    if (GetRight() != null)
                        obstacle.gameObject.SetActive(false);
                    break;
                case ObstacleInformation.TypeGenerated.left:
                    if (GetLeft() != null)
                        obstacle.gameObject.SetActive(false);
                    break;
                case ObstacleInformation.TypeGenerated.top:
                    if (GetTop() != null)
                        obstacle.gameObject.SetActive(false);
                    break;
                case ObstacleInformation.TypeGenerated.bottom:
                    if (GetBottom() != null)
                        obstacle.gameObject.SetActive(false);
                    break;
                case ObstacleInformation.TypeGenerated.rightRoad:
                    if (GetRight() == null)
                        obstacle.gameObject.SetActive(false);
                    break;
                case ObstacleInformation.TypeGenerated.leftRoad:
                    if (GetLeft() == null)
                        obstacle.gameObject.SetActive(false);
                    break;
                case ObstacleInformation.TypeGenerated.topRoad:
                    if (GetTop() == null)
                        obstacle.gameObject.SetActive(false);
                    break;
                case ObstacleInformation.TypeGenerated.bottomRoad:
                    if (GetBottom() == null)
                        obstacle.gameObject.SetActive(false);
                    break;
            }
        }
        
    }
   


}
