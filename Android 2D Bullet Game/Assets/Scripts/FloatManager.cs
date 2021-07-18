using UnityEngine;
using System.Collections;

public class FloatManager : MonoBehaviour
{
    
    public float degreesPerSecond = 0f;
    public float amplitude = 0.5f;
    public float frequency = 1f;

    Vector3 posOffset, tempPos;

    void Start()
    {
        posOffset = transform.position;
    }

    void FixedUpdate()
    {
      
        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;
        transform.position = tempPos;
    }
}