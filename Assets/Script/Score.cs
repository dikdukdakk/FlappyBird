using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    static public int score;

    void Update()
    {
        GetComponent<Text>().text = "" + score;
        PlayerPrefs.SetInt("score", score);
    }
}
