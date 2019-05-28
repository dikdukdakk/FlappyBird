using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gameOver;
    public GameObject spawnerPIPE;
    public GameObject score;

    void Start()
    {
        Score.score = 0;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("02_GameScene");
    }

    public void GameOver()
    {
        spawnerPIPE.SetActive(false);
        GameObject[] stopPIPE = GameObject.FindGameObjectsWithTag("Pipe");
        for (int i = 0; i < stopPIPE.Length; i++){
            stopPIPE[i].GetComponent<MovePipe>().enabled = false;
        }

        StartCoroutine(DelayActiveGameOverUI());

        Debug.Log("GameOver");
    }

    IEnumerator DelayActiveGameOverUI()
    {
        yield return new WaitForSeconds(1.5f);
        gameOver.SetActive(true);
        score.SetActive(false);
        Time.timeScale = 0;
    }


    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;    
    }

}
