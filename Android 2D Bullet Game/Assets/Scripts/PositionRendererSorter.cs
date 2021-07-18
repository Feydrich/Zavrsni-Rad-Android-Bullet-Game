using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PositionRendererSorter : MonoBehaviour
{
    public int sortingOrderBase = 5000;
    public int offset = 0;
    public bool runOnce = false;
    private Renderer myRenderer;
    private float timer;
    private float timerMax = 0.1f;


    private void Awake()
    {
        myRenderer = gameObject.GetComponent<Renderer>();
    }

    private void LateUpdate()
    {
        
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            timer = timerMax;
            myRenderer.sortingOrder = (int)(sortingOrderBase - transform.position.y - offset);
            if (runOnce)
            {
                Destroy(this);
            }
        }
    }


}
