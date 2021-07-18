using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorruptionHandler : MonoBehaviour
{
    public GameObject[] Segments;

    public void CorruptionCall() {

        for (int i = 0; i < Segments.Length; i++) {
            Segments[i].GetComponent<CorruptionManager>().hasExpanded = false;
        }

        for (int i = 0; i < Segments.Length; i++) {
            StartCoroutine(Expand(1, i));
        }   
    }

    private IEnumerator Expand(float waitTime, int i)
    {
        Segments[i].GetComponent<CorruptionManager>().expand();
        yield return new WaitForSeconds(waitTime);
            
        
    }


}
