using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextGameName : MonoBehaviour
{
    int frame = 0;

    void Update()
    {
        frame++;
        if (frame > 60)
        {
            gameObject.GetComponent<Text>().color = new Color(
                Random.Range(0f, 1f),
                Random.Range(0f, 1f),
                Random.Range(0f, 1f)
            );
            frame = 0;
        }
    }
}
