using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonStart : MonoBehaviour
{
    public Text btnSST;
    public Text txtOffset;

    public void OnButton()
    {
        Debug.Log("OnButtonStart");
        

        Debug.Log(GameSetting.songId);
        if (!GameSetting.songId.Equals("null"))
        {
            SceneManager.LoadScene("playing");
            GameSetting.offset2 = int.Parse(txtOffset.GetComponent<Text>().text);
        }
        
    }
}
