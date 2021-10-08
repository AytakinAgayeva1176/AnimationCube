using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private Animation playerAnimationComponent;
    [SerializeField] private float swipeDistance;
    private Vector2 initialMousePos;
    private bool isFingerDown = false;
    private SwipeDirection swipeDirection;

    void Start()
    {
        
    }

    void Update()
    {
        if (isFingerDown==false && Input.GetMouseButtonDown(0))
        {
            isFingerDown = true;
            initialMousePos = Input.mousePosition;
        }

        if (isFingerDown == true && Input.mousePosition.y >= initialMousePos.y+swipeDistance)
        {
            swipeDirection = SwipeDirection.UP;
            Debug.Log(swipeDirection);
            isFingerDown = false;
        }

        else if (isFingerDown == true && Input.mousePosition.y <= initialMousePos.y - swipeDistance)
        {
            swipeDirection = SwipeDirection.DOWN;
            Debug.Log(swipeDirection);
            isFingerDown = false;
        }
        if (isFingerDown == true && Input.mousePosition.x >= initialMousePos.x + swipeDistance)
        {
            swipeDirection = SwipeDirection.RIGHT;
            isFingerDown = false;
            Debug.Log(swipeDirection);

        }
        else if(isFingerDown == true && Input.mousePosition.x <= initialMousePos.x - swipeDistance)
        {
            swipeDirection = SwipeDirection.LEFT;
            isFingerDown = false;
            Debug.Log(swipeDirection);
        }
    }


}


public enum SwipeDirection { LEFT, RIGHT, DOWN, UP}
