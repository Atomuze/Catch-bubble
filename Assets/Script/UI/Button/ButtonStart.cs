using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonStart : MonoBehaviour
{
    public void OnButton()
    {
        Debug.Log("On Button: Start");
        //Debug.Log(GameSetting.musicId);

        if (!GameSetting.musicId.Equals("null"))
        {
            SceneManager.LoadScene("playing");
        }else
        {
            Debug.Log("plz select Music");
        }
    }
}
