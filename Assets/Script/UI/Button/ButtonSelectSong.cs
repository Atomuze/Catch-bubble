using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSelectSong : MonoBehaviour
{
    private string[] song_id = { "milk_powder_money" };
    private string[] songName_display = { "Milk Powder Money - Dexmio" };
    public Text gameObj;

    public void OnBtn()
    {
        string btnId = gameObj.GetComponent<Text>().name = song_id[0];
        string btnText = gameObj.GetComponent<Text>().text = songName_display[0];

        int i = 0;
        if(btnId.Equals("Select Song"))
        {
            gameObj.GetComponent<Text>().name = song_id[0];
            gameObj.GetComponent<Text>().text = songName_display[0];
        }
        else
        {
            i = Array.IndexOf(song_id, btnId);
            if (i == song_id.Length - 1)
            {
                gameObj.GetComponent<Text>().name = song_id[0];
                gameObj.GetComponent<Text>().text = songName_display[0];
                i = 0;
            }
            else
            {
                i++;
                gameObj.GetComponent<Text>().name = song_id[i];
                gameObj.GetComponent<Text>().text = songName_display[i];
            }
        }
    }
}
