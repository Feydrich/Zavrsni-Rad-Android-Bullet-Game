using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DirectionFace
{
    Up,
    Down,
    Left,
    Right,
    Idle
};

public enum State
{
    Positive,
    Negative
};

public class DirectionManager : MonoBehaviour
{
    public GameObject player;
    public DirectionFace direction;
    public State stateH, stateV;
    public float horizontal, vertical;
    public Animator animator;
    
    void LateUpdate()
    {
        horizontal = player.GetComponent<PlayerManager>().joystick1.Horizontal;
        vertical = player.GetComponent<PlayerManager>().joystick1.Vertical;

        if (horizontal > 0)
            stateH = State.Positive;
        else
            stateH = State.Negative;

        if (vertical > 0)
            stateV = State.Positive;
        else
            stateV = State.Negative;

        switch (stateH)
        {
            case (State.Positive):
                switch (stateV)
                {
                    case (State.Positive):
                        if (horizontal > vertical)
                            direction = DirectionFace.Right;
                        else
                            direction = DirectionFace.Up;
                        break;
                    case (State.Negative):
                        if (horizontal > Mathf.Abs(vertical))
                            direction = DirectionFace.Right;
                        else
                            direction = DirectionFace.Down;
                        break;
                }
                break;
            case (State.Negative):
                switch (stateV)
                {
                    case (State.Positive):
                        if (Mathf.Abs(horizontal) > vertical)
                            direction = DirectionFace.Left;
                        else
                            direction = DirectionFace.Up;
                        break;
                    case (State.Negative):
                        if (Mathf.Abs(horizontal) > Mathf.Abs(vertical))
                            direction = DirectionFace.Left;
                        else
                            direction = DirectionFace.Down;
                        break;
                }
                break;
        }

        if (horizontal == 0 && vertical == 0)
        {
            direction = DirectionFace.Idle;
        }

        switch (direction)
        {
            case (DirectionFace.Up):
                animator.SetInteger("Direction", 4);
                break;
            case (DirectionFace.Down):
                animator.SetInteger("Direction", 1);
                break;
            case (DirectionFace.Left):
                animator.SetInteger("Direction", 2);
                break;
            case (DirectionFace.Right):
                animator.SetInteger("Direction", 3);
                break;
            case (DirectionFace.Idle):
                animator.SetInteger("Direction", 0);
                break;
        }

        
    }
    
    
    
}
