using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;




public class PinManager : MonoBehaviour
{

    public GameObject currentLocation, selected;
    public bool isMoving = false;
    public float speed;

    public GameObject Line;
    private GameObject pathClosest;



    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (isMoving == false)
        {
            transform.position = currentLocation.GetComponent<ClickerManager>().holder.transform.position;
        }
        
        switch (currentLocation.GetComponent<ClickerManager>().Type) {
                case (dungeonType.Beach):
                    GameManager.type = dungeonType.Beach;
                    break;
                case (dungeonType.Beach2):
                    GameManager.type = dungeonType.Beach2;
                    break;
                case (dungeonType.Beach3):
                    GameManager.type = dungeonType.Beach3;
                    break;
                case (dungeonType.Forest):
                    GameManager.type = dungeonType.Forest;
                    break;
                case (dungeonType.Forest2):
                    GameManager.type = dungeonType.Forest2;
                    break;
                case (dungeonType.Forest3):
                    GameManager.type = dungeonType.Forest3;
                    break;
                case (dungeonType.Snow):
                    GameManager.type = dungeonType.Snow;
                    break;
                case (dungeonType.Snow2):
                    GameManager.type = dungeonType.Snow2;
                    break;
                case (dungeonType.Tundra):
                    GameManager.type = dungeonType.Tundra;
                    break;
                default:
                    GameManager.type = dungeonType.Forest;
                    break;
            }
    }

    public void movePin()
    {
        //path = planPath();
        GameObject next;
        next = currentLocation;
        isMoving = true;

        for (int i = 0; i < currentLocation.GetComponent<ClickerManager>().neighbour.Length; i++) {
            if (Vector3.Distance(currentLocation.GetComponent<ClickerManager>().neighbour[i].GetComponent<ClickerManager>().holder.transform.position, selected.GetComponent<ClickerManager>().holder.transform.position) < Vector3.Distance(next.GetComponent<ClickerManager>().holder.transform.position, selected.GetComponent<ClickerManager>().holder.transform.position)) {
                next = currentLocation.GetComponent<ClickerManager>().neighbour[i];
            }
        }

        currentLocation = next;
        this.transform.position = next.transform.position;
        
        isMoving = false;
    }

    public List<GameObject> planPath()
    {
        List<GameObject> path = new List<GameObject>();
        GameObject next, jump;
        jump = currentLocation;
        next = jump;



        while (next != selected)
        {
            for (int i = 0; i < jump.GetComponent<ClickerManager>().neighbour.Length; i++)
            {
                if (Vector3.Distance(jump.GetComponent<ClickerManager>().neighbour[i].GetComponent<ClickerManager>().holder.transform.position, selected.GetComponent<ClickerManager>().holder.transform.position) < Vector3.Distance(next.GetComponent<ClickerManager>().holder.transform.position, selected.GetComponent<ClickerManager>().holder.transform.position))
                {
                    next = jump.GetComponent<ClickerManager>().neighbour[i];
                }
            }
            jump = next;
            path.Add(next);
        }

        return path;
    }

    

}
