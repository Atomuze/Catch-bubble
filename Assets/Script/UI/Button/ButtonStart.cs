using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonStart : MonoBehaviour
{
    public TextMeshProUGUI btnSST;
    public Text txtOffset;
    public void OnButton()
    {
        Debug.Log("OnButtonStart");
        

        GameSetting.title = btnSST.GetComponent<TextMeshProUGUI>().name;
        Debug.Log(GameSetting.title);
        if (!GameSetting.title.Equals("select_song"))
        {
            SceneManager.LoadScene("playing");
            GameSetting.offset2 = int.Parse(txtOffset.GetComponent<Text>().text);
        }
        
    }
}