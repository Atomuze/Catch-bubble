using UnityEngine;

public class Taps : MonoBehaviour
{
    int[] judgeFrameCount;
    private int frameCount = 0;
    public TextMesh textObj;

    private void Start()
    {
        judgeFrameCount = GameSetting.judgeFrame;
    }
    void Update()
    {
        Vector2 pos = transform.position;
        float distanceSquare = (pos.x * pos.x + pos.y * pos.y);
        int distanceByFrame = ScenceSystem.fpsTarget/GameSetting.speed;
        frameCount++;

        if (distanceSquare > 0)
        {
            Vector2 runDirection = pos / Mathf.Sqrt(distanceSquare) * 5f / distanceByFrame;
;
            transform.position = pos - runDirection;
        }

        if (GameSetting.autoplay)
        {
            if (frameCount > distanceByFrame)
            {
                judgeReport(3);
                GameSetting.judgeCount[0]++;
                destory();
            }
        }
        else
        {
            
            if (distanceSquare < 0.01)
            {
                transform.position = new Vector2(0, 0);
                transform.localScale -= new Vector3(1f / judgeFrameCount[1], 1f / judgeFrameCount[1], 0);
            }


            if (frameCount > distanceByFrame - judgeFrameCount[0] && frameCount < distanceByFrame + judgeFrameCount[0])
            {
                if (ScreenTouch.getTouched() || Input.GetButtonDown("Fire1"))
                {
                    judgeReport(0);
                    GameSetting.judgeCount[0]++;
                    destory();
                }

            }
            else if (frameCount > distanceByFrame - judgeFrameCount[1] && frameCount < distanceByFrame + judgeFrameCount[1])
            {
                if (ScreenTouch.getTouched() || Input.GetButtonDown("Fire1"))
                {
                    judgeReport(1);
                    GameSetting.judgeCount[1]++;
                    destory();
                }
            }


            if (frameCount > distanceByFrame + judgeFrameCount[1])
            {
                judgeReport(2);
                GameSetting.judgeCount[2]++;
                destory();
            }
            
        }

    }
    private void judgeReport(int status)
    {   
        TextMesh judgeText = Instantiate(textObj);
        switch (status)
        {
            case 0:
                judgeText.color = Color.yellow;
                judgeText.text = "PERFECT";
                ComboText.count++;
                break;
            case 1:
                judgeText.color = Color.cyan;
                judgeText.text = "GREAT";
                ComboText.count++;
                break;
            case 2:
                judgeText.color = Color.white;
                judgeText.text = "MISS";
                ComboText.count = 0;
                break;
            case 3:
                judgeText.color = Color.red;
                judgeText.text = "perfect";
                ComboText.count++;
                break;
        }
    }
    public void destory()
    {
        Destroy(gameObject);
    }
}