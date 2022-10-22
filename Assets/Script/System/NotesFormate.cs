using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesFormate
{
    public static List<string> notes = new List<string>();
    public static List<float> tapSpawnTime = new List<float>();
    public static List<List<float>> longSpawnTime = new List<List<float>>();
    public static List<int> tapSpawnDegree = new List<int>();
    public static List<int> longSpawnDegree = new List<int>();

    public static void formates(string data, float frameRate)
    {
        //read
        MusicInfo musicInfo;
        musicInfo = JsonUtility.FromJson<MusicInfo>(data);
        tapSpawnTime.Clear();
        tapSpawnDegree.Clear();
        notes.Clear();
        int bpm = musicInfo.bpm;

        for (int i = 0; i < musicInfo.note.Count; i++)
        {
            foreach (string j in musicInfo.note[i].Split(','))
            {
                notes.Add(j);
            }
        }

        //Debug.Log("format tap...");

        float beatCount = 0;
        float beat = 4;
        for (int i = 0; i < notes.Count; i++)
        {
            float time;
            float endBeatCount = 0;
            int degree = -1;

            if (notes[i].Contains("{"))
            {
                string[] temp = notes[i].Split('{', '}');
                beat = System.Convert.ToSingle(int.Parse(temp[1]));       //beats   4/4, 3/4...
                beatCount += (4f / beat);
                time = ((frameRate / bpm) * beatCount);
                //Respawn time base on sec
                if (temp[2].Contains("["))
                {
                    string[] longtext = temp[2].Split('[', '/', ']');
                    degree = int.Parse(longtext[1]);
                    endBeatCount = int.Parse(longtext[2]);
                }
                else if (!temp[2].Equals(""))
                {
                    degree = int.Parse(temp[2]);
                }
            }
            else if (notes[i].Contains("["))
            {
                beatCount += (4 / beat);
                time = ((frameRate / bpm) * beatCount);
                string[] longtext = notes[i].Split('[', '/', ']');
                degree = int.Parse(longtext[1]);
                endBeatCount = int.Parse(longtext[2]);
            }
            else
            {
                beatCount += (4 / beat);
                time = ((frameRate / bpm) * beatCount);
                if (!notes[i].Equals(""))
                {
                    degree = int.Parse(notes[i]);
                }
            }

            if (degree != -1)
            {
                if (endBeatCount != 0) {
                    float endTime = (frameRate / bpm) * endBeatCount;
                    longSpawnTime.Add(new List<float>() { time, endTime });
                    longSpawnDegree.Add(degree);
                }
                else
                {
                    tapSpawnTime.Add(time);
                    tapSpawnDegree.Add(degree);
                }
            }
        }
    }

    public static List<string> getnote()
    {
        return notes;
    }

    public static List<float> getTapSpawnTime()
    {
        return tapSpawnTime;
    }

    public static List<int> getTapSpawnDegree()
    {
        return tapSpawnDegree;
    }

    public static List<List<float>> getLongSpawnTime()
    {
        return longSpawnTime;
    }

    public static List<int> getLongSpawnDegree()
    {
        return longSpawnDegree;
    }

}
