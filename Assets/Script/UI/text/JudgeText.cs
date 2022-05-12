using UnityEngine;
using TMPro;

public class JudgeText : MonoBehaviour
{
    TextMesh judgeText;
    int frameCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("setting judge text");
        judgeText = GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        frameCount++;
        if (frameCount > 60)
        {
            Destroy(gameObject);
        }
    }
}
