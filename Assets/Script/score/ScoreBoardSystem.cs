using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreBoardSystem : MonoBehaviour
{
    [SerializeField]
    public GameObject perfectCount;
    public GameObject greatCount;
    public GameObject missCount;

    // Start is called before the first frame update
    void Start()
    {
        perfectCount.GetComponent<TextMeshProUGUI>().text = GameSetting.judgeCount[0].ToString();
        greatCount.GetComponent<TextMeshProUGUI>().text = GameSetting.judgeCount[1].ToString();
        missCount.GetComponent<TextMeshProUGUI>().text = GameSetting.judgeCount[2].ToString();
    }
}
