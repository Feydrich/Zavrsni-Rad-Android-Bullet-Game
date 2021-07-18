using UnityEngine;

[CreateAssetMenu(fileName = "Creator.asset", menuName = "Creator")]
public class ScriptableObjectCreator: ScriptableObject
{
    public GameObject createObject;
    public int min, max;
}
