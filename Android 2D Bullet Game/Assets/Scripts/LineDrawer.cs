using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineDrawer : MonoBehaviour
{

    public LineRenderer Line;
    public GameObject Pin;
    public bool isSelected = false;
    public List<GameObject> path;

    // Start is called before the first frame update
    void Start()
    {
        Line.positionCount = 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        path.Clear();
        Line.SetPosition(0, Pin.transform.position);

        if (isSelected == true)
        {

            path = Pin.GetComponent<PinManager>().planPath();
            Line.positionCount = path.Count + 1;

            for (int i = 1; i < path.Count + 1; i++)
            {
                Line.SetPosition(i, path[i - 1].transform.position);
            }
        }
        else {
            Line.positionCount = 1;
        }
        
    }
}
