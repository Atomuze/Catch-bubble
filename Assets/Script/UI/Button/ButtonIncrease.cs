using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonIncrease : MonoBehaviour
{
    public Text txtOffset;
    public void OnButton()
    {
        int offset = int.Parse(txtOffset.GetComponent<Text>().text) + 1;
        txtOffset.GetComponent<Text>().text = offset.ToString();
        Debug.Log(offset);
    }
}
