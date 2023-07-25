using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isGameStart;
    public bool isPlayerDead;
    public bool isGameEnd;
    public GameObject startPanel;
    public GameObject gameOverPanelGO;
    public GameObject winPanelGO;
    public int levelCount;
    public TextMeshProUGUI levelText;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        Application.targetFrameRate = 60;

        if (PlayerPrefs.HasKey("Level"))
        {
            levelCount = PlayerPrefs.GetInt("Level");
        }
        else
        {
            levelCount = 1;
        }
    }

    private void Start()
    {
        PlayerAnimator.instance.PlayAnim("Idle");

        levelText.text = "Level " + levelCount.ToString();
    }

    public void StartGame()
    {
        isGameStart = true;
        startPanel.SetActive(false);
        PlayerAnimator.instance.PlayAnim("Run");
    }

    public void GameOver()
    {
        AdsController.instance.ShowAd();
        gameOverPanelGO.gameObject.SetActive(true);
    }

    public void InvokeGameOver()
    {
        Invoke(nameof(GameOver), 1.5f);
    }

    public void Win()
    {
        AdsController.instance.ShowAd();
        winPanelGO.gameObject.SetActive(true);
        levelCount++;

        PlayerPrefs.SetInt("Level", levelCount);
    }

    public void InvokeWin(int winDelay)
    {
        Invoke(nameof(Win), winDelay);
    }

    public void NextLevel()
    {
        int randLevel = Random.Range(0, SceneManager.sceneCountInBuildSettings);
        SceneManager.LoadScene(randLevel);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
