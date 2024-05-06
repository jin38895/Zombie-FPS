using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int enemiesAlive = 0;
    public int round = 0;
    public GameObject[] spawnPoints;
    public GameObject enemyPrefab;
    public Text roundText;
    public Text roundsSurvivedNum;
    public GameObject endScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesAlive == 0)
        {
            round++;
            roundText.text = "Round: " + round.ToString();
            NextWave(round);
        }
    }

    private void NextWave(int round)
    {
        for (var x=0; x<round; x++)
        {
            GameObject spawnPoint = spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Length)];
            GameObject spawnedEnemy = Instantiate(enemyPrefab, spawnPoint.transform.position, Quaternion.identity);
            spawnedEnemy.GetComponent<ZombieController>().gameManager = GetComponent<GameManager>();
            enemiesAlive++;
        }
    }

    public void EndScreen()
    {
        Cursor.lockState = CursorLockMode.None;
        roundsSurvivedNum.text = round.ToString();
        endScreen.SetActive(true);
    }

    public void Replay()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
