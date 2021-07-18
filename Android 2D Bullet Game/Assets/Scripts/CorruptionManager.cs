using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum CorruptionRate
{
    Clean,
    Partial,
    Full
};

public class CorruptionManager : MonoBehaviour
{

    public SpriteRenderer SpriteHandler;
    public Sprite Clean, Partial, Full;
    public int proof;
    public CorruptionRate State;
    public GameObject reference;
    public bool hasExpanded = false;

    void FixedUpdate()
    {
        switch (State) {
            case (CorruptionRate.Clean):
                SpriteHandler.sprite = Clean;
                break;
            case (CorruptionRate.Partial):
                SpriteHandler.sprite = Partial;
                break;
            case (CorruptionRate.Full):
                SpriteHandler.sprite = Full;
                break;
            default:
                SpriteHandler.sprite = Clean;
                break;
        }
    }

    public void expand() {
        switch (State)
        {
            case (CorruptionRate.Clean):
                break;
            case (CorruptionRate.Partial):
                if (hasExpanded == false)
                {
                    State = CorruptionRate.Full;
                    hasExpanded = true;
                    switch (reference.GetComponent<ClickerManager>().Type) {
                        case (dungeonType.Forest2):
                            reference.GetComponent<ClickerManager>().Type = dungeonType.Forest3;
                            break;
                        case (dungeonType.Beach2):
                            reference.GetComponent<ClickerManager>().Type = dungeonType.Beach3;
                            break;
                        case (dungeonType.Snow2):
                            reference.GetComponent<ClickerManager>().Type = dungeonType.Snow2;
                            break;
                        case (dungeonType.Forest):
                            reference.GetComponent<ClickerManager>().Type = dungeonType.Forest3;
                            break;
                        case (dungeonType.Beach):
                            reference.GetComponent<ClickerManager>().Type = dungeonType.Beach3;
                            break;
                        case (dungeonType.Snow):
                            reference.GetComponent<ClickerManager>().Type = dungeonType.Snow2;
                            break;
                    }


                }
                break;
            case (CorruptionRate.Full):
                GameObject expansion = null;
                for (int i = 0; i < reference.GetComponent<ClickerManager>().neighbour.Length; i++) {
                    if (reference.GetComponent<ClickerManager>().neighbour[i].GetComponent<CorruptionManager>().State == CorruptionRate.Clean && reference.GetComponent<ClickerManager>().neighbour[i].tag != "Tundra" && hasExpanded == false && reference.GetComponent<CorruptionManager>().hasExpanded == false && (reference.GetComponent<ClickerManager>().neighbour[i].GetComponent<ClickerManager>().Type!=dungeonType.Snow2)) {
                        expansion = reference.GetComponent<ClickerManager>().neighbour[i];
                        hasExpanded = true;
                        break;
                    }
                }
                if (expansion != null) {
                    expansion.GetComponent<CorruptionManager>().State = CorruptionRate.Partial;
                    switch (expansion.GetComponent<ClickerManager>().Type)
                    {
                        case (dungeonType.Forest):
                            expansion.GetComponent<ClickerManager>().Type = dungeonType.Forest2;
                            break;
                        case (dungeonType.Forest3):
                            expansion.GetComponent<ClickerManager>().Type = dungeonType.Forest2;
                            break;
                        case (dungeonType.Beach):
                            expansion.GetComponent<ClickerManager>().Type = dungeonType.Beach2;
                            break;
                        case (dungeonType.Beach3):
                            expansion.GetComponent<ClickerManager>().Type = dungeonType.Beach2;
                            break;
                        case (dungeonType.Snow):
                            reference.GetComponent<ClickerManager>().Type = dungeonType.Snow2;
                            break;
                    }
                }
                break;
            default:
                break;
        }
    }
}
