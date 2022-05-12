using TMPro;
using UnityEngine;

public class ComboText : MonoBehaviour
{
    public TMP_Text Text;
    public static int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (count > 0)
        {
            Text.text = "Combo " + count;
        }
        else
        {
            Text.text = "";
        }
    }
}
