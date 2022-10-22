using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenTouch : MonoBehaviour
{
    private static bool touched = false;
    private static bool touching = false;
    private static bool touchrelease = false;
    private static bool oneTouch = false;

    void Update()
    {
        touched = false;
        touchrelease = false;
        Touch touch;
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    touched = true;
                    touching = true;
                    break;

                case TouchPhase.Ended:
                    touching = false;
                    touchrelease = true;
                    break;
            }
        }
    }

    public static bool getTouched()
    {
        return touched;
    }
    public static bool getTouching()
    {
        return touching;
    }

    public static bool getTouchRelease()
    {
        return touchrelease;
    }

    public static bool getOneTouch()
    {
        return oneTouch;
    }
}