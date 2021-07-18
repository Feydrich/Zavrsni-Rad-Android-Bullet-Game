using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowFollowManager : MonoBehaviour
{

    public GameObject target;
    public float offsetX, offsetY, scaleX, scaleY;
    public bool isItem = false;
    public Vector3 point;

    // Start is called before the first frame update
    void Start()
    {
        point = new Vector3(target.transform.position.x - offsetX, target.transform.position.y - offsetY);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isItem)
        {
            transform.position = new Vector3(target.transform.position.x - offsetX, target.transform.position.y - offsetY);
        }

        else {
            transform.position = point;
        }
        
        if (target == null) {
            Debug.LogWarning("object missing");
        }
    }
}
