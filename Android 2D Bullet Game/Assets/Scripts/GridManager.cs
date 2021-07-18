using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public ZoneSegment zone;

    [System.Serializable]
    public struct Grid
    {
        public float verticalShift, horizontalShift;
        public int columns, rows;
    }

    public Grid grid;
    public GameObject gridTile;
    public List<Vector2> availablePoints = new List<Vector2>();

    void Awake()
    {
        zone = GetComponentInParent<ZoneSegment>();
        grid.columns = zone.Width - 4;
        grid.rows = zone.Height - 4;

        grid.horizontalShift += zone.transform.localPosition.x;
        grid.verticalShift += zone.transform.localPosition.y;

        for (int i = 0; i < grid.rows; i++)
        {
            for (int j = 0; j < grid.columns; j++)
            {
                GameObject temp = Instantiate(gridTile, transform);
                temp.GetComponent<Transform>().position = new Vector2(j - (grid.columns - grid.horizontalShift), i - (grid.rows - grid.verticalShift));
                //List<Vector2> availablePoints
                availablePoints.Add(temp.transform.position);
                temp.SetActive(false);
            }
        }

        GetComponentInParent<ObjectZoneSpawner>().InitialiseObjectSpawning();
    }
    

}
