using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSelectSong : MonoBehaviour
{
    private string[] song_Id = { "milk_powder_money" };
    private string[] song_Name = { "Milk Powder Money - Dexmio" };
    public Text text;
    public void OnBtn()
    {
        int i = 0;
        if(GameSetting.musicId.Equals("null"))
        {
            GameSetting.musicId = song_Id[0];
            GameSetting.songName = song_Name[0];
            text.GetComponent<Text>().text = song_Name[0];
        }
        else
        {
            if (i == song_Id.Length - 1)
            {
                i = 0;
                GameSetting.musicId = song_Id[i];
                GameSetting.songName = song_Name[i];
                text.GetComponent<Text>().text = song_Name[i];
            }
            else
            {
                i++;
                GameSetting.musicId = song_Id[i];
                GameSetting.songName = song_Name[i];
                text.GetComponent<Text>().text = song_Name[i];
            }
        }
    }
}
