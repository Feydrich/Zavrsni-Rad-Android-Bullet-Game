using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCreator : MonoBehaviour
{
    [System.Serializable]
    public struct Spawnable
    {
        public GameObject gameObject;
        public float chance;
    }

    public List<Spawnable> items = new List<Spawnable>();
    float totalChance = 0;
    public GameObject shadowPrefab;

    void Awake()
    {
        foreach (var spawnable in items)
        {
            totalChance += spawnable.chance;
        }
    }

    void Start()
    {
        float pick = Random.value * totalChance;
        int i = 0;
        float sumOfChance = items[0].chance;

        while (pick > sumOfChance && i < items.Count - 1)
        {
            i++;
            sumOfChance += items[i].chance;
        }

        GameObject newObject = Instantiate(items[i].gameObject, transform.position, Quaternion.identity) as GameObject;
        GameObject temp = Instantiate(shadowPrefab) as GameObject;
        temp.GetComponent<ShadowFollowManager>().target = newObject;
        temp.GetComponent<ShadowFollowManager>().isItem = true;
        temp.transform.parent = newObject.transform;

    }
    void FixedUpdate()
    {
        Destroy(gameObject);
    }
}
