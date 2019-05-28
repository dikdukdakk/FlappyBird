using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    int hightscore;
    int lastscore;
    void Update()
    {
        lastscore = PlayerPrefs.GetInt("score");
        hightscore = PlayerPrefs.GetInt("highscore");
        if (lastscore > hightscore)
            PlayerPrefs.SetInt("highscore",lastscore);

    }

    void LateUpdate()
    {
        hightscore = PlayerPrefs.GetInt("highscore");
        GetComponent<Text>().text = "" + hightscore;
    }
}
