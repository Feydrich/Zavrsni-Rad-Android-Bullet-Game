using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreationManager : MonoBehaviour
{
    public InfoLoad dungeonGenerationData;
    private List<Vector2Int> dungeonRooms;

    private void Start()
    {
        dungeonRooms = DisplacementManager.GenerateDungeon(dungeonGenerationData);
        SpawnRooms(dungeonRooms);
        
    }

    private void SpawnRooms(IEnumerable<Vector2Int> rooms)
    {
        ZoneManager.instance.LoadRoom("Start", 0, 0);
        foreach (Vector2Int roomLocation in rooms)
        {
            ZoneManager.instance.LoadRoom(ZoneManager.instance.GetRandomRoomName(), roomLocation.x, roomLocation.y);
            
        }
        
    }
}
