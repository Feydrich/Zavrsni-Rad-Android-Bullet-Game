using UnityEngine;

[CreateAssetMenu(fileName = "InfoLoad.asset", menuName = "Zone structure data")]

public class InfoLoad : ScriptableObject
{
    public int numberOfCrawlers;
    public int iterationMin;
    public int iterationMax;
}
