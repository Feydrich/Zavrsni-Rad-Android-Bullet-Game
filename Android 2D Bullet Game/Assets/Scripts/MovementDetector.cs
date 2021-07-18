using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementDetector : MonoBehaviour
{
    public GameObject target;
    public float offsetX, offsetY, scaleX, scaleY;
    public float timer = 2;
    public Vector3 mine, his;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        his = target.transform.position;
        mine = transform.position;
        transform.position = new Vector3(target.transform.position.x - offsetX, target.transform.position.y - offsetY);
        timer -= Time.deltaTime;
        transform.localScale = new Vector3(1, 1);
        
    }
}
