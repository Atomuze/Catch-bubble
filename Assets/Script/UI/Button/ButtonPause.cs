using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPause : MonoBehaviour
{

    public static float pauseTime = 0f, pausingTime = 0f;
    public void OnBtn()
    {
        if (ScenceSystem.ispause == false)
        {
            ScenceSystem.ispause = true;
            pauseTime = Time.time;
            Debug.Log("pause");
        }
        else
        {
            ScenceSystem.ispause = false;
            pausingTime = (Time.time - pauseTime) * 1000;
            Debug.Log("start");
        }
    }

}
