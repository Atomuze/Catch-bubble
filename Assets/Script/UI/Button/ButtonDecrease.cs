using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDecrease : MonoBehaviour
{
    public Text txtOffset;
    public void OnButton()
    {
        int offset = int.Parse(txtOffset.GetComponent<Text>().text) - 1;
        txtOffset.GetComponent<Text>().text = offset.ToString();
        GameSetting.offset2 -= 1;
        Debug.Log("On Button: Button Decrease / offset2:" + GameSetting.offset2);
    }
}
