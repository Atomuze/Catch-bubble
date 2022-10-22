using UnityEngine;

public class longs : MonoBehaviour
{
    private int[] judgeFrame;
    int rotateDegree;
    private int frameCount = 0, endFrame, endSpFrame, judge = 2;      //Judge: 0=perfect, 1=great, 2=miss
    int distanceByFrame = ScenceSystem.fpsTarget / GameSetting.speed;
    public TextMesh textObj;
    public GameObject noteLongS;    //ObjS
    public GameObject noteLongB;    //ObjB
    public GameObject noteLongE;    //ObjE
    private Vector2 initPos;
    GameObject ObjB, ObjS, ObjE;

    private void Start()
    {
        initPos = transform.position;
        judgeFrame = GameSetting.judgeFrame;

        //spawn start
        ObjS = Instantiate(noteLongS);
        ObjS.transform.position = initPos;

        //spawn between
        rotateDegree = int.Parse(gameObject.name.Split('/')[1]);
        float fl = rotateDegree * Mathf.PI / 180.0f;
        ObjB = Instantiate(noteLongB);
        ObjB.transform.position = new Vector2(Mathf.Sin(fl), Mathf.Cos(fl)) * 5;
        ObjB.transform.localScale = new Vector3(0, 0, 0);
        ObjB.transform.Rotate(0, 0, -rotateDegree);

        //spawn end
        ObjE = Instantiate(noteLongE);
        ObjE.transform.position = initPos;

        endSpFrame = (int)(int.Parse(gameObject.name.Split('g', '/')[1]) / (1f / ScenceSystem.fpsTarget));
        endFrame = distanceByFrame + endSpFrame;
    }

    void Update()
    {
        Vector2 posE = ObjE.transform.position;
        Vector2 posS = ObjS.transform.position;
        float distanceSquareE = (posE.x * posE.x + posE.y * posE.y);
        float distanceSquareS = (posS.x * posS.x + posS.y * posS.y);
        frameCount++;

        if (distanceSquareS > 0)
        {
            Vector2 runDirection = posS / Mathf.Sqrt(distanceSquareS) * 5f / distanceByFrame;
            ObjS.transform.position = posS - runDirection;
        }

        if (endSpFrame < frameCount)
        {
            if (distanceSquareE > 0)
            {
                Vector2 runDirection = posE / Mathf.Sqrt(distanceSquareE) * 5f / distanceByFrame;
                ObjE.transform.position = posE - runDirection;
            }
        }
        else
        {
            ObjE.transform.position = initPos;
        }

        ObjB.transform.position = (ObjE.transform.position + ObjS.transform.position) / 2;
        float scale = Vector2.Distance(ObjE.transform.position, ObjS.transform.position);
        ObjB.transform.localScale = new Vector3(0.5f, scale, 0);

        if (distanceSquareS < 0.01)
        {
            ObjS.transform.position = new Vector2(0, 0);
        }

        if (distanceSquareE < 0.01)
        {
            ObjE.transform.position = new Vector2(0, 0);
            ObjB.GetComponent<Renderer>().enabled = false;
        }

        if (GameSetting.autoplay)
        {
            if (frameCount > endFrame)
            {
                judgeReport(3);
                GameSetting.judgeCount[0]++;
                destory();
            }
        }
        else
        {
            if (distanceSquareE < 0.01)
            {
                narrow();
            }

            //toruch start
            if (frameCount > distanceByFrame - judgeFrame[0] && frameCount < distanceByFrame + judgeFrame[0])
            {
                if (ScreenTouch.getTouched())
                {
                    judge = 0;
                }
            }
            else if (frameCount > distanceByFrame - judgeFrame[1] && frameCount < distanceByFrame + judgeFrame[1])
            {
                if (ScreenTouch.getTouched())
                {
                    judge = 1;
                }
            }
            else if (frameCount > distanceByFrame + judgeFrame[1])
            {
                if (judge == 2)
                {
                    judgeReport(2);
                    GameSetting.judgeCount[2]++;
                    destory();
                }
            }

            //touch release
            if (frameCount > endFrame - judgeFrame[0] && frameCount < endFrame + judgeFrame[0])
            {
                if (ScreenTouch.getTouchRelease())
                {
                    if (judge == 0)
                    {
                        judgeReport(0);
                        GameSetting.judgeCount[0]++;
                        destory();
                    }
                    else
                    {
                        judgeReport(1);
                        GameSetting.judgeCount[1]++;
                        destory();
                    }
                }
            }
            else if (frameCount > endFrame - judgeFrame[1] && frameCount < endFrame + judgeFrame[1])
            {
                if (ScreenTouch.getTouchRelease())
                {
                    judgeReport(1);
                    GameSetting.judgeCount[1]++;
                    destory();
                }
            }
            else if (frameCount > endFrame + judgeFrame[1])
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
                Debug.Log(ComboText.count);
                break;
        }
    }
    private void destory()
    {
        Destroy(ObjS);
        Destroy(ObjB);
        Destroy(ObjE);
        Destroy(gameObject);
    }

    private void narrow()
    {
        ObjS.transform.localScale -= new Vector3(1f / judgeFrame[1], 1f / judgeFrame[1], 0);
        ObjB.transform.localScale -= new Vector3(1f / judgeFrame[1], 1f / judgeFrame[1], 0);
        ObjE.transform.localScale -= new Vector3(1f / judgeFrame[1], 1f / judgeFrame[1], 0);
    }

    private void debugTouch()
    {

        if (ScreenTouch.getTouched())
        {
            Debug.Log("touch start");
        }
        if (ScreenTouch.getTouching())
        {
            Debug.Log("touching");
        }
        if (ScreenTouch.getTouchRelease())
        {
            Debug.Log("Touch Release");
        }
    }

}
