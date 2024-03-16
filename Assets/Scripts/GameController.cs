using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public TextMeshProUGUI scoreText;
    public int spawnCount =5;
    public float spawnWait;
    public float startSpawn;
    public float waveWait;
    int score= 0;
    public TextMeshProUGUI gameOverText,QuitGameText;
    public TextMeshProUGUI restartText;
    public bool gameOver,restart;

    void Update()
    {
        if (restart == true )
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(0);
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Application.Quit();
            }
        }
    }

    IEnumerator SpawnValues()
    {
        while(true)
        {
        yield return new WaitForSeconds(startSpawn);
        for (int i = 0; i < spawnCount; i++)
        {
        Vector3 spawnPosition = new Vector3(Random.Range(-4,4),1,10);
        Quaternion spawnRotation =Quaternion.identity;

        Instantiate(hazard,spawnPosition,spawnRotation);

        yield return new WaitForSeconds(spawnWait);

        }
        yield return new WaitForSeconds(waveWait);
        if (gameOver == true)
        {
            restartText.text = "Press 'R' for Restart";
            QuitGameText.text = "Press 'Q' for Quit";
            restart = true;
            break;
        }
        }

    }
    public void GameOver () {
        gameOverText.text = "Game Over";
        gameOver = true;
    }
    

    public void UpdateScore ()
    {
        score +=10;
        scoreText.text="Score : "+score.ToString();
    }

    void Start()
    {
        gameOver = false;
        restart = false;
        StartCoroutine(SpawnValues());
    }
}
