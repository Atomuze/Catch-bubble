using UnityEngine;
using UnityEngine.UI;

public class ComboText : MonoBehaviour
{
    public Text textCombo;
    public static int count = 0;

    void Update()
    {
        if (count > 0)
        {
            textCombo.text = "Combo " + count;
        }
        else
        {
            textCombo.text = "";
        }
    }
}
