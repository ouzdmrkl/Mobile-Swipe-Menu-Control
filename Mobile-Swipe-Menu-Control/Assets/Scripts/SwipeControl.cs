using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeControl : MonoBehaviour
{
    public Characters characters_Script;
    
    // If we don't check swipe for once, we can change several things with one swipe
    private bool can_Swipe;
    
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                // deltaPosition works like, when you touch the screen, your touch point is origin (0,0).
                // For an example, if you go up after first touch, deltaPosition.y is bigger than zero (0,1)
                if (touch.deltaPosition.y > 0.1f && can_Swipe)
                {
                    SwipeUp(); // Lets call our SwipeUp() method
                    can_Swipe = false; // Set our swipe checker to false
                }
                
                else if (touch.deltaPosition.y < -0.1f && can_Swipe)
                {
                    SwipeDown();
                    can_Swipe = false;
                }

                if (touch.deltaPosition.x > 0.1f && can_Swipe)
                {
                    SwipeRight();
                    can_Swipe = false;
                }
                
                else if (touch.deltaPosition.x < -0.1f && can_Swipe)
                {
                    SwipeLeft();
                    can_Swipe = false;
                }
            }
            
            else if(touch.phase == TouchPhase.Ended)
            {
                can_Swipe = true; // If touch ended, we can swipe again
            }
        }
    }

    void SwipeUp()
    {
        characters_Script.ColorCharacter(1);
    }
    
    void SwipeDown()
    {
        characters_Script.ColorCharacter(-1);
    }
    
    void SwipeRight()
    {
        characters_Script.ChangeCharacter(1);
    }
    
    void SwipeLeft()
    {
        characters_Script.ChangeCharacter(-1);
    }
}
