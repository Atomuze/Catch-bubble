using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetting
{
    //player
    public static int speed = 2;
    public static int offset2 = 0;

    //debug
    public static bool autoplay = false;
    public static bool debugMode = false;

    //internal
    public static string songName = "null";
    public static string musicId = "null";

    public static int[] judgeFrame = new int[] { 3, 6 };    //perfect great
    public static int[] judgeCount = new int[] { 0, 0, 0};  //perfect great miss

    public static int width = 0;
    public static int height = 0;
}
