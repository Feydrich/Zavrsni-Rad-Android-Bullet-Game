using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleInformation : MonoBehaviour
{
    public enum TypeGenerated
    {
        left, right, top, bottom, leftRoad, rightRoad, bottomRoad, topRoad
    }
    public TypeGenerated doorType;
}
