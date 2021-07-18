using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction {
    up = 0,
    left = 1,
    down = 2,
    right = 3
};


public class DisplacementManager : MonoBehaviour
{
    public static List<Vector2Int> positionsVisited = new List<Vector2Int>();
    private static readonly Dictionary<Direction, Vector2Int> directionMovementMap = new Dictionary<Direction, Vector2Int>
    {
        {Direction.up, Vector2Int.up},
        {Direction.left, Vector2Int.left},
        {Direction.down, Vector2Int.down},
        {Direction.right, Vector2Int.right}
    };

    public static List<Vector2Int> GenerateDungeon(InfoLoad dungeonData)
    {
        List<Displacer> Displacers = new List<Displacer>();

        for (int i = 0; i < dungeonData.numberOfCrawlers; i++)
        {
            Displacers.Add(new Displacer(Vector2Int.zero));
        }

        int iterations = Random.Range(dungeonData.iterationMin, dungeonData.iterationMax);

        for (int i = 0; i < iterations; i++)
        {
            foreach (Displacer Displacer in Displacers)
            {
                Vector2Int newPos = Displacer.Move(directionMovementMap);
                positionsVisited.Add(newPos);
            }
        }

        return positionsVisited;
    }

}
