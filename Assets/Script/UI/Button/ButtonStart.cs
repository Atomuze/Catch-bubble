using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonStart : MonoBehaviour
{
   //public Text btnSST;
    public Text txtOffsetPlayer;

    public void OnButton()
    {
        Debug.Log("OnButtonStart");
        

        Debug.Log(GameSetting.songId);
        if (!GameSetting.songId.Equals("null"))
        {
            SceneManager.LoadScene("playing");
            //Debug.Log("t " + txtOffset.GetComponent<Text>().text);
            GameSetting.offset2 = int.Parse(txtOffsetPlayer.GetComponent<Text>().text);
        }
        
    }
}
