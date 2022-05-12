using System;
using TMPro;
using UnityEngine;

public class ButtonSelectSong : MonoBehaviour
{
    private string[] song_id = { "milk_powder_money" };
    private string[] songName_display = { "Milk Powder Money - Dexmio" };
    public TextMeshProUGUI gameObj;

    public void OnBtn()
    {
        string btnId = gameObj.GetComponent<TextMeshProUGUI>().name = song_id[0];
        string btnText = gameObj.GetComponent<TextMeshProUGUI>().text = songName_display[0];

        int i = 0;
        if(btnId.Equals("Select Song"))
        {
            gameObj.GetComponent<TextMeshProUGUI>().name = song_id[0];
            gameObj.GetComponent<TextMeshProUGUI>().text = songName_display[0];
        }
        else
        {
            i = Array.IndexOf(song_id, btnId);
            if (i == song_id.Length - 1)
            {
                gameObj.GetComponent<TextMeshProUGUI>().name = song_id[0];
                gameObj.GetComponent<TextMeshProUGUI>().text = songName_display[0];
                i = 0;
            }
            else
            {
                i++;
                gameObj.GetComponent<TextMeshProUGUI>().name = song_id[i];
                gameObj.GetComponent<TextMeshProUGUI>().text = songName_display[i];
            }
        }
    }
}
