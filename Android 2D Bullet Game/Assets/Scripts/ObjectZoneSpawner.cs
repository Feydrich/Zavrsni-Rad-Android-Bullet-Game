using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectZoneSpawner : MonoBehaviour
{
    [System.Serializable]
    public struct RandomSpawner
    {
        public string name;
        public ScriptableObjectCreator spawnerData;
    }

    public GridManager grid;
    public RandomSpawner[] spawnerData;
    public GameObject shadowPrefab;
    public GameObject dustTrailPrefab;
    

    public void InitialiseObjectSpawning()
    {
        foreach (RandomSpawner rs in spawnerData)
        {
            int randomIteration = Random.Range(rs.spawnerData.min, rs.spawnerData.max);

            for (int i = 0; i < randomIteration; i++)
            {
                int randomPos = Random.Range(0, grid.availablePoints.Count - 1);
                GameObject go = Instantiate(rs.spawnerData.createObject, grid.availablePoints[randomPos], Quaternion.identity, transform) as GameObject;
                GameObject temp = Instantiate(shadowPrefab) as GameObject;
                temp.GetComponent<ShadowFollowManager>().target = go;
                temp.transform.parent = go.transform;
                temp = Instantiate(dustTrailPrefab) as GameObject;
                temp.GetComponent<MovementDetector>().target = go;
                temp.transform.parent = go.transform;
                grid.availablePoints.RemoveAt(randomPos);
            }
        }
    }

   
}
