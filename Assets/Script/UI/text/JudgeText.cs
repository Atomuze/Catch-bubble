using UnityEngine;
using TMPro;

public class JudgeText : MonoBehaviour
{
    TextMesh judgeText;
    int frameCount = 0;
    float alpha = 1;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("setting judge text");
        judgeText = GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 0.02f, 0);
        judgeText.color = new Color(judgeText.color.r, judgeText.color.g, judgeText.color.b, alpha);
        alpha = alpha - 0.04f;
        frameCount++;
        if (frameCount > 60)
        {
            Destroy(gameObject);
        }
    }
}
