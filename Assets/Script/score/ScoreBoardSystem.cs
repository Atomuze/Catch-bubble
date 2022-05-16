using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoardSystem : MonoBehaviour
{
    [SerializeField]
    public GameObject perfectCount;
    public GameObject greatCount;
    public GameObject missCount;

    // Start is called before the first frame update
    void Start()
    {
        perfectCount.GetComponent<Text>().text = GameSetting.judgeCount[0].ToString();
        greatCount.GetComponent<Text>().text = GameSetting.judgeCount[1].ToString();
        missCount.GetComponent<Text>().text = GameSetting.judgeCount[2].ToString();
    }
}
